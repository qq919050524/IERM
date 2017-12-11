using IERM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace IERM.WCFService
{
    public class ElevatorModel
    {
        private ElevatorAlarm _alarm = new ElevatorAlarm();
        private BLL.ElevatorInfoBLL _bll = new BLL.ElevatorInfoBLL();

        /// <summary>
        /// 电梯注集合
        /// </summary>
        public List<MODEL.ElevatorInfoModel> elevatorList { get; set; }
        
        /// <summary>
        /// 金太阳运行监控返回结果
        /// </summary>
        public Dictionary<string, JTYResultModel> apiRunDataResultDic = new Dictionary<string, JTYResultModel>();

        /// <summary>
        /// 输出信息
        /// </summary>
        public Action<string> ShowMsg;

        /// <summary>
        /// 是否按小区分组
        /// </summary>
        public bool IsGroupCommunity { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public ElevatorModel()
        {
            //初始化调用一次
            var elevatorList = _bll.GetelEvatorList();
        }

        /// <summary>
        /// 启动通讯
        /// </summary>
        public void StartClient()
        {
            try
            {
                if (elevatorList.Count == 0) return;
                if (ShowMsg != null)
                {
                    ShowMsg("启动电梯运行监控");
                }
                //调用金太阳详细，接口频率有限制（1分5次）
                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(x =>
                    {
                        do
                        {
                            CacheLift();
                            if (ShowMsg != null)
                            {
                                ShowMsg(string.Format("电梯详细数据缓存完成，时间：{0}", DateTime.Now));
                            }
                            TimeSpan ts = CacheHelper.ExpireTime.AddMinutes(10) - DateTime.Now;
                            Thread.Sleep(ts.Seconds * 1000);
                        } while (1 == 1);

                    })
                );
               
                //调用金太阳，实时监控
                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(x =>
                    {
                        do
                        {
                            SetApiRunDataResultDic();
                            if (ShowMsg != null)
                            {
                                ShowMsg(string.Format("电梯运行监控：{0};时间：{1}", apiRunDataResultDic.Count, DateTime.Now));
                            }
                            Thread.Sleep(2000);
                        } while (1 == 1);
                    })
                );
                Thread.Sleep(60000);
                //处理异常
                ThreadPool.QueueUserWorkItem(
                    new WaitCallback(x =>
                    {
                        do
                        {
                            AlarmHandler();
                            Thread.Sleep(2000);
                        } while (1 == 1);
                    })
                );
            }
            catch (Exception e)
            {
                if (ShowMsg != null)
                {
                    ShowMsg(string.Format("{0};时间：{1}", e.Message, DateTime.Now));
                }
                LogHelper.Dbbug("电梯运行监控,连接服务器异常：原因如下：" + e.Message);
            }
        }
        /// <summary>
        /// 缓存电梯详细
        /// </summary>
        /// <returns></returns>
        private bool CacheLift()
        {
            try
            {
                List<MODEL.ElevatorInfoModel> list = Clone<List<MODEL.ElevatorInfoModel>>(elevatorList);
                foreach (MODEL.ElevatorInfoModel model in list)
                {
                    JTYResultModel result = JTYApiHelp.GetLiftDetail(model.registrationCode);
                    if (ShowMsg != null)
                    {
                        ShowMsg(string.Format("电梯详细缓存，{0},{1}", model.registrationCode, result.head));
                    }
                    Thread.Sleep(15000);
                }
                return true;
            }
            catch (Exception e)
            {
                if (ShowMsg != null)
                {
                    ShowMsg("缓存详细error：原因如下：" + e.Message);
                }
                LogHelper.Dbbug("缓存详细error：原因如下：" + e.Message);
                return false;

            }
        }
        /// <summary>
        /// 视频
        /// </summary>
        /// <returns></returns>
        private bool CacheVideo()
        {
            try
            {
                List<MODEL.ElevatorInfoModel> list = Clone<List<MODEL.ElevatorInfoModel>>(elevatorList);
                foreach (MODEL.ElevatorInfoModel model in list)
                {
                    JTYResultModel video = JTYApiHelp.GetLiftVideo(model.registrationCode);
                    if (ShowMsg != null)
                    {
                        ShowMsg(string.Format("电梯视频缓存，{0},{1}", model.registrationCode, video.head));
                    }
                    Thread.Sleep(15000);
                }
                return true;
            }
            catch (Exception e)
            {
                if (ShowMsg != null)
                {
                    ShowMsg("缓存电梯error：原因如下：" + e.Message);
                }
                LogHelper.Dbbug("缓存电梯error：原因如下：" + e.Message);
                return false;

            }
        }
        /// <summary>
        /// 保持实时监控
        /// </summary>
        private bool SetApiRunDataResultDic()
        {
            try
            {
                List<MODEL.ElevatorInfoModel> list = Clone<List<MODEL.ElevatorInfoModel>>(elevatorList);
                List<string> registrationCodes = new List<string>();
                for (int i = 0, n = 1; i < list.Count; i++, n++)
                {
                    registrationCodes.Add(list[i].registrationCode);
                    if (n % 50 == 0 || i == list.Count - 1)
                    {
                        n = 0;
                        //调用api
                        JTYResultModel resultModel = JTYApiHelp.GetLiftRunData(registrationCodes.ToArray());
                        if (resultModel.issuccess)
                        {
                            //成功数据处理
                            dynamic d = JsonConvert.DeserializeObject(resultModel.para);
                            foreach (string registrationCode in registrationCodes)
                            {
                                JTYResultModel model = new JTYResultModel()
                                {
                                    issuccess = true,
                                    head = "",
                                    para = JsonConvert.SerializeObject(d[registrationCode])
                                };
                                //结果插入dic
                                if (apiRunDataResultDic.ContainsKey(registrationCode))
                                {
                                    apiRunDataResultDic[registrationCode] = model;
                                }
                                else
                                {
                                    apiRunDataResultDic.Add(registrationCode, model);
                                }
                            }
                        }
                        else
                        {
                            if (ShowMsg != null)
                            {
                                ShowMsg(string.Format("电梯运行监控,api调用失败{0};时间：{1}", resultModel.head, DateTime.Now));
                            }
                        }
                        registrationCodes.Clear();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                if (ShowMsg != null)
                {
                    ShowMsg("电梯运行监控SetApiRunDataResultDic：原因如下：" + e.Message);
                }
                LogHelper.Dbbug("电梯运行监控SetApiRunDataResultDic：原因如下：" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// 报警
        /// </summary>
        /// <returns></returns>
        private void AlarmHandler()
        {
            try
            {
                if (apiRunDataResultDic.Count > 0)
                {
                    Dictionary<string, JTYResultModel> tempDic = new Dictionary<string, JTYResultModel>();
                    //防止冲突，对apiRunDataResultDic进行拷贝
                    tempDic = Clone<Dictionary<string, JTYResultModel>>(apiRunDataResultDic);
                    foreach (string key in tempDic.Keys)
                    {
                        JTYResultModel result = tempDic[key];
                        if (result.issuccess)
                        {
                            dynamic d = JsonConvert.DeserializeObject(result.para);
                            string errorCodeType = d.ErrorCodeType;
                            string errorCodeMean = d.ErrorCodeMean;
                            bool forHelp = d.ForHelp;
                            bool trapped = d.Trapped;
                            _alarm.AlarmJudge(key, errorCodeType, errorCodeMean, forHelp, trapped);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (ShowMsg != null)
                {
                    ShowMsg("电梯运行监控AlarmHandler：原因如下：" + e.Message);
                }
                LogHelper.Dbbug("电梯运行监控AlarmHandler：原因如下：" + e.Message);
            }
        }
        //防止冲突,对象复制
        private T Clone<T>(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                object retval = bf.Deserialize(ms);
                ms.Close();
                return (T)retval;
            }
        }
    }
}


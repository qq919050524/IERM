using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading;
using IERM.Common;

namespace IERM.WCFService
{
    /// <summary>
    /// 通讯实体类
    /// </summary>
    public class ComunicationModel
    {
        private readonly BLL.CommunicationLogBLL commlog_bll = new BLL.CommunicationLogBLL();

        #region --------属性-----------
        private int _communityid;
        private string _communityname;
        private string _commip;
        private int _commport;
        private int _commcyc;
        //private Dictionary<int, DevHouse.BaseDevHouse> dictdevhouse;
        private Socket _skClient;
        private System.Threading.Timer restartTimer = null;

        public ComunicationModel()
        {
            restartTimer = new System.Threading.Timer(o => StartClient(), null, Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// 小区id
        /// </summary>
        public int CommunityID
        {
            get
            {
                return _communityid;
            }

            set
            {
                _communityid = value;
            }
        }
        /// <summary>
        /// 小区名
        /// </summary>
        public string CommunityName
        {
            get
            {
                return _communityname;
            }

            set
            {
                _communityname = value;
            }
        }
        /// <summary>
        /// 小区通讯地址
        /// </summary>
        public string CommIP
        {
            get
            {
                return _commip;
            }

            set
            {
                _commip = value;
            }
        }
        /// <summary>
        /// 小区通讯端口
        /// </summary>
        public int CommPort
        {
            get
            {
                return _commport;
            }

            set
            {
                _commport = value;
            }
        }
        /// <summary>
        /// 小区通讯周期
        /// </summary>
        public int CommCyc
        {
            get
            {
                return _commcyc;
            }

            set
            {
                _commcyc = value;
            }
        }

        /// <summary>
        /// 小区设备房列表
        /// </summary>
        public Dictionary<int, DevHouse.BaseDevHouse> DictDevHouse
        {
            get
            {
                object obj = CacheHelper.GetCache("ComunicationModel.DictDevHouse");
                if (obj == null)
                {
                    Dictionary<int, DevHouse.BaseDevHouse> DictDevHouse = LoadAllDevhouse();
                    if (DictDevHouse.Count > 0)
                    {
                        CacheHelper.SetCache("ComunicationModel.DictDevHouse", DictDevHouse, CacheHelper.ExpireTime);
                    }
                    return DictDevHouse;
                }
                else
                {
                    return obj as Dictionary<int, DevHouse.BaseDevHouse>;
                }
            }
        }
        /// <summary>
        /// 获取全部设备房
        /// </summary>
        /// <param name="communityid">小区id</param>
        private Dictionary<int, DevHouse.BaseDevHouse> LoadAllDevhouse()
        {
            var dict = new Dictionary<int, DevHouse.BaseDevHouse>();
            var devlist = new BLL.DevInfoBLL().GetDevHouseInfo();
            /// <summary>
            /// 报警设置列表
            /// </summary>
            List<MODEL.AlarmSettingModel> alarmsettinglist = new BLL.AlarmSettingBLL().GetAllAlarmSetting();
            foreach (var item in devlist)
            {
                switch (item.devType)
                {
                    case 1:
                    case 3:
                        dict.Add(item.devID, new DevHouse.PumpHouse(item.devID, alarmsettinglist.Where(w => w.devID == item.devID).ToList()));
                        break;
                    case 2:
                        dict.Add(item.devID, new DevHouse.SwitchRoom(item.devID, alarmsettinglist.Where(w => w.devID == item.devID).ToList()));
                        break;
                    default:
                        dict.Add(item.devID, new DevHouse.PumpHouse(item.devID, alarmsettinglist.Where(w => w.devID == item.devID).ToList()));
                        break;
                }
            }
            return dict;
        }
        /// <summary>
        /// 小区通讯套接字
        /// </summary>
        public Socket SkClient
        {
            get
            {
                return _skClient;
            }

            set
            {
                _skClient = value;
            }
        }

        /// <summary>
        /// 输出信息
        /// </summary>
        public Action<string> ShowMsg;

        #endregion

        /// <summary>
        /// 启动通讯
        /// </summary>
        public void StartClient()
        {

            //1.创建Socket
            if (_skClient == null)
            {
                try
                {
                    _skClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    //开始连接
                    int len = 0;
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(_commip), _commport);

                    _skClient.Connect(endPoint);
                    if (ShowMsg != null)
                    {
                        ShowMsg(string.Format("连接项目：<{0}>成功！  {1}", CommunityName, DateTime.Now));
                        LogHelper.Dbbug("通信服务启动成功！");
                    }

                    ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                    {
                        while (_skClient != null)
                        {
                            byte[] buffers = new byte[1024 * 5];
                            try
                            {
                                len = _skClient.Receive(buffers);
                            }
                            catch (SocketException ex)
                            {
                                LogHelper.Dbbug("接收数据时出现异常，---" + ex.Message);
                                break;
                            }
                            //119.97.206.94
                            if (len > 200)
                            {
                                int index = 0;
                                while (index + 6 < len)
                                {
                                    if (!BinaryHelper.BytesEquals(BinaryHelper.strToToHexByte("3C 2A"), buffers.Skip(index).Take(2).ToArray()))
                                    {
                                        LogHelper.Dbbug("数据包头格式错误！");
                                        break;
                                    }
                                    int devNum = BinaryHelper.bytesToUshort(buffers.Skip(index + 2).Take(2).ToArray());
                                    if (devNum < 1 || devNum > 10000)
                                    {
                                        LogHelper.Dbbug("获取设备编号异常！");
                                        break;
                                    }
                                    int dataLength = BinaryHelper.bytesToUshort(buffers.Skip(index + 4).Take(2).ToArray());

                                    string msg = string.Format("后台未添编号为：<{0}> 的设备房。请联系管理员处理！", devNum);
                                    if (DictDevHouse.ContainsKey(devNum))
                                    {
                                        DictDevHouse[devNum].Decode(buffers.Skip(index + 6).Take(dataLength).ToArray());
                                        msg = string.Format("项目名：[{0}] 设备码：[{1}] 数据包长度：[{2}] 通讯时间：[{3}]", CommunityName, devNum, dataLength, DateTime.Now.ToString("HH:mm:ss fff"));
                                    }
                                    if (ShowMsg != null) { ShowMsg(msg); }
                                    index += 6 + dataLength;
                                }
                            }
                            else if (len == 0)
                            {
                                _skClient.Shutdown(SocketShutdown.Both);
                                _skClient.Close();
                                _skClient = null;
                                if (ShowMsg != null)
                                {
                                    ShowMsg(string.Format("{0}，远程主机强制关闭！60秒后尝试重连", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                }
                                LogHelper.Dbbug(string.Format("远程于{0}主机强制关闭！，连接已断开！", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                restartTimer.Change(60000, Timeout.Infinite);
                                return;
                            }
                            else
                            {
                                LogHelper.Dbbug("数据包长度异常！" + len.ToString());
                                //保存异常数据包
                                commlog_bll.Add(new MODEL.CommunicationLogModel()
                                {
                                    dataSize = len,
                                    data = buffers.Take(len).ToArray(),
                                    InsertTime = DateTime.Now
                                });
                            }
                        }
                    }));


                    if (_skClient != null)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                        {
                            while (_skClient != null)
                            {
                                foreach (var item in DictDevHouse.Values)
                                {
                                    try
                                    {
                                        _skClient.Send(item.Request());
                                        Thread.Sleep(CommCyc);
                                    }
                                    catch (Exception err)
                                    {
                                        _skClient.Shutdown(SocketShutdown.Both);
                                        _skClient.Close();
                                        _skClient = null;
                                        if (ShowMsg != null)
                                        {
                                            ShowMsg(string.Format("请求[{0}]设备房数据时出现异常！连接已断开，60秒后重连", item.DevNum));
                                        }
                                        LogHelper.Dbbug("发起请求时出现异常：原因如下:" + err.Message);
                                        restartTimer.Change(60000, Timeout.Infinite);
                                        return;
                                    }
                                }
                                //每个设备房间隔10秒发送一次查询请求
                                Thread.Sleep(10000);
                            }
                        }));

                    }
                }
                catch (Exception err)
                {
                    _skClient = null;
                    if (ShowMsg != null)
                    {
                        ShowMsg(string.Format("{0};时间：{1}", err.Message, DateTime.Now));
                    }
                    LogHelper.Dbbug("连接服务器异常：原因如下：" + err.Message);
                }

            }
        }




    }
}

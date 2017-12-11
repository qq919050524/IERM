using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Common
{
    public static class JTYApiHelp
    {
        //api url
        private static readonly string _host = ConfigerHelper.GetAppSetting("JTYHost");
        //版本号
        private static readonly string _version = ConfigerHelper.GetAppSetting("JTYVersion");
        //合作方标识
        private static readonly string _partner = ConfigerHelper.GetAppSetting("JTYPartner");
        //api key
        private static readonly string _key = ConfigerHelper.GetAppSetting("JTYKey");

        #region 获取token
        #region 返回参数
        //{
        //    "head": {
        //        "code": 100,//获取成功返回码
        //        "msg": "成功！"//获取成功备注说明
        //    },
        //    "para": {
        //        "token": "3C1AA0EF8A33CACE31EDAD593AE80FD8"//验证通过获取的token
        //    }
        //}
        #endregion
        /// <summary>
        /// 获取token 失败返回空
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        private static string CallApiGetToken()
        {
            try
            {
                string token = "";
                var para = new
                {
                    head = new
                    {
                        version = _version,
                        partner = _partner,
                        key = _key
                    }
                };
                string data = string.Format("data={0}", JsonConvert.SerializeObject(para));
                string url = string.Format("{0}/GetToken.ashx", _host);
                string result = HttpService.Post(data, url);

                dynamic d = JsonConvert.DeserializeObject(result);
                if (d.head.code == 100)
                {
                    token = d.para.token;
                    CacheHelper.SetCache("JTYToken", token, CacheHelper.ExpireTime);
                }
                else
                {
                    LogHelper.Dbbug("金太阳GetToken失败=>" + result);
                }
                return token;
            }
            catch (Exception ex)
            {
                LogHelper.Dbbug("金太阳GetToken失败=>" + ex.ToString());
                throw ex;
            }
        }
        /// <summary>
        /// 根据api错误码，清空token缓存
        /// </summary>
        /// <param name="apiResultCode"></param>
        private static void ClearCacheToken(object apiResultCode)
        {
            int code = Convert.ToInt32(apiResultCode);
            if (code == 203 || code == 204)
                CacheHelper.RemoveCache("JTYToken");
        }
        private static object _lockGetTokenOBj = new object();
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="result">true返回token，false返回错误信息</param>
        /// <returns></returns>
        public static bool GetToken(out string result)
        {
            try
            {
                lock (_lockGetTokenOBj)
                {
                    bool isok = false;
                    result = "";
                    var obj = CacheHelper.GetCache("JTYToken");
                    if (obj == null)
                    {
                        result = CallApiGetToken();
                        if (!string.IsNullOrEmpty(result))
                        {
                            CacheHelper.SetCache("JTYToken", result, CacheHelper.ExpireTime);
                            isok = true;
                        }
                        else
                        {
                            result = "token获取失败";
                            isok = false;
                        }
                    }
                    else
                    {
                        result = obj.ToString();
                        isok = true;
                    }
                    return isok;
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                return false;
            }
        }
        #endregion

        #region 获取运行监控
        #region 返回参数
        // {
        //    "head": {
        //        "code": 100,
        //        "msg": "成功"
        //    },
        //    "para": {
        //        "31104201072012090013": {
        //            "YzName": "XXX 小区",//电梯所属业主单位名称
        //            "Address": "1 栋 1 单元", //电梯所在位置
        //            "InternalNum": "2",//电梯编号
        //            "Floor": 5,//楼层int型（默认0）
        //            "FloorOffset": 0, //电梯楼层修正值，解决地下楼与显示误差int型23
        //            "Open": 0,//电梯开关门状态0：关门，1：开门int型（默认0）
        //            "UpOrDown": -1,//电梯上下行状态0: 停止1: 上行-1: 下行int型（默认0）
        //            "ErrorCodeType": "日立 gvf-ii1000-c090 58",//当前故障码类型（电梯品牌+电梯型号+当前故障码）
        //            "ErrorCodeMean": "速度低故障" //当前故障码含意
        //        },
        //        "31104201072012090014": {
        //            "YzName": null,
        //            "Address": null,
        //            "InternalNum": null,
        //            "Floor": 0,
        //            "FloorOffset": 0,
        //            "Open": 0,
        //            "UpOrDown": 0,
        //            "ErrorCodeType": null,
        //            "ErrorCodeMean": null
        //        }
        //    }
        //}
        #endregion
        private static object _lockLiftRunDataOBj = new object();
        /// <summary>
        /// 获取运行监控
        /// </summary>
        /// <param name="registercodes"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static JTYResultModel GetLiftRunData(string[] registercodes)
        {
            JTYResultModel result = CallApiGetLiftRunData(registercodes);
            return result;
        }

        private static JTYResultModel CallApiGetLiftRunData(string[] registercodes)
        {
            JTYResultModel resultModel = new JTYResultModel();
            resultModel.issuccess = false;
            try
            {
                string token = "";
                if (!GetToken(out token))
                {
                    resultModel.head = token;
                    resultModel.issuccess = false;
                    return resultModel;
                }
                var para = new
                {
                    head = new
                    {
                        version = _version,
                        token = token,
                    },
                    para = new
                    {
                        registercodes = registercodes
                    }
                };
                string data = string.Format("data={0}", JsonConvert.SerializeObject(para));
                string url = string.Format("{0}/GetLiftRunData.ashx", _host);
                dynamic d = JsonConvert.DeserializeObject(HttpService.Post(data, url));
                if (d.head.code == 100)
                {
                    resultModel.head = JsonConvert.SerializeObject(d.head);
                    resultModel.para = JsonConvert.SerializeObject(d.para);
                    resultModel.issuccess = true;
                }
                else
                {
                    resultModel.head = JsonConvert.SerializeObject(d.head);
                    resultModel.para = "";
                    resultModel.issuccess = false;
                    ClearCacheToken(d.head.code);
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                LogHelper.Dbbug("金太阳GetLiftRunData失败=>" + ex.ToString());
                resultModel.head = ex.ToString();
                return resultModel;
            }
        }
        #endregion

        #region 电梯明细
        #region 返回参数
        //{
        //    "head": {
        //        "code": 100,
        //        "msg": "成功"
        //    },
        //    "para": {
        //        "city": "武汉",//业主单位市
        //        "district": "硚口区", //业主单位区（县）
        //        "yzname": "XXX 小区",//业主单位名称
        //        "wyname": "XXXXX 物业管理有限公司",//物业单位名称
        //        "wylinkman": "XXX",//物业单位联系人
        //        "wylinktel": "027-86XXXX18",//物业单位联系电话
        //        "wbname": "XXXX 电梯维保公司",//维保单位名称
        //        "wblinkman": "东方朔",//维保单位联系人
        //        "wblinktel": "15071xxxx",//维保单位联系电话
        //        "registercode": "31104201072012090013",//电梯注册码
        //        "address": "7 栋",//电梯所在位置
        //        "internalnum": "1",//电梯编号
        //        "liftstatus": "运行中",//电梯当前运行状态
        //        "lifttypename": "乘客电梯", //电梯类型
        //        "ycdate": "2017-05-24",//最近一次年检时间（已完成）
        //        "usingtypename": "住宅",//电梯使用类型
        //        "csname": "通力电梯",//电梯厂商名称21
        //        "brand": "通力",//电梯品牌
        //        "liftmodel": "tp10/20-19",//电梯型号
        //        "outfacdate": "2012-02-09",//电梯出厂日期
        //        "tsgd": "30",//提升高度（停靠层站）
        //        "syqdcd": "/", //使用区段长度
        //        "beginusedate": "2016-08-29", //投入使用日期
        //        "registerorg": "武汉市特种设备监督检验所",//电梯注册机构
        //        "remark": ""
        //    }
        //}
        #endregion
        private static object _lockLiftDetailOBj = new object();
        /// <summary>
        /// 电梯明细
        /// </summary>
        /// <param name="registercodes">电梯注册码</param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static JTYResultModel GetLiftDetail(string registercode)
        {
            lock (_lockLiftDetailOBj)
            {
                var obj = CacheHelper.GetCache("GetLiftDetail_" + registercode);
                if (obj == null)
                {
                    JTYResultModel resultModel = CallApiGetLiftDetail(registercode);
                    if (resultModel.issuccess)
                    {
                        CacheHelper.SetCache("GetLiftDetail_" + registercode, resultModel, CacheHelper.ExpireTime);
                    }
                    return resultModel;
                }
                else
                {
                    JTYResultModel result = obj as JTYResultModel;
                    return result;
                }
            }
        }
        private static JTYResultModel CallApiGetLiftDetail(string registercode)
        {
            JTYResultModel resultModel = new JTYResultModel();
            resultModel.issuccess = false;
            try
            {
                string token = "";
                if (!GetToken(out token))
                {
                    resultModel.head = token;
                    resultModel.issuccess = false;
                    return resultModel;
                }
                var para = new
                {
                    head = new
                    {
                        version = _version,
                        token = token,
                    },
                    para = new
                    {
                        registercode = registercode
                    }
                };
                string data = string.Format("data={0}", JsonConvert.SerializeObject(para));
                string url = string.Format("{0}/GetLiftDetail.ashx", _host);
                dynamic d = JsonConvert.DeserializeObject(HttpService.Post(data, url));
                if (d.head.code == 100)
                {
                    resultModel.head = JsonConvert.SerializeObject(d.head);
                    resultModel.para = JsonConvert.SerializeObject(d.para);
                    resultModel.issuccess = true;
                }
                else
                {
                    resultModel.head = JsonConvert.SerializeObject(d.head);
                    resultModel.para = "";
                    resultModel.issuccess = false;
                    ClearCacheToken(d.head.code);
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                LogHelper.Dbbug("金太阳GetLiftDetail失败=>" + ex.ToString());
                resultModel.head = ex.ToString();
                return resultModel;
            }

        }
        #endregion

        #region 电梯视频
        #region 返回参数
        //{
        //"head":{ "code":100, "msg":"成功" }, 
        //"para":{
        //"url": "http://www.kingorient.com/meeting.html?mac=ccb8a8197c04&vendorKey=00465050c4f5fc0936c1b3ad85b2d50 917bdfef9fcdba85c59799f14fef8dd000000000" //多功能报警机实时视频 URL 地址 } 
        //}
        #endregion
        private static object _lockLiftVideoOBj = new object();
        public static JTYResultModel GetLiftVideo(string registercode)
        {
            lock (_lockLiftVideoOBj)
            {
                var obj = CacheHelper.GetCache("GetLiftVideo_" + registercode);
                if (obj == null)
                {
                    JTYResultModel resultModel = CallApiGetLiftVideo(registercode);
                    //if (resultModel.issuccess)
                    //{
                    //    CacheHelper.SetCache("GetLiftVideo_" + registercode, resultModel, DateTime.Now.AddMinutes(1));
                    //}
                    return resultModel;
                }
                else
                {
                    JTYResultModel result = obj as JTYResultModel;
                    return result;
                }
            }
        }

        private static JTYResultModel CallApiGetLiftVideo(string registercode)
        {
            JTYResultModel resultModel = new JTYResultModel();
            resultModel.issuccess = false;
            try
            {
                string token = "";
                if (!GetToken(out token))
                {
                    resultModel.head = token;
                    resultModel.issuccess = false;
                    return resultModel;
                }
                var para = new
                {
                    head = new
                    {
                        version = _version,
                        partner = _partner,
                        key = _key
                    },
                    para = new
                    {
                        registercode = registercode
                    }
                };
                string data = string.Format("data={0}", JsonConvert.SerializeObject(para));
                string url = string.Format("{0}/GetLiftVideo.ashx", _host);
                dynamic d = JsonConvert.DeserializeObject(HttpService.Post(data, url));
                if (d.head.code == 100)
                {
                    resultModel.head = JsonConvert.SerializeObject(d.head);
                    resultModel.para = JsonConvert.SerializeObject(d.para);
                    resultModel.issuccess = true;
                }
                else
                {
                    resultModel.head = JsonConvert.SerializeObject(d.head);
                    resultModel.para = "";
                    resultModel.issuccess = false;
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                LogHelper.Dbbug("金太阳GetLiftVideo失败=>" + ex.ToString());
                resultModel.head = ex.ToString();
                return resultModel;
            }

        }
        #endregion
    }
    [Serializable]
    public class JTYResultModel
    {
        public JTYResultModel()
        {
            head = ""; para = ""; issuccess = false;
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string head { get; set; }
        /// <summary>
        /// 结果（JSON字符串，js端需要JSON.pas）
        /// </summary>
        public string para { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool issuccess { get; set; }
    }

}

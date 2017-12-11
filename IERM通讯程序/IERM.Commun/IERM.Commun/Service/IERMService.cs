using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IERM.Common;
using IERM.IService;

namespace IERM.WCFService
{
    public class IERMService : IServiceBase
    {
        public string GetDataByDevID(int devhouseNum)
        {
            var jr = new MODEL.JsonResultModel<DevHouse.BaseDevHouse>()
            {
                IsSucceed = false,
                Data = null,
                Msg = "无法访问WCF服务，请检查WCF服务是否启动或访问地址是否正确！",
                RedirectUrl = string.Empty
            };
            if (WCFStartForm.commModel.DictDevHouse.Keys.Contains(devhouseNum))
            {
                var tmpdata = WCFStartForm.commModel.DictDevHouse[devhouseNum];
                if (tmpdata != null)
                {
                    jr.IsSucceed = true;
                    jr.Data = tmpdata;
                    jr.Msg = "获取设备房数据成功！";
                }
            }
            else
            {
                jr.Msg = "不存在请求的设备房号！";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 获取电梯明细
        /// </summary>
        /// <param name="registercode"></param>
        /// <returns></returns>
        public string GetLiftDetail(string registercode)
        {
            JTYResultModel model = JTYApiHelp.GetLiftDetail(registercode);
            var jr = new MODEL.JsonResultModel<string>()
            {
                IsSucceed = model.issuccess,
                Data = model.para,
                Msg = model.head,
                RedirectUrl = string.Empty
            };

            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 电梯运行数据
        /// </summary>
        /// <param name="communityid"></param>
        /// <param name="registercode"></param>
        /// <returns></returns>
        public string GetLiftRunData(string registercode)
        {

            var jr = new MODEL.JsonResultModel<string>()
            {
                IsSucceed = false,
                Data = null,
                Msg = "无法访问WCF服务，请检查WCF服务是否启动或访问地址是否正确！",
                RedirectUrl = string.Empty
            };
            if (WCFStartForm.elevatorModel.apiRunDataResultDic.ContainsKey(registercode))
            {
                var tmpdata = WCFStartForm.elevatorModel.apiRunDataResultDic[registercode];
                if (tmpdata != null)
                {
                    jr.IsSucceed = tmpdata.issuccess;
                    jr.Data = tmpdata.para;
                    jr.Msg = tmpdata.head;
                }
            }
            else
            {
                jr.Msg = "小区没有监控的电梯！";
            }
            return JsonConvert.SerializeObject(jr);
        }

        /// <summary>
        /// 电梯视频
        /// </summary>
        /// <param name="registercode"></param>
        /// <returns></returns>
        public string GetLiftVideo(string registercode)
        {
            JTYResultModel model = JTYApiHelp.GetLiftVideo(registercode);
            var jr = new MODEL.JsonResultModel<string>()
            {
                IsSucceed = model.issuccess,
                Data = model.para,
                Msg = model.head,
                RedirectUrl = string.Empty
            };

            return JsonConvert.SerializeObject(jr);
        }
    }
}

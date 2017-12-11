using IERM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.WCFService
{
    public class ElevatorAlarm
    {
        private BLL.AlarmElevatorBLL _bll = new BLL.AlarmElevatorBLL();
        /// <summary>
        /// 电梯报警记录，每部电梯一条记录
        /// </summary>
        public Dictionary<string, Dictionary<string, MODEL.AlarmElevatorModel>> alarmElevatorDic = new Dictionary<string, Dictionary<string, MODEL.AlarmElevatorModel>>();

        #region 报警判断,记录数据库
        /// <summary>
        /// 报警判断,记录数据库
        /// </summary>
        /// <param name="registrationCode">电梯注册码</param>
        /// <param name="errorCodeType">金太阳其他=（电梯品牌+电梯型号+当前故障码）</param>
        /// <param name="errorCodeMean">当前故障码含意 </param>
        /// <param name="forHelp">手动报警标识（false：正常 true：手动报警）</param>
        /// <param name="trapped">困人标识（false：正常 true：手动报警）</param>
        public void AlarmJudge(string registrationCode, string errorCodeType, string errorCodeMean, bool forHelp, bool trapped)
        {
            if (string.IsNullOrEmpty(registrationCode)) return;
            //金太阳其他
            if (!string.IsNullOrEmpty(errorCodeType))
            {
                MODEL.AlarmElevatorModel model = new MODEL.AlarmElevatorModel();
                model.registrationCode = registrationCode;
                model.errorCodeType = errorCodeType;
                model.errorCodeMean = errorCodeMean;
                model.customCode = "other";
                model.alarmState = -1;
                model.insertTime = DateTime.Now;

                AlarmRecord(registrationCode, model);
            }
            else
            {
                MODEL.AlarmElevatorModel model = new MODEL.AlarmElevatorModel();
                model.registrationCode = registrationCode;
                model.errorCodeType = "noProblem";
                model.errorCodeMean = "报警恢复(不包含手动和困人)";
                model.customCode = "other";
                model.alarmState = 1;
                model.insertTime = DateTime.Now;

                AlarmRecord(registrationCode, model);
            }
            //手动报警
            if (forHelp)
            {
                MODEL.AlarmElevatorModel model = new MODEL.AlarmElevatorModel();
                model.registrationCode = registrationCode;
                model.errorCodeType = "forHelp";
                model.errorCodeMean = "手动报警";
                model.customCode = "forHelp";
                model.alarmState = -1;
                model.insertTime = DateTime.Now;

                AlarmRecord(registrationCode, model);
            }
            else
            {
                MODEL.AlarmElevatorModel model = new MODEL.AlarmElevatorModel();
                model.registrationCode = registrationCode;
                model.errorCodeType = "noProblem";
                model.errorCodeMean = "手动报警恢复";
                model.customCode = "forHelp";
                model.alarmState = 1;
                model.insertTime = DateTime.Now;

                AlarmRecord(registrationCode, model);
            }
            //困人报警
            if (trapped)
            {
                MODEL.AlarmElevatorModel model = new MODEL.AlarmElevatorModel();
                model.registrationCode = registrationCode;
                model.errorCodeType = "trapped";
                model.errorCodeMean = "困人报警";
                model.customCode = "trapped";
                model.alarmState = -1;
                model.insertTime = DateTime.Now;

                AlarmRecord(registrationCode, model);
            }
            else
            {
                MODEL.AlarmElevatorModel model = new MODEL.AlarmElevatorModel();
                model.registrationCode = registrationCode;
                model.errorCodeType = "noProblem";
                model.errorCodeMean = "困人报警恢复";
                model.customCode = "trapped";
                model.alarmState = 1;
                model.insertTime = DateTime.Now;

                AlarmRecord(registrationCode, model);
            }
        }
        /// <summary>
        /// 对比,插入数据库
        /// </summary>
        /// <param name="registrationCode"></param>
        /// <param name="model"></param>
        private void AlarmRecord(string registrationCode, MODEL.AlarmElevatorModel model)
        {
            if (alarmElevatorDic.ContainsKey(registrationCode))
            {
                Dictionary<string, MODEL.AlarmElevatorModel> historyDic = alarmElevatorDic[registrationCode];
                if (historyDic.ContainsKey(model.customCode))
                {
                    MODEL.AlarmElevatorModel historyDicModel = historyDic[model.customCode];
                    //报警&&错误不相同
                    if (model.alarmState == -1 && !model.errorCodeType.Equals(historyDicModel.errorCodeType))
                    {
                        _bll.Add(model);

                    }
                    //复位
                    else if (model.alarmState == 1 && historyDicModel.alarmState == -1)
                    {
                        _bll.Add(model);
                    }
                    //更新历史记录
                    historyDic[model.customCode] = model;
                }
                else
                {
                    MODEL.AlarmElevatorModel LatestEvent = _bll.GetLatestEvent(registrationCode, model.customCode);
                    //第一次报警,判断数据状态
                    if (LatestEvent != null && model.alarmState != LatestEvent.alarmState)
                    {
                        _bll.Add(model);
                    }
                    else if (LatestEvent == null && model.alarmState == -1)
                    {
                        _bll.Add(model);
                    }
                    historyDic.Add(model.customCode, model);
                }
            }
            else
            {
                MODEL.AlarmElevatorModel LatestEvent = _bll.GetLatestEvent(registrationCode, model.customCode);
                //第一次报警,判断数据状态
                if (LatestEvent != null && model.alarmState != LatestEvent.alarmState)
                {
                    _bll.Add(model);
                }
                else if (LatestEvent == null && model.alarmState == -1)
                {
                    _bll.Add(model);
                }
                Dictionary<string, MODEL.AlarmElevatorModel> dic = new Dictionary<string, MODEL.AlarmElevatorModel>();
                dic.Add(model.customCode, model);
                alarmElevatorDic.Add(registrationCode, dic);
            }
        }
        #endregion
    }
}

using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class AlarmSettingBLL
    {
        private readonly AlarmSettingDAL alarmsetting_dal = new AlarmSettingDAL();
        /// <summary>
        /// 获取指定设备类型的报警类型
        /// </summary>
        /// <param name="devtype"></param>
        /// <returns></returns>
        public List<AlarmSettingModel> GetAlarmTypeListByDevType(int devtype)
        {
            return alarmsetting_dal.GetAlarmTypeListByDevType(devtype);
        }

        /// <summary>
        /// 获取指定设备的报警设置
        /// </summary>
        /// <param name="devtype"></param>
        /// <returns></returns>
        public List<AlarmSettingModel> GetAlarmListByDevID(int devid)
        {
            return alarmsetting_dal.GetAlarmListByDevID(devid);
        }

        /// <summary>
        /// 保存报警设置
        /// </summary>
        public int SaveAlarmSetting(List<AlarmSettingModel> alarmlist,bool isupdate,DevInfoModel devmodel)
        {
            List<string> cmdlist = new List<string>();
            if(isupdate)
            {
                cmdlist.Add(string.Format("update devinfo set devName='{0}',devType={1} where devID={2}",devmodel.devName,devmodel.devType,devmodel.devID));
                cmdlist.Add(string.Format("DELETE from devhousesystype where devhouseID={0}",devmodel.devID));
                if(!string.IsNullOrEmpty(devmodel.devhouseTypes))
                {
                    cmdlist.AddRange(devmodel.devhouseTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => string.Format("insert into devhousesystype(devhouseID,systypeID) values ({0},{1})", devmodel.devID, s)));
                }
                cmdlist.AddRange(alarmlist.Select(s => string.Format("UPDATE alarmsetting set `maxValue`= {0}, minValue = {1}, isWork = {2},`delayed`= {3},isSend = {4} where devID = {5} and alarmCode = '{6}'", s.maxValue, s.minValue, s.isWork, s.delayed, s.isSend, s.devID, s.alarmCode)));
            }
            else
            {
                cmdlist.Add(string.Format("insert into devinfo(devID,devName,devType,communityID,sort) values ({0},'{1}',{2},{3},{4})", devmodel.devID, devmodel.devName, devmodel.devType, devmodel.communityID,devmodel.sort));
                cmdlist.Add(string.Format("DELETE from devhousesystype where devhouseID={0}", devmodel.devID));
                if (!string.IsNullOrEmpty(devmodel.devhouseTypes))
                {
                    cmdlist.AddRange(devmodel.devhouseTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => string.Format("insert into devhousesystype(devhouseID,systypeID) values ({0},{1})", devmodel.devID, s)));
                }
                cmdlist.Add(string.Format("delete from alarmsetting where devID={0}", devmodel.devID));
                cmdlist.AddRange(alarmlist.Select(s => string.Format("insert into alarmsetting(devID,alarmCode,`maxValue`,minValue,isWork,`delayed`,isSend) values ({0},'{1}',{2},{3},{4},{5},{6})", s.devID, s.alarmCode, s.maxValue, s.minValue, s.isWork, s.delayed, s.isSend)));
            }
            return alarmsetting_dal.SaveAlarmSetting(cmdlist);
        }

        public int DeleteAlarmSetting(int devid)
        {
            List<string> cmdlist = new List<string>();
            cmdlist.Add(string.Format("update devinfo set isDel=1 where devID={0}", devid));
            cmdlist.Add(string.Format("DELETE from devhousesystype where devhouseID={0}", devid));
            cmdlist.Add(string.Format("delete from alarmsetting where devID={0}",devid));
            return alarmsetting_dal.DeleteAlarmSetting(cmdlist);
        }


        public bool GetAlarmSettingSendMessage(string alarmCode) {

            return alarmsetting_dal.GetAlarmSettingSendMessage(alarmCode);

        }
    }
}

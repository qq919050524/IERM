using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class MainTenanceSettingBLL
    {
        private readonly MainTenanceSettingDAL msetting_dal = new MainTenanceSettingDAL();

        /// <summary>
        /// 获取维保计划
        /// </summary>
        /// <param name="devhouseid"></param>
        /// <param name="systypeid"></param>
        /// <returns></returns>
        public List<ViewMainTenanceSettingModel> GetMaintenancesetting(int devhouseid, int systypeid, int pageindex, int pagesize, out int rowcount)
        {
            var tmpdata = msetting_dal.GetMaintenancesetting(devhouseid, systypeid).GroupBy(s => s.sID);
            rowcount = tmpdata.Count();

            return tmpdata.Select(s => new ViewMainTenanceSettingModel()
            {

                cycLength = s.FirstOrDefault().cycLength,
                cycUnit = s.FirstOrDefault().cycUnit,
                devhouseID = s.FirstOrDefault().devhouseID,  //设备房ID
                devName = s.FirstOrDefault().devName,      //设备房
                equCode = s.FirstOrDefault().equCode,
                equID = s.FirstOrDefault().equID,
                equName = s.FirstOrDefault().equName,
                equNum = s.FirstOrDefault().equNum,
                isCyclic = s.FirstOrDefault().isCyclic,
                mType = s.FirstOrDefault().mType,
                mtypeID = s.FirstOrDefault().mtypeID,
                isDel = s.FirstOrDefault().isDel,
                sID = s.FirstOrDefault().sID,
                stratDate = s.FirstOrDefault().stratDate,
                systypeID = s.FirstOrDefault().systypeID,
                mtypeName = s.FirstOrDefault().mtypeName,
                status = s.FirstOrDefault().status,
                systypeName = s.FirstOrDefault().systypeName,
                mtypeList = s.Select(w => new MainTenanceTypeModel()
                {
                    mID = w.mtypeID,
                    mtypeName = w.mtypeName
                }).ToList(),
                flagTime = GetFlagTime(s.FirstOrDefault().sID)
            }).OrderBy(o => o.stratDate).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        /// <summary>
        /// 获取指定维保计划上次和下次的时间
        /// </summary>
        /// <param name="settingid"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetFlagTime(int settingid)
        {
            return msetting_dal.GetFlagTime(settingid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MainTenanceSettingModel model)
        {
            return msetting_dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MainTenanceSettingModel model)
        {
            return msetting_dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int sID)
        {
            return msetting_dal.Delete(sID);
        }
    }
}

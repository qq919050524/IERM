using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class MainTenanceSettingDAL
    {
        /// <summary>
        /// 获取维保计划
        /// </summary>
        /// <param name="devhouseid"></param>
        /// <param name="systypeid"></param>
        /// <returns></returns>
        public List<ViewMainTenanceSettingModel> GetMaintenancesetting(int devhouseid, int systypeid)
        {
            StringBuilder whereStr = new StringBuilder();
            whereStr.AppendFormat(" where devhouseID={0}", devhouseid);
            if(systypeid!=0)
            {
                whereStr.AppendFormat(" and systypeID={0}", systypeid);
            }

            return MySQLHelper.ExecuteToList<ViewMainTenanceSettingModel>("SELECT * from view_maintenancesetting " + whereStr.ToString(), null);
        }

        /// <summary>
        /// 获取指定维保计划上次和下次的时间
        /// </summary>
        /// <param name="settingid"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetFlagTime(int settingid)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("lastDate", "无");
            dict.Add("nextDate", "无");
            DataTable tmp = MySQLHelper.ExecuteToDataTable(string.Format("SELECT ms.*,max(ml.operateTime) as operateTime from maintenancesetting as ms LEFT JOIN maintenancelog as ml on ml.settingID = ms.sID where ms.sID ={0}",settingid), null);
            if(tmp!=null&&tmp.Rows.Count>0)
            {
                int cycunit = Convert.ToInt32(tmp.Rows[0]["cycUnit"]);
                int cyclength = Convert.ToInt32(tmp.Rows[0]["cycLength"]);

                if (tmp.Rows[0]["operateTime"] !=DBNull.Value)
                {
                    dict["lastDate"] = Convert.ToDateTime(tmp.Rows[0]["operateTime"]).ToString("yyyy-MM-dd");
                }
                if(dict["lastDate"]== "无")
                {
                    if (Convert.ToBoolean(tmp.Rows[0]["status"]))
                    {
                        switch (cycunit)
                        {
                            case 1:
                                dict["nextDate"] = Convert.ToDateTime(tmp.Rows[0]["stratDate"]).AddDays(cyclength).ToString("yyyy-MM-dd");
                                break;
                            case 2:
                                dict["nextDate"] = Convert.ToDateTime(tmp.Rows[0]["stratDate"]).AddDays(cyclength * 7).ToString("yyyy-MM-dd");
                                break;
                            default:
                                dict["nextDate"] = Convert.ToDateTime(tmp.Rows[0]["stratDate"]).AddMonths(cyclength).ToString("yyyy-MM-dd");
                                break;
                        }
                    }                        
                }
                else
                {
                    if (Convert.ToBoolean(tmp.Rows[0]["status"]))
                    {
                        dict["nextDate"] = Convert.ToDateTime(dict["lastDate"]).AddMonths(cyclength).ToString("yyyy-MM-dd");
                    }                        
                }
            }
            return dict;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MainTenanceSettingModel model)
        {
            List<string> cmdstrlist = new List<string>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into maintenancesetting(");
            strSql.Append("equID,mType,cycLength,cycUnit,isCyclic,stratDate,status,isDel)");
            strSql.Append(" values (");
            strSql.AppendFormat("{0},{1},{2},{3},{4},'{5}',{6},{7});", model.equID, model.mType, model.cycLength, model.cycUnit, model.isCyclic, model.stratDate, model.status, model.isDel);
            strSql.Append(" select last_insert_id() as insertId");
            string maincmdstr = strSql.ToString();
            

           cmdstrlist.Add(string.Format("DELETE FROM maintenancecontent where settingID={0}", model.sID));

            foreach(var item in model.mcontentList)
            {
                cmdstrlist.Add(string.Format("insert into maintenancecontent (settingID,mtypeID) values([@],{0})",item.mtypeID));
            }

            return MySQLHelper.ExecuteMasterslaveByTran(maincmdstr,cmdstrlist) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MainTenanceSettingModel model)
        {
            List<string> cmdstrlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update maintenancesetting set ");
            strSql.AppendFormat("equID={0},mType={1},cycLength={2},",model.equID,model.mType,model.cycLength);
            strSql.AppendFormat("cycUnit={0},isCyclic={1},stratDate='{2}',",model.cycUnit,model.isCyclic,DateTime.Now);
            strSql.AppendFormat("status={0},isDel={1} where sID={2}", model.status, 0, model.sID);
            cmdstrlist.Add(strSql.ToString());
            cmdstrlist.Add(string.Format("DELETE FROM maintenancecontent where settingID={0}", model.sID));
            foreach (var item in model.mcontentList)
            {
                cmdstrlist.Add(string.Format("insert into maintenancecontent (settingID,mtypeID) values({0},{1})", item.settingID, item.mtypeID));
            }

            return MySQLHelper.ExecuteSqlByTran(cmdstrlist) > 0 ? true : false;

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int sID)
        {
            List<string> cmdstrlist = new List<string>();
            cmdstrlist.Add(string.Format("DELETE FROM maintenancecontent where settingID={0}",sID));
            cmdstrlist.Add(string.Format("DELETE FROM maintenancesetting where sID={0}", sID));
            return MySQLHelper.ExecuteSqlByTran(cmdstrlist) > 0 ? true : false;
        }
    }
}

using IERM.Common;
using IERM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.DAL
{
    public class EquipmentInfoDAL
    {
        /// <summary>
		/// 增加一条数据并返回新行号
		/// </summary>
		public int Add(EquipmentInfoModel model,List<EquipmentaccModel> accdata)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into equipmentinfo(");
            strSql.Append("equName,equCode,equNum,queImgPath,devhouseID,sysTypeID,setupDate,startupDate,agelimit,manufacturer,supplier,supplierContact,mDepartment,mpName,mPhoneNum,device_type_code)");
            strSql.Append(" values (");
            strSql.AppendFormat("'{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}',{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}');",model.equName, model.equCode, model.equNum, model.queImgPath, model.devhouseID, model.sysTypeID, model.setupDate, model.startupDate, model.agelimit, model.manufacturer, model.supplier, model.supplierContact, model.mDepartment, model.mpName, model.mPhoneNum,model.device_type_code);
            strSql.Append(" select last_insert_id() as insertId");
            List<string> acclist = new List<string>();
            acclist.Add("");//这里不用删除原记录
            acclist.AddRange(accdata.Select(s => string.Format("insert into equipmentacc(equID,accName,accNo,accParameter,other) values ([@],'{0}','{1}','{2}','{3}')", s.accName, s.accNo, s.accParameter, s.other)));

            return Convert.ToInt32(MySQLHelper.ExecuteMasterslaveByTran(strSql.ToString(), acclist)) ;
        }

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EquipmentInfoModel model,List<EquipmentaccModel> accdata)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update equipmentinfo set equName='{0}',equCode='{1}',equNum='{2}',",model.equName,model.equCode,model.equNum);
            strSql.AppendFormat("queImgPath='{0}',devhouseID={1},sysTypeID={2},",model.queImgPath,model.devhouseID,model.sysTypeID);
            strSql.AppendFormat("setupDate='{0}',startupDate='{1}',agelimit={2},",model.setupDate,model.startupDate,model.agelimit);
            strSql.AppendFormat("manufacturer='{0}',supplier='{1}',supplierContact='{2}',",model.manufacturer,model.supplier,model.supplierContact);
            strSql.AppendFormat("device_type_code='{0}',", model.device_type_code);
            strSql.AppendFormat("mDepartment='{0}',mpName='{1}',mPhoneNum='{2}' where eID={3};",model.mDepartment,model.mpName,model.mPhoneNum,model.eID);
            List<string> cmdstrlist = new List<string>();
            cmdstrlist.Add(strSql.ToString());
            cmdstrlist.AddRange(accdata.Select(s => string.Format("insert into equipmentacc(equID,accName,accNo,accParameter,other) values ({0},'{1}','{2}','{3}','{4}')", s.equID, s.accName, s.accNo, s.accParameter, s.other)));

            return MySQLHelper.ExecuteSqlByTran(cmdstrlist) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条设备记录
        /// </summary>
        /// <param name="cmdstrlist"></param>
        /// <returns></returns>
        public bool Delete(List<string> cmdstrlist)
        {
            return MySQLHelper.ExecuteSqlByTran(cmdstrlist) > 0 ? true : false;
        }

        /// <summary>
        /// 获取指定设备详细信息
        /// </summary>
        /// <param name="houseid"></param>
        /// <returns></returns>
        public ViewEquinfoModel GetEquipmentinfoByequId(int equid)
        {
            var tmpdata = MySQLHelper.ExecuteToList<ViewEquinfoModel>(string.Format("SELECT * from view_equinfo where eID={0}", equid), null).FirstOrDefault();
            tmpdata.equaccList = MySQLHelper.ExecuteToList<EquipmentaccModel>(string.Format("select * from equipmentacc where equID={0}", equid), null);
            return tmpdata;
        }

        /// <summary>
        /// 获取指定设备房全部设备信息
        /// </summary>
        public List<EquipmentInfoModel> GetEquListByHouseID(int houseid, int pagesize, int pageindex, out int rowcount)
        {
            rowcount = Convert.ToInt32(MySQLHelper.ExecuteScalar(string.Format("SELECT count(1) FROM equipmentinfo where devhouseID={0}", houseid), null));

            if (rowcount == 0) return new List<EquipmentInfoModel>();

            return MySQLHelper.ExecuteToList<EquipmentInfoModel>(string.Format("SELECT ei.eID,ei.equName,ei.equNum,ei.equCode,st.tID as sysTypeID,st.typeName as typeName,ei.setupDate,ei.agelimit,ei.mDepartment,ei.mpName,ei.mPhoneNum,ei.device_type_code from equipmentinfo as ei INNER JOIN systemtype as st on st.tID = ei.sysTypeID where devhouseID={0} order by setupDate LIMIT {1},{2}", houseid, (pageindex - 1) * pagesize, pagesize), null);
        }
        /// <summary>
        /// 根据小区获取设备
        /// </summary>
        /// <param name="communityID"></param>
        /// <returns></returns>
        public List<EquipmentInfoModel> GetEquipmentInfoListByCommunity(int communityID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select e.eID,e.equCode,e.equName,t.devide_type_name from equipmentinfo e ");
            sql.Append(" left join devinfo d on e.devhouseID = d.devID ");
            sql.Append(" left join eccm_device_type t on t.device_type_code = e.device_type_code ");
            sql.Append(" where e.isDel=0 and d.communityID=@communityID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@communityID", communityID),
            };

            return MySQLHelper.ExecuteToList<EquipmentInfoModel>(sql.ToString(), parameters);
        }

        /// <summary>
        /// 根据小区计划选择获取设备
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="type">0获取设备类型，1获取设备</param>
        /// <returns></returns>
        public List<EquipmentInfoModel> GetEquipmentInfoListByCommunityForPlan(int communityID, int type)
        {
            StringBuilder sql = new StringBuilder();
            if (type == 1)//获取设备
            {
                sql.Append(" select e.eID,e.equCode,e.equName,t.devide_type_name from equipmentinfo e ");
                sql.Append(" inner join devinfo d on e.devhouseID = d.devID ");
                sql.Append(" inner join eccm_device_type t on t.device_type_code = e.device_type_code ");
                sql.Append(" where e.isDel=0 and d.communityID=@communityID ");

            }
            else if (type == 0)//获取设备类型
            {
                sql.Append(" select t.devide_type_name,t.device_type_code from equipmentinfo e ");
                sql.Append(" inner join devinfo d on e.devhouseID = d.devID ");
                sql.Append(" inner join eccm_device_type t on t.device_type_code = e.device_type_code ");
                sql.Append(" where e.isDel=0 and d.communityID=@communityID ");
                sql.Append(" GROUP BY t.devide_type_name,t.device_type_code ");
            }
            else { }
            MySqlParameter[] parameters = {
                    new MySqlParameter("@communityID", communityID),
                };
            return MySQLHelper.ExecuteToList<EquipmentInfoModel>(sql.ToString(), parameters);
        }
    }
}

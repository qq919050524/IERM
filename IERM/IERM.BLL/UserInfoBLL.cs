using IERM.Common;
using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public partial class UserInfoBLL
    {
        private readonly UserInfoDAL userinfo_dal = new UserInfoDAL();
        public UserInfoBLL()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int uid)
        {
            return userinfo_dal.Exists(uid);
        }


        /// <summary>
        /// 增加新用户
        /// </summary>
        public bool Add(UserInfoModel model, string roleid, string authcommunity, int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into userinfo(");
            strSql.Append("loginName,password,nickName,mobile,headimg,companyName,departmentName,remark)");
            strSql.Append(" values (");
            strSql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", model.loginName, model.password, model.nickName, model.mobile, model.headimg, model.companyName, model.departmentName, model.remark);
            strSql.Append(" select last_insert_id() as insertId");
            List<string> acclist = new List<string>();
            acclist.Add("");
            acclist.Add(string.Format("insert into userrolerelative(userID,roleID) values ([@],'{0}')", roleid));
            if (string.IsNullOrEmpty(authcommunity))
            {
                acclist.AddRange(new BLL.CommunityInfoBLL().GetCommunity(" and isdel=0 ", uid).Select(s => string.Format("insert into usercommunityrelative(userID,communityID,insertTime) values ([@],{0},'{1}')", s.communityID, DateTime.Now)));
            }
            else
            {
                acclist.AddRange(authcommunity.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => string.Format("insert into usercommunityrelative(userID,communityID,insertTime) values ([@],{0},'{1}')", s, DateTime.Now)));
            }

            return userinfo_dal.Add(strSql.ToString(), acclist);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserInfoModel model, string roleid, string authcommunity, int uid)
        {
            List<string> cmdstrlist = new List<string>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update userinfo set ");
            strSql.AppendFormat("loginName='{0}',nickName='{1}'", model.loginName, model.nickName);
            strSql.AppendFormat(",mobile='{0}',headimg='{1}',companyName='{2}' ", model.mobile, model.headimg, model.companyName);
            strSql.AppendFormat(",departmentName='{0}',remark='{1}' ", model.departmentName, model.remark);
            //strSql.AppendFormat(",password='{1}' ", model.password);
            strSql.AppendFormat("where uid={0}", model.uid);
            cmdstrlist.Add(strSql.ToString());
            cmdstrlist.Add(string.Format("delete from userrolerelative where userID={0}", model.uid));
            cmdstrlist.Add(string.Format("insert into userrolerelative (roleID,userID) value({0},{1})", roleid, model.uid));
            cmdstrlist.Add(string.Format("delete from usercommunityrelative where userID={0}", model.uid));
            if (string.IsNullOrEmpty(authcommunity))
            {
                cmdstrlist.AddRange(new BLL.CommunityInfoBLL().GetCommunity(" and  isdel=0 ", uid).Select(s => string.Format("insert into usercommunityrelative(userID,communityID,insertTime) values ({0},{1},'{2}')", model.uid, s.communityID, DateTime.Now)));
            }
            else
            {
                cmdstrlist.AddRange(authcommunity.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => string.Format("insert into usercommunityrelative(userID,communityID,insertTime) values ({0},{1},'{2}')", model.uid, s, DateTime.Now)));
            }
            return userinfo_dal.Update(cmdstrlist);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int uid)
        {
            return userinfo_dal.Delete(uid);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserInfoModel GetModel(int uid)
        {
            return userinfo_dal.GetModel(uid);
        }

        /// <summary>
        /// 根据用户名和密码判断是否有登录权限
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool CheckLogin(string loginname, string pwd, out UserInfoModel model)
        {
            model = userinfo_dal.GetList(" loginName='" + loginname + "' and isDel=0").FirstOrDefault();
            if (model != null)
            {
                model.actionList = userinfo_dal.GetAuthAction(model.uid);
                model.communityList = userinfo_dal.GetAuthCommunity(model.uid).Where(w => w.isauth == true).Select(s => s.communityID).ToList();

                return ConvertHelper.StringToMD5(pwd).ToLower() == model.password.ToLower() ? true : false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取分页用户权限信息
        /// </summary>
        public DataTable GetPagingUserinfoWithRole(string strWhere, int pageIndex, int pageSize, out int userCount)
        {
            return userinfo_dal.GetPagingUserinfoWithRole(strWhere, pageIndex, pageSize, out userCount);
        }

        /// <summary>
        /// 获取用户授权小区列表
        /// </summary>
        public List<AuthCommunityModel> GetAuthCommunity(int userid, int cityid, string partname)
        {
            var comm = userinfo_dal.GetAuthCommunity(userid);
            var tmpdata = comm.Where(c => c.pCityID == cityid).ToList();
            //var tmpdata = comm.Where(c => c.isauth == true).ToList();
            if (!string.IsNullOrEmpty(partname))
            {
                return tmpdata.Where(s => s.communityName.Contains(partname)).ToList();
            }
            return tmpdata;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public int DeleteUser(int userid)
        {
            //List<string> cmdlist = new List<string>();
            //cmdlist.Add(string.Format("update userinfo set isDel=1 where uid={0}", userid));
            //cmdlist.Add(string.Format("delete from userrolerelative where userID={0}", userid));
            //cmdlist.Add(string.Format("delete from usercommunityrelative where userID={0}", userid));
            //return userinfo_dal.ExecuteCmdList(cmdlist);
            return userinfo_dal.Delete(userid);
        }

        /// <summary>
        /// 根据小区获取用户
        /// </summary>
        /// <param name="communityID"></param>
        /// <returns></returns>
        public List<UserInfoModel> GetUserByCommunity(int communityID)
        {
            return userinfo_dal.GetUserByCommunity(communityID);
        }

    }
}

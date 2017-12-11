using IERM.Message.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.Message.BLL
{
    public class SendMessageBLL
    {
        private readonly DAL.SendMessageDAL dal = new DAL.SendMessageDAL();
        public SendMessageBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sendmsgID)
        {
            return dal.Exists(sendmsgID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SendMessageModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SendMessageModel model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 更改发送状态为正常
        /// </summary>
        public bool UpdateStatus(int devID, string alarmCode)
        {
            return dal.UpdateStatus(devID, alarmCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int sendmsgID)
        {

            return dal.Delete(sendmsgID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string sendmsgIDlist)
        {
            return dal.DeleteList(sendmsgIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SendMessageModel GetModel(int sendmsgID)
        {

            return dal.GetModel(sendmsgID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SendMessageModel> GetModelList(string strWhere)
        {
            DataTable dt = dal.GetList(strWhere);
            return DataTableToList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SendMessageModel> DataTableToList(DataTable dt)
        {
            List<SendMessageModel> modelList = new List<SendMessageModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SendMessageModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
    }
}

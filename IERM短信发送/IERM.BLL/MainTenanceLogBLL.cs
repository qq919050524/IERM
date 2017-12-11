﻿using IERM.Message.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IERM.Message.BLL
{
    public class MainTenanceLogBLL
    {
        private readonly DAL.MainTenanceLogDAL dal = new DAL.MainTenanceLogDAL();

       
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MainTenanceLogModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MainTenanceLogModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int mID)
        {

            return dal.Delete(mID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string mIDlist)
        {
            return dal.DeleteList(mIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MainTenanceLogModel GetModel(int mID)
        {

            return dal.GetModel(mID);
        }

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
        public List<MainTenanceLogModel> GetModelList(string strWhere)
        {
            DataTable dt = dal.GetList(strWhere);
            return DataTableToList(dt);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MainTenanceLogModel> DataTableToList(DataTable dt)
        {
            List<MainTenanceLogModel> modelList = new List<MainTenanceLogModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MainTenanceLogModel model;
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

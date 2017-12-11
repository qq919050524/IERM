using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class CityInfoBLL
    {
        private readonly CityInfoDAL cityinfo_dal = new CityInfoDAL();
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CityInfoModel model)
        {
            return cityinfo_dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(CityInfoModel model)
        {
            return cityinfo_dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int areaID)
        {
            return cityinfo_dal.Delete(areaID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CityInfoModel GetModel(int areaID)
        {
            return cityinfo_dal.GetModel(areaID);
        }

        /// <summary>
        /// 获取所有激活的城市信息
        /// </summary>
        /// <returns></returns>
        public List<CityInfoModel> GetAllCity()
        {
            return cityinfo_dal.GetAllCity();
        }
    }
}

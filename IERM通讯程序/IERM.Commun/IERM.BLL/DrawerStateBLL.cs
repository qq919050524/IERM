using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class DrawerStateBLL
    {
        private readonly DAL.DrawerStateDAL drawerstate_dal = new DAL.DrawerStateDAL();

        /// <summary>
        /// 增加一条数据,返回主键
        /// </summary>
        public int Add(MODEL.DrawerStateModel model)
        {
            return drawerstate_dal.Add(model);
        }

        /// <summary>
        /// 序列化字符串输出
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Serializer(MODEL.DrawerStateModel model)
        {
            return drawerstate_dal.Serializer(model);
        }
    }
}

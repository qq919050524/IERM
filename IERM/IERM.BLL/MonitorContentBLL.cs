using IERM.DAL;
using IERM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.BLL
{
    public class MonitorContentBLL
    {
        private readonly MonitorContentDAL mcontent_dal = new MonitorContentDAL();
        /// <summary>
        /// 获取设备房展示的内容                                            
        /// </summary>
        /// <returns></returns>
        public List<MonitorContentModel> GetMonitorContent(int mid)
        {
            return mcontent_dal.GetMonitorContent(string.Format(" where pID={0} and isDel=0 order by sort asc", mid));
        }
        /// <summary>
        /// 获取页脚html内容
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public string GetFooterContent(int mid)
        {
            var mcontent = GetMonitorContent(mid);
            System.Text.StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mcontent.Count; i++)
            {
                if (i % 6 == 0)
                {
                    sb.Append("<div class='row'>");
                }
                if(mcontent[i].contentCode.ToLower()=="fill")
                {
                    sb.Append("<div class='col-xs-6 col-md-4 col-lg-2'></div>");
                }
                else
                {
                    sb.AppendFormat("<div class='col-xs-6 col-md-4 col-lg-2'><h6>{0}:<span class='{1} label label-default'>---</span> {2}</h6></div>", mcontent[i].contentName, mcontent[i].contentCode, mcontent[i].unit);
                }
               
                if ((i + 1) % 6 == 0)
                {
                    sb.Append("</div>");
                }
            }
            return sb.ToString();
        }
    }
}

using IERM.BLL;
using IERM.Common;
using IERM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IERM.Handler
{
    /// <summary>
    /// StandardHandler 的摘要说明
    /// </summary>
    public class StandardHandler : IHttpHandler
    {
        private readonly EccmStandardBLL bll = new EccmStandardBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Params["action"];
            var result = string.Empty;
            if (string.IsNullOrEmpty(action))
            {
                result = JsonConvert.SerializeObject(new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "行为参数未传递",
                    RedirectUrl = string.Empty
                });
            }
            else
            {
                switch (action.ToLower())
                {
                    case "getstandard"://获取所有标准
                        result = GetStandard(context);
                        break;
                    case "addstandard"://添加新新标准
                        result = AddStandard(context);
                        break;
                    case "updatestandard"://编辑标准
                        result = UpdateStandard(context);
                        break;
                    case "deletestandard"://删除标准
                        result = DeleteStandard(context);
                        break;
                }
            }
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取所有标准
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetStandard(HttpContext context)
        {
            int pagesize = 1;
            int pageindex = 1;
            int rowcount = 0;

            string _pindex = context.Request.Params["pageIndex"];
            string _psize = context.Request.Params["pageSize"];
            string _name = context.Request.Params["name"];
            System.Text.StringBuilder strWhere = new System.Text.StringBuilder();

            if (!string.IsNullOrEmpty(_pindex))
            {
                pageindex = int.Parse(_pindex);
            }
            if (!string.IsNullOrEmpty(_psize))
            {
                pagesize = int.Parse(_psize);
            }
            if (!string.IsNullOrEmpty(_name))
            {
                strWhere.AppendFormat(" inspection_standard like '%{0}%'", _name);
            }

            var pr = new PagingResultModel<DataTable>()
            {
                total = 0,
                rows = new DataTable()
            };
            pr.rows = bll.GetList(strWhere.ToString(), pageindex, pagesize, out rowcount);
            pr.total = rowcount;

            return JsonConvert.SerializeObject(pr);
        }
        /// <summary>
        /// 添加新标准
        /// </summary>
        private string AddStandard(HttpContext context)
        {
            //标准类型
            string type = context.Request.Params["type"];
            //标准内容
            string txt = context.Request.Params["text"];

            //新标准
            EccmStandardModel model = new EccmStandardModel();
            model.standard_type = int.Parse(type);
            model.inspection_standard = txt;

            try
            {
                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "添加标准失败",
                    RedirectUrl = ""
                };

                if (bll.Add(model))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "添加标准成功";
                }
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {
                LogHelper.Debug("添加新标准（AddStandard）---" + err.Message);
                throw err;
            }
        }

        /// <summary>
        /// 更新标准
        /// </summary>
        private string UpdateStandard(HttpContext context)
        {
            //标准ID
            string id = context.Request.Params["id"];
            //标准类型
            string type = context.Request.Params["type"];
            //标准内容
            string txt = context.Request.Params["text"];

            //新标准
            EccmStandardModel model = new EccmStandardModel();
            model.standard_id = int.Parse(id);
            model.standard_type = int.Parse(type);
            model.inspection_standard = txt;
            model.ext1 = "";
            model.ext2 = "";
            model.ext3 = "";

            try
            {
                var jr = new JsonResultModel<int>()
                {
                    IsSucceed = false,
                    Data = 0,
                    Msg = "修改标准失败",
                    RedirectUrl = ""
                };

                if (bll.Update(model))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "修改标准成功";
                }
                return JsonConvert.SerializeObject(jr);
            }
            catch (Exception err)
            {
               LogHelper.Debug("修改标准（UpdateStandard）---" + err.Message);
                throw err;
            }
        }

        /// <summary>
        /// 删除标准
        /// </summary>
        private string DeleteStandard(HttpContext context)
        {
            string id = context.Request.Params["id"];
            var jr = new JsonResultModel<int>()
            {
                IsSucceed = false,
                Data = 0,
                Msg = "删除标准失败",
                RedirectUrl = string.Empty
            };

            if (!string.IsNullOrEmpty(id))
            {

                if (bll.Delete(int.Parse(id)))
                {
                    jr.IsSucceed = true;
                    jr.Msg = "删除标准成功";
                    jr.Data = int.Parse(id);
                }
            }
            return JsonConvert.SerializeObject(jr);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
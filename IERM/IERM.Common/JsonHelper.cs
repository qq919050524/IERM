using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERM.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 序列化数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            JsonSerializerSettings js = new JsonSerializerSettings();
            js.DateFormatString = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";

            return JsonConvert.SerializeObject(value, js);
        }
    }
}

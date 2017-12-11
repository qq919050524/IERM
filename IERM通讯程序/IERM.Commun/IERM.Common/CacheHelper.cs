using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace IERM.Common
{
    public class CacheHelper
    {
        /// <summary>
        /// 默认过期时间凌晨2点
        /// </summary>
        public static DateTime ExpireTime
        {
            get
            {
                return DateTime.Today.AddDays(1).AddHours(2);
            }
        }
        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <param name="CacheKey">键</param>
        public static object GetCache(string CacheKey)
        {
            ObjectCache cache = MemoryCache.Default;
            return cache[CacheKey];
        }

        /// <summary>
        /// 设置带绝对过期时间的数据缓存
        /// </summary>
        public static void SetCache(string CacheKey, object objObject, DateTime? absoluteExpiration = null, TimeSpan? slidingExpiration = null)
        {
            ObjectCache cache = MemoryCache.Default;
            var policy = new CacheItemPolicy();
            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }
            policy.Priority = CacheItemPriority.Default;
            cache.Set(CacheKey, objObject, policy);
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        public static void RemoveCache(string CacheKey)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(CacheKey);
        }

    }
}

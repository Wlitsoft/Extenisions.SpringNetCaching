/**********************************************************************************************************************
 * 描述：
 *      分布式缓存。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年03月19日	 新建
 *********************************************************************************************************************/

using System;
using System.Collections;
using System.Collections.Concurrent;
using Wlitsoft.Framework.Common;
using Wlitsoft.Framework.Common.Extension;
using Wlitsoft.Framework.Common.Core;

namespace Wlitsoft.SpringNet.Extended.Cache
{
    /// <summary>
    /// 分布式缓存。
    /// </summary>
    public class DistributedCache : Spring.Caching.AbstractCache
    {
        //json 序列化者。
        private static readonly ISerializer JsonSerializer;

        private static readonly ConcurrentDictionary<string, Type> Types;

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="DistributedCache"/> 类的静态实例。
        /// </summary>
        static DistributedCache()
        {
            JsonSerializer = App.SerializerService.GetJsonSerializer();
            Types = new ConcurrentDictionary<string, Type>();
        }

        #endregion

        #region Overrides of AbstractCache

        /// <summary>Retrieves an item from the cache.</summary>
        /// <param name="key">Item key.</param>
        /// <returns>
        /// Item for the specified <paramref name="key" />, or <c>null</c>.
        /// </returns>
        public override object Get(object key)
        {
            CacheEntry entry = App.DistributedCache.Get<CacheEntry>(key.ToString());

            if (entry == null || string.IsNullOrEmpty(entry.JsonValue) || string.IsNullOrEmpty(entry.TypeName))
                return null;

            Type type = Types.GetOrAdd(entry.TypeName, Type.GetType(entry.TypeName));

            if (type == null)
            {
                Type outType;
                Types.TryRemove(entry.TypeName, out outType);
                return null;
            }

            return JsonSerializer.Deserialize(type, entry.JsonValue);
        }

        /// <summary>Removes an item from the cache.</summary>
        /// <param name="key">Item key.</param>
        public override void Remove(object key)
        {
            App.DistributedCache.Remove(key.ToString());
        }

        /// <summary>Gets a collection of all cache item keys.</summary>
        public override ICollection Keys
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// Actually does the cache implementation specific insert operation into the cache.
        /// </summary>
        /// <remarks>
        /// Items inserted using this method have default cache priority.
        /// </remarks>
        /// <param name="key">Item key.</param>
        /// <param name="value">Item value.</param>
        /// <param name="timeToLive">Item's time-to-live (TTL).</param>
        protected override void DoInsert(object key, object value, TimeSpan timeToLive)
        {
            CacheEntry entry = new CacheEntry()
            {
                TypeName = value.GetType().AssemblyQualifiedName,
                JsonValue = value.ToJsonString()
            };
            App.DistributedCache.Set<CacheEntry>(key.ToString(), entry, timeToLive);
        }

        #endregion
    }
}

/**********************************************************************************************************************
 * 描述：
 *      缓存项。
 * 
 * 变更历史：
 *      作者：李亮  时间：2017年03月19日	 新建
 *********************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wlitsoft.SpringNet.Extended.Cache
{
    /// <summary>
    /// 缓存项。
    /// </summary>
    public class CacheEntry
    {
        /// <summary>
        /// 获取或设置类型名（包括程序集名称）。
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 获取或设置Json字符串值。
        /// </summary>
        public string JsonValue { get; set; }
    }
}

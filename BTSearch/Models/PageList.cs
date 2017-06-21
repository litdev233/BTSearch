using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSearch.Models
{
    /// <summary>
    /// 分页数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageList<T>
    {
        public T data { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 最大页
        /// </summary>
        public int max_page { get; set; }

    }
}

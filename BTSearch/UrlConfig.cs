using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSearch
{
    /// <summary>
    /// 接口地址
    /// </summary>
    public class UrlConfig
    {
        /// <summary>
        /// 豆瓣热门电影前20条接口地址
        /// </summary>
        public static readonly string APIDouBan = "https://movie.douban.com/j/search_subjects?type=movie&tag=%E7%83%AD%E9%97%A8&sort=recommend&page_limit=30&page_start=0";

        /// <summary>
        /// bt db站的搜索地址
        /// </summary>
        public static readonly string APIBTDB = "http://btdb.in/q/{0}/{1}?sort=popular";

        /// <summary>
        /// bt ku5站的搜索地址
        /// </summary>
        public static readonly string APIBTKu = "http://btku5.com/q/{0}/{1}?sort=_score";

        /// <summary>
        /// 磁力吧的搜索地址
        /// </summary>
        public static readonly string APIBTCiLi = "http://ciliba.net/word/{0}_{1}.html";

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BTSearch.Models
{
    /// <summary>
    /// 豆瓣电影实体集合
    /// </summary
    [DataContract]
    public class DouBan
    {
        /// <summary>
        /// Subjects
        /// </summary>
        [DataMember]
        public List<DouBanSubject> subjects { get; set; }
    }

    /// <summary>
    /// 豆瓣电影
    /// </summary>
    [DataContract]
    public class DouBanSubject
    {
        /// <summary>
        /// 8.1
        /// </summary>
        [DataMember]
        public string rate{get; set;}

        public string rate_int
        {
            get
            {
                double ra = double.Parse(rate);
                if (ra > 0)
                    return (ra / 2).ToString("0.0");
                else
                    return "0";
            }
        }

        /// <summary>
        /// Cover_x
        /// </summary>
        [DataMember]
        public int cover_x { get; set; }
        /// <summary>
        /// Is_beetle_subject
        /// </summary>
        [DataMember]
        public bool is_beetle_subject { get; set; }
        /// <summary>
        /// 猜火车2
        /// </summary>
        [DataMember]
        public string title { get; set; }
        /// <summary>
        /// https://movie.douban.com/subject/22263645/
        /// </summary>
        [DataMember]
        public string url { get; set; }
        /// <summary>
        /// Playable
        /// </summary>
        [DataMember]
        public bool playable { get; set; }
        /// <summary>
        /// https://img3.doubanio.com/view/movie_poster_cover/lpst/public/p2403165796.webp
        /// </summary>
        [DataMember]
        public string cover { get; set; }
        /// <summary>
        /// 22263645
        /// </summary>
        [DataMember]
        public string id { get; set; }
        /// <summary>
        /// Cover_y
        /// </summary>
        [DataMember]
        public int cover_y { get; set; }
        /// <summary>
        /// Is_new
        /// </summary>
        [DataMember]
        public bool is_new { get; set; }
    }

}

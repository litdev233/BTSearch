using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BTSearch.Models
{
    /// <summary>
    /// BT实体信息
    /// </summary>
    [DataContract]
    public class BTInfo
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 文件数量
        /// </summary>
        public int file_num { get; set; }


        /// <summary>
        /// 大小
        /// </summary>
        public string total_size { get; set; }


        /// <summary>
        /// 热度
        /// </summary>
        public int hot { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 磁力链地址
        /// </summary>
        public string magnet { get; set; }

        /// <summary>
        /// 文件列表
        /// </summary>
        public List<BTFile> file_list { get; set; }

    }

    [DataContract]
    public class BTFile
    {
        /// <summary>
        /// 文件类别
        /// </summary>
        public int file_type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string file_title { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public string file_size { get; set; }

        /// <summary>
        /// 文件图标
        /// </summary>
        public string file_icon { get; set; }

    }

}

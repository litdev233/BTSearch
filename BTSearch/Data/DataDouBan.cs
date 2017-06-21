using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace BTSearch.Data
{
    /// <summary>
    /// 豆瓣数据
    /// </summary>
    public class DataDouBan
    {
        public static async Task<Models.DouBan> GetWebData()
        {
            System.Diagnostics.Debug.WriteLine("加载豆瓣数据.....");
            string result = await Tools.WebHelper.HttpGet(UrlConfig.APIDouBan);
            if (string.IsNullOrWhiteSpace(result))
                return null;
            var serializer = new DataContractJsonSerializer(typeof(Models.DouBan));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Models.DouBan)serializer.ReadObject(ms);
            return data;
        }
    }
}

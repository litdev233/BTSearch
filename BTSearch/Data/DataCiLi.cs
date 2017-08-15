using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSearch.Data
{
    /// <summary>
    /// 磁力吧
    /// </summary>
    public class DataCiLi
    {
        /// <summary>
        /// 解析web数据
        /// </summary>
        public static async Task<Models.PageList<List<Models.BTInfo>>> GetData(string word, int page_index = 1)
        {
            try
            {
                Models.PageList<List<Models.BTInfo>> result_entity = new Models.PageList<List<Models.BTInfo>>();
                List<Models.BTInfo> data_list = new List<Models.BTInfo>();
                string url = string.Format(UrlConfig.APIBTCiLi, Uri.EscapeDataString(word), page_index);
                HtmlWeb webClient = new HtmlWeb();
                HtmlDocument doc = await webClient.LoadFromWebAsync(url);
                //var total_span = doc.DocumentNode.Descendants().Where(p => p.Name == "div" && p.Attributes["class"] != null && p.Attributes["class"].Value.Contains("result-stats")).ToList();
                //if (total_span.Count == 1)
                //    result_entity.total = Tools.TypeHelper.ObjectToInt(total_span[0].InnerText.Split(' ')[1], 0);
                //if (result_entity.total != 0)
                //{
                //    double page_size = 10;
                //    result_entity.max_page = (int)Math.Ceiling(result_entity.total / page_size);
                //}
                //else
                //    result_entity.max_page = 1;
                
                var bt_list = doc.DocumentNode.Descendants().Where(p => p.Name == "li").ToList().Skip(1);
                
                foreach (var item in bt_list)
                {
                    Models.BTInfo result = new Models.BTInfo();
                    result.title = item.ChildNodes[0].ChildNodes[0].InnerText;
                    var cili = item.ChildNodes[0].ChildNodes[0].Attributes["href"].Value.Replace("/btread/", "").Replace(".html", "").Trim();
                    //磁力链
                    result.magnet = "magnet:?xt=urn:btih:" + cili;

                    var other_info = item.ChildNodes[2].ChildNodes[1].ChildNodes[1].InnerText;

                    var other_arr = other_info.Split('\n');
                    //总大小
                    result.total_size = other_arr[0].Replace("大小:", "").Replace(" ", "").Trim();

                    //文件数量
                    result.file_num = Tools.TypeHelper.ObjectToInt(other_arr[1].Replace("文件数: ", "").Replace(" ", " ").Trim(), 0);//Tools.TypeHelper.ObjectToInt(item.ChildNodes[3].ChildNodes[5].InnerText, 0);
                    //时间
                    result.time = other_arr[2].Replace("创建日期: ","").Replace(" ","").Trim();//item.ChildNodes[3].ChildNodes[7].InnerText;
                    //热度
                    result.hot = Tools.TypeHelper.ObjectToInt(other_arr[3].Replace("热度: ","").Replace(" ","").Trim());//Tools.TypeHelper.ObjectToInt(item.ChildNodes[3].ChildNodes[9].InnerText, 1);
                    
                    result.file_list = new List<Models.BTFile>();
                    data_list.Add(result);
                }
                result_entity.data = data_list;
                result_entity.max_page = 1;
                result_entity.total = data_list.Count();
                return result_entity;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("解析磁力吧数据出现异常：" + ex.Message);
                return null;
            }
        }

    }
}

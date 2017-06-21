using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace BTSearch.Data
{
    /// <summary>
    /// btDB站的数据
    /// </summary>
    public class DataBTDB
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
                string url = string.Format(UrlConfig.APIBTDB, Uri.EscapeDataString(word), page_index);
                HtmlWeb webClient = new HtmlWeb();
                HtmlDocument doc = await webClient.LoadFromWebAsync(url);
                var total_span = doc.DocumentNode.Descendants().Where(p => p.Name == "div" && p.Attributes["class"] != null && p.Attributes["class"].Value.Contains("result-stats")).ToList();
                if (total_span.Count == 1)
                    result_entity.total = Tools.TypeHelper.ObjectToInt(total_span[0].InnerText.Split(' ')[1], 0);
                if (result_entity.total != 0)
                {
                    double page_size = 10;
                    result_entity.max_page = (int)Math.Ceiling(result_entity.total / page_size);
                }
                else
                    result_entity.max_page = 1;
                var bt_list = doc.DocumentNode.Descendants().Where(p => p.Name == "li" && p.Attributes["class"] != null && p.Attributes["class"].Value.Contains("search-ret-item")).ToList();
                foreach (var item in bt_list)
                {
                    Models.BTInfo result = new Models.BTInfo();
                    List<Models.BTFile> bt_file_list = new List<Models.BTFile>();
                    result.title = item.ChildNodes[1].ChildNodes[0].Attributes["title"].Value;
                    //文件数量
                    result.file_num = Tools.TypeHelper.ObjectToInt(item.ChildNodes[3].ChildNodes[5].InnerText, 0);
                    //总大小
                    result.total_size = item.ChildNodes[3].ChildNodes[3].InnerText;
                    //热度
                    result.hot = Tools.TypeHelper.ObjectToInt(item.ChildNodes[3].ChildNodes[9].InnerText, 1);
                    //时间
                    result.time = item.ChildNodes[3].ChildNodes[7].InnerText;
                    //磁力链
                    result.magnet = item.ChildNodes[3].ChildNodes[1].Attributes["href"].Value;

                    var file_list = item.ChildNodes[5].ChildNodes.Where(p => p.Name == "li" && p.Attributes["class"] != null && p.Attributes["class"].Value.Contains("file")).ToList();
                    foreach (var file in file_list)
                    {
                        Models.BTFile bt_file = new Models.BTFile();
                        bt_file.file_icon = "Assets/" + file.ChildNodes[1].ChildNodes[0].Attributes["class"].Value.Replace("fa ", "") + ".png";
                        bt_file.file_title = file.ChildNodes[3].InnerText.Replace("\n", "");
                        bt_file.file_size = file.ChildNodes[5].InnerText;
                        bt_file_list.Add(bt_file);
                    }
                    result.file_list = bt_file_list;
                    data_list.Add(result);
                }
                result_entity.data = data_list;
                return result_entity;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("解析BT酷站数据出现异常：" + ex.Message);
                return null;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace BTSearch.Tools
{
    public class WebHelper
    {
        /// <summary>
        /// HttpGet请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<string> HttpGet(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return "";
            var http = new HttpClient();
            try
            {
                var response = await http.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                http.Dispose();
            }
        }

    }
}

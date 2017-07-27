using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WebApiTestUtils
{
    /// <summary>
    /// http工具类
    /// </summary>
    public static class HttpUtils
    {
        public static string HttpGet(string url)
        {
            var client = new WebClient();
            try
            {
                var jsonStr = client.DownloadData(url);
                return Encoding.UTF8.GetString(jsonStr);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            
        }

        /// <summary>
        /// Post方式提交数据，返回网页的源代码
        /// </summary>
        /// <param name="url">发送请求的 URL</param>
        /// <param name="param">请求的参数集合</param>
        /// <returns>远程资源的响应结果</returns>
        public static string SendPost(string url, Dictionary<string, string> param)
        {
            var result = "";
            var postData = new StringBuilder();
            if (param != null && param.Count > 0)
            {
                foreach (var p in param)
                {
                    if (postData.Length > 0)
                    {
                        postData.Append("&");
                    }
                    postData.Append(p.Key);
                    postData.Append("=");
                    postData.Append(p.Value);
                }
            }
            var byteData = Encoding.GetEncoding("UTF-8").GetBytes(postData.ToString());
            try
            {

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Referer = url;
                request.Accept = "*/*";
                request.Timeout = 30 * 1000;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.Method = "POST";
                request.ContentLength = byteData.Length;
                var stream = request.GetRequestStream();
                stream.Write(byteData, 0, byteData.Length);
                stream.Flush();
                stream.Close();
                var response = (HttpWebResponse)request.GetResponse();
                var backStream = response.GetResponseStream();
                var sr = new StreamReader(backStream, Encoding.GetEncoding("UTF-8"));
                result = sr.ReadToEnd();
                sr.Close();
                backStream.Close();
                response.Close();
                request.Abort();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}

using System.Collections.Generic;
using WebApiTestModel.News;

namespace WebApiTestModel
{
    /// <summary>
    /// 聚合对应接口数据处理类
    /// </summary>
    public class RequestResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public string reason { get; set; }

        public JsonData result { get; set; }

        public string error_code { get; set; }
    }

    /// <summary>
    /// json数据
    /// </summary>
    public class JsonData
    {
        /// <summary>
        /// 数据集
        /// </summary>
        public List<NewsInfo> list { get; set; }

        public string totalPage { get; set; }

        public string ps { get; set; }

        public string pno { get; set; }
    }
}
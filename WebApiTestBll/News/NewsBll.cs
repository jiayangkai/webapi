using System.Collections.Generic;
using WebApiTestModel;
using WebApiTestModel.News;
using WebApiTestUtils;

namespace WebApiTestBll.News
{
    public class NewsBll
    {
        public List<NewsInfo> GetNews()
        {
            var jsonStr = HttpUtils.HttpGet("http://v.juhe.cn/weixin/query?key=" + ApiKeyUtils.NewsKey);
            var result = JsonUtils.JsonToObj<RequestResult>(jsonStr);
            var news = result.result.list;
            return news;
        }
    }
}

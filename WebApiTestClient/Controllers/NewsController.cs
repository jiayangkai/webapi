using System.Web.Http;
using WebApiTestBll.News;
using WebApiTestUtils;

namespace WebApiTestClient.Controllers
{
    /// <summary>
    /// 新闻控制类
    /// </summary>
    public class NewsController : ApiController
    {
        private readonly NewsBll _bll =new NewsBll();
        /// <summary>
        /// 获取最近新闻
        /// </summary>
        /// <returns></returns>
        public string GetLastNews()
        {
            var list = _bll.GetNews();
            var jsonStr = JsonUtils.ObjToJson(list);
            return jsonStr;
        }
    }
}

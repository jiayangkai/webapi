using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTestBll.express;
using WebApiTestModel.Express;

namespace WebApiTestClient.Controllers
{
    /// <summary>
    /// 快递
    /// </summary>
    public class ExpressController : ApiController
    {
        private readonly ExpressBll _bll = new ExpressBll();

        /// <summary>
        /// 识别快递单号
        /// </summary>
        /// <param name="expressNo">快递单号</param>
        /// <returns></returns>
        public List<ExpressInfo.Shipper> GetExpressByNo(string expressNo)
        {
            return _bll.OrderTracesSubByJson(expressNo);
        }
        /// <summary>
        /// 物流轨迹
        /// </summary>
        /// <param name="expressNo">快递单号</param>
        /// <param name="expressCode">快递编码</param>
        /// <returns></returns>
        public List<ExpressInfo.TracesData> GetExpressLineByNoAndCode(string expressNo, string expressCode)
        {
            return _bll.GetOrderTracesByJson(expressNo, expressCode);
        }
    }
}

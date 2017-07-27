using System.Collections.Generic;
using System.Text;
using System.Web;
using WebApiTestModel.Express;
using WebApiTestUtils;

namespace WebApiTestBll.express
{
    /// <summary>
    /// 快递业务
    /// </summary>
    public class ExpressBll
    {
        /// <summary>
        /// Json方式  单号识别
        /// </summary>
        /// <returns></returns>
        public List<ExpressInfo.Shipper> OrderTracesSubByJson(string expressNo)
        {
            var requestData = "{" + string.Format("'LogisticCode': '{0}'", expressNo) + "}";

            var param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", ApiKeyUtils.EBusinessID);
            param.Add("RequestType", "2002");
            var dataSign = EncryptUtils.encrypt(requestData, ApiKeyUtils.AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            var result = HttpUtils.SendPost(ApiKeyUtils.ReqURL, param);

            //根据公司业务处理返回的信息......
            var list = JsonUtils.JsonToObj<ExpressInfo.ShipperInfo>(result).Shippers;
            var resultlist = new List<ExpressInfo.Shipper>();
            //若识别出多家快递，则返回有物流轨迹的
            if (list.Count > 1)
            {
                foreach(var item in list)
                {
                    if (IsGetOrderTraces(expressNo, item.ShipperCode))
                    {
                        resultlist.Add(item);
                        break;
                    }
                }
            }
            else
            {
                resultlist.AddRange(list);
            }

            return resultlist;
        }

        /// <summary>
        /// Json方式 查询订单物流轨迹
        /// </summary>
        /// <param name="expressNo">快递单号</param>
        /// <param name="expressCode">快递编码</param>
        /// <returns></returns>
        public List<ExpressInfo.TracesData> GetOrderTracesByJson(string expressNo, string expressCode)
        {
            var requestData = "{" +
                              string.Format("'OrderCode':'','ShipperCode':'{0}','LogisticCode':'{1}'", expressCode,
                                  expressNo) + "}";

            var param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", ApiKeyUtils.EBusinessID);
            param.Add("RequestType", "1002");
            var dataSign = EncryptUtils.encrypt(requestData, ApiKeyUtils.AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            var result = HttpUtils.SendPost(ApiKeyUtils.ReqURL, param);

            //根据公司业务处理返回的信息......
            var expressInfo = JsonUtils.JsonToObj<ExpressInfo.ExpresssTraces>(result);
            expressInfo.Traces.Reverse();
            return expressInfo.Traces;
        }

        /// <summary>
        /// Json方式 查询订单物流轨迹
        /// </summary>
        /// <param name="expressNo">快递单号</param>
        /// <param name="expressCode">快递编码</param>
        /// <returns></returns>
        public bool IsGetOrderTraces(string expressNo, string expressCode)
        {
            var requestData = "{" +
                              string.Format("'OrderCode':'','ShipperCode':'{0}','LogisticCode':'{1}'", expressCode,
                                  expressNo) + "}";

            var param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", ApiKeyUtils.EBusinessID);
            param.Add("RequestType", "1002");
            var dataSign = EncryptUtils.encrypt(requestData, ApiKeyUtils.AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            var result = HttpUtils.SendPost(ApiKeyUtils.ReqURL, param);

            //根据公司业务处理返回的信息......
            var expressInfo = JsonUtils.JsonToObj<ExpressInfo.ExpresssTraces>(result);
            //站点轨迹不为空，则该快递编号对应有数据
            if (expressInfo!=null && expressInfo.State != "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

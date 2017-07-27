using System;
using System.Collections.Generic;

namespace WebApiTestModel.Express
{
    public class ExpressInfo
    {
        public class TracesData
        {
            /// <summary>
            /// 站点时间
            /// </summary>
            public DateTime AcceptTime { get; set; }
            /// <summary>
            /// 站点信息
            /// </summary>
            public string AcceptStation { get; set; }
        }

        public class ExpresssTraces
        {
            /// <summary>
            /// 电商ID
            /// </summary>
            public string EBusinessID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string OrderCode { get; set; }
            /// <summary>
            /// 快递编码
            /// </summary>
            public string ShipperCode { get; set; }
            /// <summary>
            /// 快递单号
            /// </summary>
            public string LogisticCode { get; set; }
            /// <summary>
            /// 状态
            /// </summary>
            public bool Success { get; set; }
            /// <summary>
            /// 快递状态
            /// </summary>
            public string State { get; set; }
            /// <summary>
            /// 站点轨迹
            /// </summary>
            public List<TracesData> Traces { get; set; }
        }
        /// <summary>
        /// 快递编码及名称
        /// </summary>
        public class Shipper
        {
            public string ShipperCode { get; set; }
            public string ShipperName { get; set; }
        }

        public class ShipperInfo
        {
            /// <summary>
            /// 电商ID
            /// </summary>
            public string EBusinessID { get; set; }
            /// <summary>
            /// 快递编码
            /// </summary>
            public string ShipperCode { get; set; }
            /// <summary>
            /// 快递单号
            /// </summary>
            public string LogisticCode { get; set; }
            /// <summary>
            /// 状态
            /// </summary>
            public bool Success { get; set; }
            /// <summary>
            /// 快递列表
            /// </summary>
            public List<Shipper> Shippers { get; set; }

        }

    }
}

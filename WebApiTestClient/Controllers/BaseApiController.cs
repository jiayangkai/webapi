using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTestClient.Authorize;

namespace WebApiTestClient.Controllers
{
    /// <summary>
    /// 基础类
    /// </summary>
    [RequestAuthorize]
    public class BaseApiController : ApiController
    {
    }
}

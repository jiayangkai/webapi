using System;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;
using WebApiTestBll.User;
using UrlHelper = System.Web.Mvc.UrlHelper;

namespace WebApiTestClient.Authorize
{
    /// <summary>
    /// 授权验证
    /// </summary>
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly UserBll _bll = new UserBll();
        /// <summary>
        /// 重写基类的验证方式，自定义Ticket验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var authorization = actionContext.Request.Headers.Authorization;
            if ((authorization != null) && (authorization.Parameter != null))
            {
                //解密用户ticket,并校验用户名密码是否匹配
                var encryptTicket = authorization.Parameter;
                if (ValidateTicket(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {

            }
            else
            {
                var challengeMessage = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
                throw new HttpResponseException(challengeMessage);
            }  
        }

        //校验用户名密码（正式环境中应该是数据库校验）
        private bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var formsAuthenticationTicket = FormsAuthentication.Decrypt(encryptTicket);
            if (formsAuthenticationTicket != null)
            {
                var strTicket = formsAuthenticationTicket.UserData;

                //从Ticket里面获取用户名和密码
                var index = strTicket.IndexOf("&", StringComparison.Ordinal);
                var strUser = strTicket.Substring(0, index);
                var strPwd = strTicket.Substring(index + 1);

                return _bll.ValidateUser(strUser, strPwd);
            }
            return false;
        }
    }
}
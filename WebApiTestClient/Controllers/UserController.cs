using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using WebApiTestBll.User;
using WebApiTestModel.User;

namespace WebApiTestClient.Controllers
{
    /// <summary>
    /// 用户信息控制器
    /// </summary>
    public class UserController : ApiController
    {
        private readonly UserBll _bll = new UserBll();
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="strUser"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        [HttpGet]
        public object Login(string strUser, string strPwd)
        {
            if (!_bll.ValidateUser(strUser, strPwd))
            {
                return new { bRes = false };
            }
            var ticket = new FormsAuthenticationTicket(0, strUser, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", strUser, strPwd),
                            FormsAuthentication.FormsCookiePath);
            //返回登录结果、用户信息、用户验证票据信息
            var oUser = new UserInfo{ Name = strUser, PassWord = strPwd, Ticket = FormsAuthentication.Encrypt(ticket) };
            //将身份信息保存在session中，验证当前请求是否是有效请求
            HttpContext.Current.Session[strUser] = oUser;
            return oUser;
        }

        

    }
}

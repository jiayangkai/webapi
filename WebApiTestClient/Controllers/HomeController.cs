using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiTestClient.Controllers
{
    /// <summary>
    /// 主页
    /// </summary>
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// 返回主界面
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="ticket">票据</param>
        /// <returns></returns>
        public ActionResult Index(string username,string ticket)
        {
            ViewBag.username = username;
            ViewBag.ticket = ticket;
            return View();
        }
    }
}
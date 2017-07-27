using WebApiTestDll;
using WebApiTestModel.User;
namespace WebApiTestBll.User
{
    public class UserBll
    {
        private readonly SqlConnectionDll _dll = new SqlConnectionDll();
        /// <summary>
        /// 校验用户名密码
        /// </summary>
        /// <param name="strUser">用户名</param>
        /// <param name="strPwd">密码</param>
        /// <returns>返回校验结果</returns>
        public bool ValidateUser(string strUser, string strPwd)
        {
            var sql =
                string.Format(
                    "SELECT u.`username`,u.`password` FROM bdm284884200_db.`User` AS u WHERE u.`username`='{0}' AND u.`password`='{1}'",
                    strUser, strPwd);
            return _dll.GetMySqlCommand(sql);
        }
    }
}

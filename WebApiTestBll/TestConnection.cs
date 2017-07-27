using WebApiTestDll;
using WebApiTestModel.User;

namespace WebApiTestBll
{
    public class TestConnection
    {
        private readonly SqlConnectionDll _dll = new SqlConnectionDll();

        public bool GetSqlCommand(string sql)
        {
           return _dll.GetMySqlCommand(sql);
        }

        public UserInfo GetUser(string sql)
        {
            return _dll.GetUser(sql);
        }
    }
}

using System;
using MySql.Data.MySqlClient;
using WebApiTestModel.User;
using WebApiTestUtils;

namespace WebApiTestDll
{
    public class SqlConnectionDll
    {
        /// <summary>
        /// 建立数据库连接
        /// </summary>
        /// <returns>返回mysqlconnection对象</returns>
        public MySqlConnection GetMySqlConnection()
        {
            var mySqlStr = ConfigUtils.GetConnectionByName("mysqlconnstring");
            //mySqlStr = "server=bdm284884200.my3w.com;user id=bdm284884200;password=jie19910219;database=bdm284884200_db";
            var connection = new MySqlConnection(mySqlStr);
            return connection;

        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sqlStr">要执行的语句</param>
        /// <returns>true,成功；反之失败</returns>
        public bool GetMySqlCommand(string sqlStr)
        {
            var connection = GetMySqlConnection();
            MySqlCommand command = null;
            object obj = null;
            try
            {
                connection.Open();
                command = new MySqlCommand(sqlStr, connection);
                obj = command.ExecuteScalar();
                return obj != null;
            }
            catch (Exception ex)
            {
                return obj != null;
            }
            finally
            {
                if (command != null) command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            
        }

        /// <summary>
        /// 执行sql语句返回reader
        /// </summary>
        /// <param name="sqlStr">要执行的语句</param>
        /// <returns>返回DataReader对象</returns>
        public MySqlDataReader GetMySqlDataReader(string sqlStr)
        {
            var connection= GetMySqlConnection();
            MySqlCommand command = null;
            try
            {
                connection.Open();
                command = new MySqlCommand(sqlStr, connection);
                return command.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (command != null) command.Dispose();
                connection.Close();
                connection.Dispose();
            }

        }

        public UserInfo GetUser(string sqlStr)
        {
            var connection = GetMySqlConnection();
            MySqlCommand command = null;
            MySqlDataReader reader = null;
            var user = new UserInfo();
            try
            {
                connection.Open();
                command = new MySqlCommand(sqlStr, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["id"].ToString());
                    user.Name = reader["username"].ToString();
                    user.PassWord = reader["password"].ToString();
                }
                return user;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (command != null) command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            
            
            
        }
    }
}

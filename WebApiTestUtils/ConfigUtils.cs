using System;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;

namespace WebApiTestUtils
{
    /// <summary>
    /// 配置文件操作
    /// </summary>
    public static class ConfigUtils
    {
        #region 辅助方法

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <returns></returns>
        private static Configuration GetConfigUtils()
        {
            bool isWebProj = FileUtils.FileExists(FileUtils.MapPath("~/web.config")); //如果根目录存在web.config，则认为是web项目
            return isWebProj
                ? (Configuration)WebConfigurationManager.OpenWebConfiguration("~")
                : ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        /// <summary>
        /// AppSettings中是否存在该配置
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>是否存在</returns>
        private static bool IsAppSettingsKeyExists(string key)
        {
            return ConfigurationManager.AppSettings.AllKeys.Any(str => str == key);
        }

        #endregion 辅助方法

        #region 读取AppSettings

        /// <summary>
        /// 获取需要的配置
        /// </summary>
        /// <param name="key">查询的Key</param>
        /// <param name="defaultVaule">默认值(可选)</param>
        /// <returns>读取失败时返回指定值</returns>
        /// <remarks>在web项目中，修改后立刻读取会失败，需要重新发送请求，因为此时的webConfig还没有刷新</remarks>
        public static string GetAppSettingsValue(string key, string defaultVaule = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException();
            }

            //var value = GetConfigUtils().AppSettings.Settings[key].Value; //这里会重新读取config而不是使用内存中的Config
            return ConfigurationManager.AppSettings[key] ?? defaultVaule;
        }

        #endregion 读取AppSettings

        #region 读取链接字符串

        /// <summary>
        /// 读取配置文件数据库链接字符串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }

            var result = ConfigurationManager.ConnectionStrings[name];

            return result == null ? null : result.ToString();
        }

        #endregion 读取链接字符串

        #region AppSettings增删改

        /// <summary>
        /// 修改AppSettings，如果不存在则添加，存在则更新
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void ModifyAppSettings(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException();
            }

            var config = GetConfigUtils();

            if (!IsAppSettingsKeyExists(key))
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 删除AppSettings,如果没有key,则不修改
        /// </summary>
        /// <param name="key"></param>
        public static void DeleteAppSettings(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException();
            }

            if (!IsAppSettingsKeyExists(key))
            {
                return;
            }

            var config = GetConfigUtils();
            config.AppSettings.Settings.Remove(key);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        #endregion AppSettings增删改
    }
}

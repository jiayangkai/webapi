using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace WebApiTestUtils
{
    public class FileUtils
    {
        /// <summary>
        /// 解析相对路径
        /// </summary>
        /// <param name="path">相对根目录的路径</param>
        /// <returns>物理路径</returns>
        public static string MapPath(string path)
        {
            if (Path.IsPathRooted(path))
            {
                return path;
            }

            if (HostingEnvironment.IsHosted)
            {
                return HostingEnvironment.MapPath(path);
            }

            if (!VirtualPathUtility.IsAppRelative(path))
            {
                throw new DirectoryNotFoundException("无法解析非根路径");
            }

            var physicalPath = VirtualPathUtility.ToAbsolute(path, "/");
            physicalPath = physicalPath.Replace('/', '\\');
            physicalPath = physicalPath.Substring(1);
            physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, physicalPath);

            return physicalPath;
        }

        /// <summary>
        /// 返回文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }
    }
}

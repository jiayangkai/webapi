using System.Linq;

namespace WebApiTestUtils
{
    /// <summary>
    /// 系统工具类
    /// </summary>
    public static class SystemUtils
    {
        /// <summary>
        /// 根据属性名获取属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="propertyname"></param>
        /// <returns></returns>
        public static object GetObjectPropertyValue<T>(T t, string propertyname)
        {
            var type = typeof(T);

            var property = type.GetProperty(propertyname);

            if (property == null) return string.Empty;

            var obj = property.GetValue(t, null);
            
            return obj;
        }
        /// <summary>
        /// 根据属性名设置对象的属性值，并返回该对象本身
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T SetTPropertyValueByName<T>(T t, string propertyName, string value)
        {
            var type = t.GetType();
            var property = type.GetProperties();
            foreach (var item in property.Where(item => item.Name == propertyName))
            {
                item.SetValue(t,value,null);
            }
            
            return t;
        }

    }
}

using System.Configuration;
using System.Reflection;

namespace STIM.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="WMS.SYS.OracleDAL" />。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["STIM_DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch(System.Exception ex)
            {
                //LogUtil.WriteLog(ex, "CreateObjectNoCache");
                return null;
            }

        }
   
        #endregion

        #region 接口

        /// <summary>
        /// 创建STIM_CONFIG数据层接口
        /// </summary>
        public static STIM.IDAL.ISTIM_CONFIG CreateSTIM_CONFIG()
        {
            string ClassNamespace = AssemblyPath + ".STIM_CONFIG";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (STIM.IDAL.ISTIM_CONFIG)objType;
        }
        #endregion
    }
}
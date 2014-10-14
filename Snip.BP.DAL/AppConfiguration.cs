using System;
using System.Configuration;
using System.Web.Configuration;

namespace Snip.BP.Dal
{
    /// <summary>
    /// La clase AppConfiguration contiene propiedades de solo lectura que son esencialmente atajos a configuraciones en el archivo web.config.
    /// </summary>
    public static class AppConfiguration
    {
        #region Propiedades Públicas

        public static string Database 
        { 
            get { return "SqlSNIP"; } 
        }
        public static string ConnectionSetting
        {
            get { return WebConfigurationManager.ConnectionStrings["SqlSNIP"].ToString(); }
        }

        /// <summary>Returns the connectionstring for the application.</summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
        }
        /// <summary>Returns the name of the current connectionstring for the application.</summary>
        public static string ConnectionStringName
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionStringName"];
            }
        }
        #endregion
    }
}

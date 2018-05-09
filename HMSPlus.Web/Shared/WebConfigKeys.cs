using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HMSPlus.Web.Shared
{
    public class WebConfigKeys
    {
        public static string IsProduction = WebConfigurationManager.AppSettings["IsProduction"];

        public static string AdminEmail = WebConfigurationManager.AppSettings["AdminEmail"];

        public static string SiteUrl = WebConfigurationManager.AppSettings["SiteUrl"];

        public static string GetConfigValueByKey(string key)
        {

            return WebConfigurationManager.AppSettings[key];
        }
    }
}
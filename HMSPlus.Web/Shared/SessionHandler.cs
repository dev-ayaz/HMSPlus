using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSPlus.Web.Shared
{
    public class SessionHandler
    {
        public static long? UserId
        {
            get
            {
                if (HttpContext.Current.Session[SessionKeys.UserId] != null)
                {
                    return Convert.ToInt64(HttpContext.Current.Session[SessionKeys.UserId]);

                }

                return null;
            }
            set => HttpContext.Current.Session[SessionKeys.UserId] = value;
        }

        public static string RolePermissions
        {
            get => HttpContext.Current.Session[SessionKeys.UserRolePermissions]?.ToString() ?? string.Empty;
            set => HttpContext.Current.Session[SessionKeys.UserRolePermissions] = value;
        }

        public static string CultureCode
        {
            get => HttpContext.Current.Session[SessionKeys.CultureCode]?.ToString() ?? @"en-US";
            set => HttpContext.Current.Session[SessionKeys.CultureCode] = value;
        }
    }
}
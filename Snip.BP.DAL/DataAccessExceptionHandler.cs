using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Snip.BP.Dal
{
    public class DataAccessExceptionHandler
    {
        public static void HandleException(string msg)
        {
            string errorUrl = "~/Error/Error.aspx";
            HttpContext.Current.Session.Add("ErrorMsg", msg);
            HttpContext.Current.Response.Redirect(errorUrl);
        }
    }
}

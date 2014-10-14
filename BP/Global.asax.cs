using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using Snip.BP.Bll.App;

namespace BP
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Application.Add("CodAplicacion", 1);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string anioEjer = AplicacionManager.ParametroGetValueById("ANIO_EJER");

            if (anioEjer != null)
            {
                Session.Add("AnioPIP", anioEjer);
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
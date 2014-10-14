using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BP.Bpm
{
    public partial class ProyectoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/Default.aspx";
            Response.Redirect(url);
        }
    }
}
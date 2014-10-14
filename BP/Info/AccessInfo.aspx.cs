using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.Enums;
using Snip.BP.BO.Enums;

namespace BP.Info
{
    public partial class AccessInfo : System.Web.UI.Page
    {
        private int anio = DateTime.Today.Year;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AnioPIP"] != null)
                {
                    anio = Convert.ToInt32(Session["AnioPIP"]);
                }

                Master.HideMenuAll();
                Master.SetMenuVisible(MenuIndex.Inicio, true);
                Master.Anio = anio;
                Master.SetParametersMenu();

                this.ViewState.Add("PIP", this.anio);

            }
        }
        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/bps/LicitacionList.aspx";
            Response.Redirect(url);
        }
    }
}
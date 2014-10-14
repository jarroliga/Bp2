using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.Enums;
using Snip.BP.BO;

namespace BP.Info
{
    public partial class RegisterInfo : System.Web.UI.Page
    {
        private int anio = DateTime.Today.Year;
        private int codLicitacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.HideMenuAll();
                Master.SetMenuVisible(MenuIndex.Inicio, true);
                Master.SetMenuVisible(MenuIndex.Licitaciones, true);
                Master.SetMenuVisible(MenuIndex.Licitacion, true);

                if (Int32.TryParse(Request.QueryString["IdLic"], out codLicitacion))
                {
                    if (Session["AnioPIP"] != null)
                    {
                        anio = Convert.ToInt32(Session["AnioPIP"]);
                    }

                    Master.Anio = anio;
                    Master.CodLicitacion = codLicitacion;
                    Master.SetParametersMenu();

                    this.ViewState.Add("PIP", this.anio);
                    this.ViewState.Add("CodLicitacion", this.codLicitacion);
                }
            }
        }
        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/bps/LicitacionEtapaCronogramaList.aspx?IdLic=" + this.ViewState["CodLicitacion"].ToString();
            Response.Redirect(url);
        }
    }
}
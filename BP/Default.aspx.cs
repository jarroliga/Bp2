using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.BP.BO.Bp;
using Snip.BP.Bll.Bp;
using Snip.BP.Bll.Bps;
using Snip.Enums;

namespace BP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Master.HideMenuAll();
                Master.SetMenuVisible(MenuIndex.Inicio, true);

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //Master.SetMenuVisible(MenuIndex.Licitaciones, true);
                    //Master.SetMenuVisible(MenuIndex.Seguridad, true);
                    //this.rptListaPip.DataSource = ListaPipManager.GetList();
                    //this.rptListaPip.DataBind();

                    int codUsuario = -1;
                    int anio = DateTime.Today.Year;
                    string idPerfil = string.Empty;

                    if (Session["CodUsuario"] != null)
                    {
                        codUsuario = Convert.ToInt32(Session["CodUsuario"]);
                    }
                    if (Session["AnioPIP"] != null)
                    {
                        anio = Convert.ToInt32(Session["AnioPIP"]);
                    }
                    if (Session["IdPerfil"] != null)
                    {
                        idPerfil = Session["IdPerfil"].ToString();
                    }

                    if (idPerfil == "BPS_ADMIN")
                    {
                        Master.SetMenuVisible(MenuIndex.Administracion, true);
                        Master.SetMenuVisible(MenuIndex.Seguridad, true);
                    }

                    //int alertasReprogramacion = 0;
                    //int alertasEstado = AlertaManager.AlertaEstadoGetTotalEvents(anio, codUsuario);
                    //int alertasEtapa = AlertaManager.AlertaEtapaGetTotalEvents(anio, codUsuario);

                    //if (idPerfil == "BPS_USIP")
                    //{
                    //    alertasReprogramacion = AlertaManager.AlertaReprogramacionGetTotalEvents(anio, codUsuario, 16);
                    //}
                    //else if (idPerfil == "BPS_DIRSEG" || idPerfil == "BPS_ESPSEG")
                    //{
                    //    alertasReprogramacion = AlertaManager.AlertaReprogramacionGetTotalEvents(anio, codUsuario, 17);
                    //}
                    //else if (idPerfil == "BPS_ADMIN")
                    //{
                    //    alertasReprogramacion = AlertaManager.AlertaReprogramacionGetTotalEvents(anio, codUsuario);
                    //}
                    //else
                    //{
                    //    alertasReprogramacion = 0;
                    //}

                    //if (alertasEstado == 0)
                    //{
                    //    this.hlkAlertaReg.Visible = false;
                    //    this.imgAlerta1.Visible = false;
                    //}
                    //else
                    //{
                    //    this.hlkAlertaReg.Text = "Tiene " + alertasEstado.ToString() + " evento(s) de alertas de registro pendientes de revisar.";
                    //}
                    //if (alertasEtapa == 0)
                    //{
                    //    this.hlkAlertaEta.Visible = false;
                    //    this.imgAlerta2.Visible = false;
                    //}
                    //else
                    //{
                    //    this.hlkAlertaEta.Text = "Tiene " + alertasEtapa.ToString() + " evento(s) de alertas de etapas con fecha vencida pendientes de revisar.";
                    //}
                    //if (alertasReprogramacion == 0)
                    //{
                    //    this.hlkAlertaRpg.Visible = false;
                    //    this.imgAlerta3.Visible = false;
                    //}
                    //else
                    //{
                    //    this.hlkAlertaRpg.Text = "Tiene " + alertasReprogramacion.ToString() + " evento(s) de alertas de solicitudes de reprogramacion.";
                    //}

                }
                else
                {
                    //Master.SetMenuVisible(MenuIndex.Licitaciones, false);
                    this.hlkAlertaReg.Visible = false;
                    this.hlkAlertaEta.Visible = false;
                    this.hlkAlertaRpg.Visible = false;
                }
            }
        }
    }
}
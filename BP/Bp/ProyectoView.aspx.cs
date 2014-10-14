using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.BP.BO.Bp;
using Snip.BP.Bll.Bp;
using Snip.Enums;

namespace BP.Bp
{
    public partial class ProyectoView : System.Web.UI.Page
    {
        private int anio = 0;
        private int codProy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AnioPIP"] != null)
                {
                    this.anio = Convert.ToInt32(Session["AnioPIP"]);
                }

                if (Int32.TryParse(Request.QueryString["IdProy"], out codProy) && this.anio > 0)
                {
                    Master.HideMenuAll();
                    Master.SetMenuVisible(MenuIndex.Inicio, true);
                    Master.SetMenuVisible(MenuIndex.Proyecto, true);
                    Master.Anio = this.anio;
                    Master.CodProyecto = this.codProy;
                    Master.SetParametersMenu();

                    this.ViewState.Add("CodProy", this.codProy);
                    this.ViewState.Add("PIP", this.anio);

                    Proyecto_Load(this.codProy, this.anio);
                }
            }
        }
        private void Proyecto_Load(int codProy, int anio)
        {
            Proyecto proyecto = new Proyecto();
            proyecto = ProyectoManager.GetItem(codProy, true);

            this.lblCodSnip.Text = proyecto.CodSnip;
            this.lblNombre.Text = proyecto.Nombre;
            this.lblEtapa.Text = proyecto.Etapa.Nombre;
            this.lblInstitucion.Text = proyecto.UnidadEjecutora.Institucion.Nombre + " / " + proyecto.UnidadEjecutora.Nombre;
            this.lblSector.Text = proyecto.Sector.SectorPadre.Nombre + " / " + proyecto.Sector.Nombre;
            this.lblFechaIniPrev.Text = proyecto.FechaInicioPrevista.Value.ToShortDateString();
            this.lblFechaFinPrev.Text = proyecto.FechaFinPrevista.Value.ToShortDateString();
            this.lblFechaIniReal.Text = proyecto.FechaInicioReal.Value.ToShortDateString();
            this.lblFechaFinReal.Text = proyecto.FechaFinReal.Value.ToShortDateString();

            this.lblDescripcion.Text = proyecto.ProyectoFicha.Descripcion;
            this.lblObjetivosDesarrollo.Text = proyecto.ProyectoFicha.ObjetivosDesarrollo;
            this.lblObjetivosEspecificos.Text = proyecto.ProyectoFicha.ObjetivosEspecificos;
            this.lblJustificacion.Text = proyecto.ProyectoFicha.Justificacion;
            this.lblAspectosOperativos.Text = proyecto.ProyectoFicha.AspectosOperativos;
            this.lblBeneficios.Text = proyecto.ProyectoFicha.Beneficios;
        }
        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/bp/ProyectoList.aspx?";
            url += "anio=" + this.ViewState["PIP"].ToString();
            Response.Redirect(url);
        }
    }
}
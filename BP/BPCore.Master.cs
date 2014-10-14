using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.Enums;

namespace BP
{
    public partial class BPCore : System.Web.UI.MasterPage
    {
        // Atributos utilizados para el control de parámetros de navegación
        public int Anio { get; set; }
        public int CodProyecto { get; set; }
        public int CodObra { get; set; }
        public int CodLicitacion { get; set; }
        public int CodContrato { get; set; }
        public int CodSolicitud { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                this.litUsuario.Text = HttpContext.Current.User.Identity.Name;
                this.hlkLogin.Visible = false;
                this.hlkLogout.Visible = true;
                this.hlkChangePass.Visible = true;
            }
            else
            {
                this.litUsuario.Text = "Invitado";
                HideMenuAll();
            }
        }
        public void HideMessage()
        {
            this.litMsj.Text = string.Empty;
            this.pnlMsj.Visible = false;
        }
        public void HideMenuAll()
        {
            // Preinversión
            this.mnu1001.Visible = false;
            this.mnu1010.Visible = false;
            this.mnu1020.Visible = false;
            this.mnu1030.Visible = false;
            this.mnu1040.Visible = false;

            // Banco Proyectos
            this.mnu2001.Visible = true;
            this.mnu2010.Visible = false;

            // Seguimiento
            this.mnu4001.Visible = false;
            this.mnu4010.Visible = false;
            this.mnu4020.Visible = false;
            this.mnu4030.Visible = false;

            // Gestión Municipal
            this.mnu5001.Visible = false;
            this.mnu5010.Visible = false;
            this.mnu5020.Visible = false;
            
            this.mnu9001.Visible = false;
            this.mnu8001.Visible = false;

        }
        public void SetMenuVisible(MenuIndex menuIndex, bool visible)
        {
            switch (menuIndex)
            {
                case MenuIndex.Inicio:
                    this.mnu0001.Visible = visible;
                    break;
                case MenuIndex.Preinversion:
                    this.mnu1001.Visible = visible;
                    break;
                case MenuIndex.Iniciativas:
                    this.mnu1010.Visible = visible;
                    break;
                case MenuIndex.ProgramaPi:
                    this.mnu1020.Visible = visible;
                    break;
                case MenuIndex.ComponentePi:
                    this.mnu1030.Visible = visible;
                    break;
                case MenuIndex.ProyectoPi:
                    this.mnu1040.Visible = visible;
                    break;
                case MenuIndex.Proyecto:
                    this.mnu2001.Visible = visible;
                    break;
                case MenuIndex.Obra:
                    this.mnu2010.Visible = visible;
                    break;
                case MenuIndex.Licitaciones:
                    this.mnu4001.Visible = visible;
                    break;
                case MenuIndex.Licitacion:
                    this.mnu4010.Visible = visible;
                    break;
                case MenuIndex.Contratos:
                    this.mnu4020.Visible = visible;
                    break;
                case MenuIndex.Contrato:
                    this.mnu4030.Visible = visible;
                    break;
                case MenuIndex.GestionMunicipal:
                    this.mnu5001.Visible = visible;
                    break;
                case MenuIndex.Evaluacion:
                    this.mnu5010.Visible = visible;
                    break;
                case MenuIndex.ConfiguracionBpm:
                    this.mnu5020.Visible = visible;
                    break;
                case MenuIndex.Seguridad:
                    this.mnu9001.Visible = visible;
                    break;
                case MenuIndex.Administracion:
                    this.mnu8001.Visible = visible;
                    break;
                case MenuIndex.Reportes:
                    this.mnu6001.Visible = visible;
                    break;
                default:
                    this.mnu0001.Visible = visible;
                    break;
            }
        }
        public void SetParametersMenu()
        {
            string parametrosUrlProy = "?IdProy=" + CodProyecto.ToString();

            this.hlkProyectoView.NavigateUrl += parametrosUrlProy;
            this.hlkObraList.NavigateUrl += parametrosUrlProy;
            //this.hlkGastoRecurrente.NavigateUrl += parametrosUrlProy;

            string parametrosUrlObra = "&IdObra=" + CodObra.ToString();

            this.hlkObraView.NavigateUrl += parametrosUrlProy + parametrosUrlObra;
            this.hlkContratoList.NavigateUrl += parametrosUrlProy + parametrosUrlObra;

            string parametrosUrlLicitacion = "?IdLic=" + this.CodLicitacion.ToString();

            this.hlkLicitacionEdit.NavigateUrl += parametrosUrlLicitacion;
            this.hlkLicitacionObraList.NavigateUrl += parametrosUrlLicitacion;
            this.hlkCronogramaList.NavigateUrl += parametrosUrlLicitacion;
            this.hlkLicitacionEtapa.NavigateUrl += parametrosUrlLicitacion;
            this.hlkLicitacionBitacoraList.NavigateUrl += parametrosUrlLicitacion;
            this.hlkLicitacionReprogramacion.NavigateUrl += parametrosUrlLicitacion;
            this.hlkLicitacionAjusteFinanciero.NavigateUrl += parametrosUrlLicitacion;
            this.hlkLicitacionCancel.NavigateUrl += parametrosUrlLicitacion;
            this.hlkLicitacionDeserted.NavigateUrl += parametrosUrlLicitacion;

        }
        public void ShowMessage(string msg, MessageType msgType)
        {
            this.pnlMsj.BackColor = System.Drawing.Color.FromArgb(226, 236, 255);
            this.pnlMsj.BorderStyle = BorderStyle.Solid;
            this.pnlMsj.BorderWidth = 1;

            switch (msgType)
            {
                case MessageType.Info:
                    this.pnlMsj.BackColor = System.Drawing.Color.FromArgb(226, 236, 255);
                    this.pnlMsj.BorderColor = System.Drawing.Color.FromArgb(135, 182, 217);
                    this.pnlMsj.ForeColor = System.Drawing.Color.DarkBlue;
                    break;
                case MessageType.Error:
                    this.pnlMsj.BackColor = System.Drawing.Color.FromArgb(252, 252, 198);
                    this.pnlMsj.BorderColor = System.Drawing.Color.FromArgb(225, 207, 133);
                    this.pnlMsj.ForeColor = System.Drawing.Color.Firebrick;
                    break;
                case MessageType.Alert:
                    this.pnlMsj.BackColor = System.Drawing.Color.FromArgb(252, 252, 198);
                    this.pnlMsj.BorderColor = System.Drawing.Color.FromArgb(225, 207, 133);
                    this.pnlMsj.ForeColor = System.Drawing.Color.DarkGoldenrod;
                    break;
                case MessageType.Tips:
                    this.pnlMsj.BackColor = System.Drawing.Color.FromArgb(226, 236, 255);
                    this.pnlMsj.BorderColor = System.Drawing.Color.FromArgb(135, 182, 217);
                    this.pnlMsj.ForeColor = System.Drawing.Color.DarkBlue;
                    break;
                case MessageType.Ayuda:
                    this.pnlMsj.BackColor = System.Drawing.Color.FromArgb(226, 236, 255);
                    this.pnlMsj.BorderColor = System.Drawing.Color.FromArgb(135, 182, 217);
                    this.pnlMsj.ForeColor = System.Drawing.Color.DarkBlue;
                    break;
            }
            this.litMsj.Text = msg;
            this.pnlMsj.Visible = true;
        }
    }
}
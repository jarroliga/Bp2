using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

using Snip.Enums;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;
using Snip.BP.Bll.App;
using Snip.BP.Bll.Bp;

namespace BP.App
{
    public partial class UsuarioEdit : System.Web.UI.Page
    {
        private int codUsuario = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.HideMenuAll();
                Master.SetMenuVisible(MenuIndex.Inicio, true);
                Master.SetMenuVisible(MenuIndex.Administracion, true);

                if (Int32.TryParse(Request.QueryString["IdUsr"], out codUsuario))
                {
                    Master.SetParametersMenu();

                    this.ViewState.Add("CodUsuario", this.codUsuario);

                    Usuario usuario = new Usuario();
                    usuario = UsuarioManager.GetItem(codUsuario);

                    if (usuario != null)
                    {
                        LoadFormControlsFromUsuario(usuario);
                    }
                }
            }
        }

        #region Cargar y Guardar Datos

        private void LoadFormControlsFromUsuario(Usuario usuario)
        {
            this.txtLogin.Text = usuario.Login;
            this.txtApellido.Text = usuario.Apellido;
            this.txtNombre.Text = usuario.Nombre;
            this.chkEsInterno.Checked = usuario.EsInterno;
            this.chkHabilitado.Checked = usuario.Habilitado;
            this.txtUltimoAcceso.Text = usuario.FechaUltimoAcceso == null ? string.Empty : usuario.FechaUltimoAcceso.Value.ToShortDateString();

            this.ViewState.Add("Pass", usuario.Password);
            this.ViewState.Add("Salt", usuario.Salt);

            LoadInstitucionList();

            if (!usuario.EsInterno)
            {
                this.ddlInstitucion.SelectedValue = usuario.Institucion.Codigo.ToString();
            }
            else
            {    
                this.ddlInstitucion.Enabled = false;
            }

        }
        private void LoadUsuarioFromFormControls(Usuario usuario)
        {
            IFormatProvider culture = new CultureInfo("es-NI", true);

            usuario.Codigo = Convert.ToInt32(this.ViewState["CodUsuario"]);
            usuario.Nombre = this.txtNombre.Text;
            usuario.Apellido = this.txtApellido.Text;
            usuario.Email = this.txtEmail.Text;
            usuario.EsInterno = this.chkEsInterno.Checked;
            usuario.Habilitado = this.chkHabilitado.Checked;
            usuario.Institucion.Codigo = Convert.ToInt32(this.ddlInstitucion.SelectedValue);
            usuario.Login = this.txtLogin.Text;

            usuario.Password = this.ViewState["Pass"].ToString();
            usuario.Salt = this.ViewState["Salt"].ToString();

            if (Session["CodUsuario"] != null)
            {
                usuario.CodUsuarioActualizacion = Convert.ToInt32(Session["CodUsuario"]);
            }
            else
            {
                EndEditing();
            }

        }
        private void LoadInstitucionList()
        {
            InstitucionCollection instituciones = new InstitucionCollection();
            instituciones = InstitucionManager.GetListAll();
            this.ddlInstitucion.DataSource = instituciones;
            this.ddlInstitucion.DataValueField = "Codigo";
            this.ddlInstitucion.DataTextField = "Nombre";
            this.ddlInstitucion.DataBind();

            this.ddlInstitucion.SelectedIndex = -1;
        }
        private void SaveEditing()
        {
            int codigo = -1;

            Page.Validate();

            if (Page.IsValid)
            {
                Usuario usuario = new Usuario();
                LoadUsuarioFromFormControls(usuario);
                
                try
                {
                    codigo = UsuarioManager.Save(usuario);
                    EndEditing();
                }
                catch (DBConcurrencyException)
                {
                    Master.ShowMessage("No se ha podido guarda el registro en la base de datos.", MessageType.Error);
                }
            }
            else
            {
                Snip.BP.Validation.BrokenRulesCollection brokenRules = new Snip.BP.Validation.BrokenRulesCollection();
                brokenRules.Add("Debe registrar la fecha de firma");
                eList.BrokenRules = brokenRules;
                eList.Visible = true;
            }
            if (codigo != -1)
            {
                Master.ShowMessage("No se ha podido guarda el registro en la base de datos.", MessageType.Error);
            }
        }
        #endregion

        #region Métodos Auxiliares

        protected void EndEditing()
        {
            string url = "~/App/UsuarioList.aspx";
            Response.Redirect(url);
        }
        protected void BtnRegresarClick(object sender, ImageClickEventArgs e)
        {
            EndEditing();
        }
        protected void BtnSalvarClick(object sender, ImageClickEventArgs e)
        {
            SaveEditing();
        }

        #endregion

    }
}
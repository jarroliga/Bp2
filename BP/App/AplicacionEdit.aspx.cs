using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.BP.BO.App;
using Snip.BP.Bll.App;
using Snip.Enums;

namespace BP.App
{
    public partial class AplicacionEdit : System.Web.UI.Page
    {
        private int codAplicacion = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.HideMenuAll();
                Master.SetMenuVisible(MenuIndex.Inicio, true);
                Master.SetMenuVisible(MenuIndex.Administracion, true);

                if (Int32.TryParse(Request.QueryString["idAplicacion"], out codAplicacion))
                {
                    this.ViewState.Add("CodAplicacion", codAplicacion);
                    Load_Aplicacion(codAplicacion);
                }
            }
        }
        protected void Load_Aplicacion(int codAplicacion)
        {
            Aplicacion aplicacion = new Aplicacion();

            aplicacion = AplicacionManager.GetItem(codAplicacion);

            this.txtCodigo.Text = aplicacion.Codigo.ToString();
            this.txtId.Text = aplicacion.IdAplicacion.ToString();
            this.txtNombre.Text = aplicacion.Nombre;

        }
        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                Aplicacion oAplicacion = new Aplicacion();

                oAplicacion.Codigo = Convert.ToInt32(this.ViewState["CodAplicacion"]);
                oAplicacion.IdAplicacion = this.txtId.Text;
                oAplicacion.Nombre = this.txtNombre.Text;

                int codigo = AplicacionManager.Save(oAplicacion);

                if (codigo == -1)
                {
                    Master.ShowMessage("El registro no pudo ser almacenado en la base de datos.", Snip.Enums.MessageType.Error);
                }
                else
                {
                    EndEditing();
                }
            }
        }
        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            EndEditing();
        }
        private void EndEditing()
        {
            Response.Redirect("~/App/AplicacionList.aspx");
        }
    }
}
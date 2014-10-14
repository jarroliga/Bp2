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
    public partial class AplicacionNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Master.SetMenuActivo(MenuIndex.Administracion);
            }
        }
        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                Aplicacion oAplicacion = new Aplicacion();

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
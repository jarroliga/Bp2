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
    public partial class AplicacionList : System.Web.UI.Page
    {
        #region Eventos de la Pagina

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.HideMenuAll();
                Master.SetMenuVisible(MenuIndex.Inicio, true);
                Master.SetMenuVisible(MenuIndex.Administracion, true);

                this.grdList.DataKeyNames = new string[] { "Codigo" };
                //Master.SetMenuActivo(MenuIndex.Administracion);

                grdList_Load();
            }
        }
        #endregion

        #region Configuracion del GridView Principal

        private void grdList_Load()
        {
            this.grdList.DataSource = AplicacionManager.GetList();
            this.grdList.DataBind();

        }
        protected void grdList_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton edit = (ImageButton)e.Row.Cells[0].FindControl("imgEdit");
                edit.CommandArgument = e.Row.RowIndex.ToString();

                ImageButton delete = (ImageButton)e.Row.Cells[1].FindControl("imgDelete");
                delete.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
        protected void grdList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string url = "#";

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = this.grdList.Rows[index];
                grdList.SelectedIndex = index;

                url = "~/App/AplicacionEdit.aspx?IdAplicacion=" + this.grdList.SelectedDataKey["Codigo"].ToString();

                Response.Redirect(url);
            }
            if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = this.grdList.Rows[index];
                grdList.SelectedIndex = index;

                url = "~/App/AplicacionList.aspx";

                Aplicacion aplicacion = new Aplicacion();
                aplicacion.Codigo = Convert.ToInt32(this.grdList.SelectedDataKey["Codigo"]);

                bool deleted_ok = AplicacionManager.Delete(aplicacion);

                if (!deleted_ok)
                {
                    Master.ShowMessage("El registro no pudo ser eliminado!!", Snip.Enums.MessageType.Alert);
                }
                else
                {
                    Response.Redirect(url);
                }
            }
        }
        #endregion

        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/Default.aspx";
            Response.Redirect(url);
        }
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/App/AplicacionNew.aspx");
        }
    }
}
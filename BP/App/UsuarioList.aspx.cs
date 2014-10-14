using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.Enums;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;
using Snip.BP.Bll.App;
using Snip.BP.Bll.Bp;

namespace BP.App
{
    public partial class UsuarioList : System.Web.UI.Page
    {
        private string searchValue = string.Empty; // Sin filtrar
        private string sortExpression = "Apellido"; // Criterio de ordenamiento inicial
        private SortDirection sortDirection = SortDirection.Ascending;

        static readonly string USR_SEARCH_VALUE = "UserSearchValue";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.HideMenuAll();
                Master.SetMenuVisible(MenuIndex.Inicio, true);
                Master.SetMenuVisible(MenuIndex.Administracion, true);

                this.grdList.DataKeyNames = new string[] { "Codigo" };

                InstitucionLoad();

                if (Session[USR_SEARCH_VALUE] != null)
                    searchValue = Session[USR_SEARCH_VALUE].ToString();
                else
                    Session.Add(USR_SEARCH_VALUE, searchValue);

                // Actualiza el tamaño de página al seleccionado por el usuario
                this.grdList.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                // Almacena en variable de estado los valores iniciales de filtrado, paginación y ordenamiento
                this.ViewState.Add("SearchValue", searchValue);
                this.ViewState.Add("SortField", this.sortExpression);
                this.ViewState.Add("SortDirection", this.sortDirection);

                GrdListLoad();
            }
        }

        private void InstitucionLoad()
        {
            this.ddlInstitucion.DataSource = InstitucionManager.GetListAll();
            this.ddlInstitucion.DataTextField = "Nombre";
            this.ddlInstitucion.DataValueField = "Codigo";
            this.ddlInstitucion.DataBind();

            this.ddlInstitucion.Items.Insert(0, new ListItem("<Todas las Instituciones>", "-1"));

            this.ddlInstitucion.SelectedIndex = 0;

        }
        protected void InstitucionSelectedIndexChanged(object sender, EventArgs e)
        {
            GrdListLoad();
        }

        #region Manejadores de eventos del grid

        private void GrdListLoad()
        {
            // Recupera las variables de sesion con los filtros y parametros para la carga de los datos
            string currentSearchValue = this.Session[USR_SEARCH_VALUE].ToString();

            string currentSortField = this.ViewState["SortField"].ToString();
            SortDirection currentSortDirection = (SortDirection)this.ViewState["SortDirection"];

            int currentPageIndex = this.grdList.PageIndex;
            int currentPageSize = this.ddlPageSize.SelectedValue == "0" ? 0 : this.grdList.PageSize;

            int currentMaxPageIndex = Convert.ToInt32(this.ViewState["MaxPageIndex"]);

            bool sortDirection = currentSortDirection == SortDirection.Ascending ? true : false;

            int codInstitucion = Convert.ToInt32(this.ddlInstitucion.SelectedValue);

            string idPerfil = null;
            int codUsuario = -1;

            if (Session["CodUsuario"] != null)
            {
                idPerfil = Session["IdPerfil"].ToString();
                codUsuario = Convert.ToInt32(Session["CodUsuario"]);
            }

            string filterCriteria = string.Empty;
            string filterValue = string.Empty;

            // Recupera los datos de acuerdo a los parametros especificados, retornando el número de registros.
            int totalRecords = 0;
            this.grdList.DataSource = UsuarioManager.GetListPaged(codInstitucion, currentPageIndex, currentPageSize, currentSortField, sortDirection, currentSearchValue, filterCriteria, filterValue, ref totalRecords);
            this.grdList.DataBind();

            // Actualiza el máximo número de páginas disponibles de acuerdo al nuevo tamaño de página.
            currentMaxPageIndex = CalculatePages(totalRecords) - 1;
            this.ViewState.Add("MaxPageIndex", currentMaxPageIndex);
            this.ViewState.Add("TotalRecords", totalRecords);

            // Actualiza la barra de navegación con los valores de página actual y de total de páginas.
            this.txtPageNumber.Text = (currentPageIndex + 1).ToString();
            this.lblMaxPageNumber.Text = (currentMaxPageIndex + 1).ToString();

            this.lblTotalRegistros.Text = "  Total: " + totalRecords.ToString("#,###") + " registros";

            EnableDisableNavigation(currentMaxPageIndex);
            upGrd.Update();

        }
        protected void GrdListRowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton edit = (ImageButton)e.Row.Cells[0].FindControl("imgEdit");
                edit.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
        protected void GrdListRowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string url = "#";

            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = this.grdList.Rows[index];
                grdList.SelectedIndex = index;

                url = "~/App/UsuarioEdit.aspx?IdUsr=" + this.grdList.SelectedDataKey["Codigo"].ToString();

                Response.Redirect(url);
            }

        }
        private int CalculatePages(int totalRecords)
        {
            double currentPageSize = Convert.ToDouble(this.grdList.PageSize);
            int totalPages = 1;

            if (currentPageSize != 0)
                totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalRecords) / currentPageSize));

            return totalPages;
        }
        private void EnableDisableNavigation(int maxPageIndex)
        {
            if (maxPageIndex == 0)
            {
                this.btnFirst.Enabled = false;
                this.btnPrev.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.txtPageNumber.Enabled = false;
            }
            else
            {
                this.btnFirst.Enabled = true;
                this.btnPrev.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
                this.txtPageNumber.Enabled = true;
            }
        }
        protected void GrdListSorted(Object source, GridViewSortEventArgs e)
        {
            string currentSortField = this.ViewState["SortField"].ToString();
            SortDirection currentSortDirection = (SortDirection)this.ViewState["SortDirection"];

            if (currentSortField != string.Empty)
            {
                if (String.Compare(e.SortExpression, currentSortField, true) == 0)
                {
                    currentSortDirection = (currentSortDirection == SortDirection.Ascending) ? SortDirection.Descending : SortDirection.Ascending;
                }
                else
                {
                    currentSortDirection = SortDirection.Ascending;
                }
            }
            currentSortField = e.SortExpression;

            ViewState["SortDirection"] = currentSortDirection;
            ViewState["SortField"] = currentSortField;

            GrdListLoad();

        }
        protected void GrdListPageIndexChanged(object sender, CommandEventArgs e)
        {
            int pageNumber = int.Parse(this.txtPageNumber.Text);
            int maxPageNumber = int.Parse(this.lblMaxPageNumber.Text);
            int newPageNumber = 1;

            switch (e.CommandArgument.ToString().ToLower())
            {
                case "first":
                    newPageNumber = 1;
                    break;
                case "prev":
                    newPageNumber = pageNumber - 1;
                    newPageNumber = newPageNumber < 1 ? 1 : newPageNumber;
                    break;
                case "next":
                    newPageNumber = pageNumber + 1;
                    newPageNumber = newPageNumber > maxPageNumber ? maxPageNumber : newPageNumber;
                    break;
                case "last":
                    newPageNumber = maxPageNumber;
                    break;
            }

            this.txtPageNumber.Text = newPageNumber.ToString();
            this.grdList.PageIndex = newPageNumber - 1;

            GrdListLoad();

        }
        protected void GrdListPageNumberChanged(object sender, EventArgs e)
        {
            int newPageNumber = 0;
            int maxPageNumber = int.Parse(this.lblMaxPageNumber.Text);

            if (int.TryParse(this.txtPageNumber.Text, out newPageNumber))
            {
                if (newPageNumber > 0 && newPageNumber <= maxPageNumber)
                {
                    this.grdList.PageIndex = newPageNumber - 1;
                    //pageIndex = (newPageNumber * this.grdList.PageSize) - this.grdList.PageSize;
                    //pageIndex = pageIndex < 0 ? 0 : pageIndex;
                }
                else if (newPageNumber > maxPageNumber)
                {
                    this.grdList.PageIndex = maxPageNumber - 1;
                }
            }
            else
            {
                this.grdList.PageIndex = 0;
            }

            GrdListLoad();
        }
        protected void GrdListPageSizeSelectedIndexChanged(object sender, EventArgs e)
        {
            int pageSize = int.Parse(this.ddlPageSize.SelectedValue);

            if (pageSize == 0)
            {
                this.grdList.PageSize = int.Parse(this.ViewState["TotalRecords"].ToString());
                this.grdList.PageIndex = 0;
            }
            else
            {
                this.grdList.PageSize = pageSize;
                this.grdList.PageIndex = 0;
            }
            GrdListLoad();
        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            ActualizarFiltro();
        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            ActualizarFiltro();
        }
        private void ActualizarFiltro()
        {
            string searchValue = string.Empty;

            if (!string.IsNullOrEmpty(this.txtFiltro.Text))
                searchValue = this.txtFiltro.Text;

            this.ViewState["SearchValue"] = searchValue;
            this.Session[USR_SEARCH_VALUE] = searchValue;
            GrdListLoad();
        }
        #endregion
        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/bps/LicitacionEdit.aspx?";
            url += "IdLic=" + this.ViewState["CodLicitacion"].ToString();
            Response.Redirect(url);
        }
    }
}
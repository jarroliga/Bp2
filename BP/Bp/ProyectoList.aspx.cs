using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.Enums;
using Snip.BP.BO.Bp;
using Snip.BP.Bll.Bp;

namespace BP.Bp
{
    public partial class ProyectoList : System.Web.UI.Page
    {
        private string searchValue = string.Empty; // Sin filtrar
        private string sortExpression = "CodSnip"; // Criterio de ordenamiento inicial
        private SortDirection sortDirection = SortDirection.Ascending;

        static readonly string PROY_SEARCH_VALUE = "ProySearchValue";

        private int anio = DateTime.Today.Year;

        #region Eventos de la Pagina

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.HideMenuAll();
                Master.SetMenuVisible(MenuIndex.Inicio, true);
                Master.SetMenuVisible(MenuIndex.Licitaciones, true);

                ListaPipLoad();

                if (Session["AnioPIP"] != null)
                {
                    this.ddlListaPip.SelectedValue = Session["AnioPIP"].ToString();
                }
                else
                {
                    Session.Add("AnioPIP", this.ddlListaPip.SelectedValue);
                    this.anio = Convert.ToInt32(this.ddlListaPip.SelectedValue);
                }

                Master.Anio = this.anio;

                this.grdList.DataKeyNames = new string[] { "Codigo" };

                if (Session[PROY_SEARCH_VALUE] != null)
                    searchValue = Session[PROY_SEARCH_VALUE].ToString();
                else
                    Session.Add(PROY_SEARCH_VALUE, searchValue);

                // Actualiza el tamaño de página al seleccionado por el usuario
                this.grdList.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                // Almacena en variable de estado los valores iniciales de filtrado, paginación y ordenamiento
                this.ViewState.Add("SearchValue", searchValue);
                this.ViewState.Add("SortField", this.sortExpression);
                this.ViewState.Add("SortDirection", this.sortDirection);
                this.ViewState.Add("PIP", this.ddlListaPip.SelectedValue);

                grdList_Load();
            }
        }
        #endregion

        private void ListaPipLoad()
        {
            this.ddlListaPip.DataSource = ListaPipManager.GetList();
            this.ddlListaPip.DataTextField = "Nombre";
            this.ddlListaPip.DataValueField = "Anio";
            this.ddlListaPip.DataBind();
            this.ddlListaPip.SelectedIndex = -1;
        }
        protected void ListaPipSelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("AnioPIP", this.ddlListaPip.SelectedValue);
            grdList_Load();
        }

        #region Manejadores de Eventos del GridView

        protected void grdList_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton edit = (ImageButton)e.Row.Cells[0].FindControl("imgEdit");
                edit.CommandArgument = e.Row.RowIndex.ToString();

                ImageButton read = (ImageButton)e.Row.Cells[1].FindControl("imgRead");
                read.CommandArgument = e.Row.RowIndex.ToString();
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

                url = "~/Bp/ProyectoView.aspx?anio=" + this.ViewState["PIP"].ToString();
                url += "&IdProy=" + this.grdList.SelectedDataKey["Codigo"].ToString();

                Response.Redirect(url);
            }
            if (e.CommandName == "Consultar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = this.grdList.Rows[index];
                grdList.SelectedIndex = index;

                url = "~/Bp/ProyectoView.aspx?anio=" + this.ViewState["PIP"].ToString();
                url += "&IdProy=" + this.grdList.SelectedDataKey["Codigo"].ToString();

                Response.Redirect(url);
            }
        }
        protected void grdList_DataBound(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

        }
        private void grdList_Load()
        {
            // Recupera las variables de sesion con los filtros y parametros para la carga de los datos
            string currentSearchValue = this.Session[PROY_SEARCH_VALUE].ToString();

            string currentSortField = this.ViewState["SortField"].ToString();
            SortDirection currentSortDirection = (SortDirection)this.ViewState["SortDirection"];

            int currentPageIndex = this.grdList.PageIndex;
            int currentPageSize = this.ddlPageSize.SelectedValue == "0" ? 0 : this.grdList.PageSize;

            int currentMaxPageIndex = Convert.ToInt32(this.ViewState["MaxPageIndex"]);
            int anio = Convert.ToInt32(this.Session["AnioPIP"]);

            bool sortDirection = currentSortDirection == SortDirection.Ascending ? true : false;

            string idPerfil = null;
            int codUsuario = -1;

            if (Session["CodUsuario"] != null)
            {
                idPerfil = Session["IdPerfil"].ToString();
                codUsuario = Convert.ToInt32(Session["CodUsuario"]);
            }

            // Recupera los datos de acuerdo a los parametros especificados, retornando el número de registros.
            int totalRecords = 0;
            this.grdList.DataSource = ProyectoManager.GetListPaged(anio, currentPageIndex, currentPageSize, currentSortField, sortDirection, currentSearchValue, string.Empty, string.Empty, codUsuario, idPerfil, Session.SessionID, ref totalRecords);
            this.grdList.DataBind();

            // Actualiza el máximo número de páginas disponibles de acuerdo al nuevo tamaño de página.
            int maxPageIndex = CalculatePages(totalRecords) - 1;
            this.ViewState.Add("MaxPageIndex", maxPageIndex);
            this.ViewState.Add("TotalRecords", totalRecords);

            // Actualiza la barra de navegación con los valores de página actual y de total de páginas.
            this.txtPageNumber.Text = (currentPageIndex + 1).ToString();
            this.lblMaxPageNumber.Text = (maxPageIndex + 1).ToString();

            this.lblTotalRegistros.Text = "  Total: " + totalRecords.ToString("#,###") + " registros";

            EnableDisableNavigation(maxPageIndex);
            upGrd.Update();

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
        protected void grdList_Sorted(Object source, GridViewSortEventArgs e)
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

            grdList_Load();

        }
        protected void grdList_PageIndexChanged(object sender, CommandEventArgs e)
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

            grdList_Load();

        }
        protected void grdList_PageNumberChanged(object sender, EventArgs e)
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

            grdList_Load();
        }
        protected void PageSizeSelectedIndexChanged(object sender, EventArgs e)
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
            grdList_Load();
        }
        protected void FiltroTextChanged(object sender, EventArgs e)
        {
            ActualizarFiltro();
        }
        protected void FiltroClick(object sender, EventArgs e)
        {
            ActualizarFiltro();
        }
        private void ActualizarFiltro()
        {
            string searchValue = string.Empty;

            if (!string.IsNullOrEmpty(this.txtFiltro.Text))
                searchValue = this.txtFiltro.Text;

            this.ViewState["SearchValue"] = searchValue;
            this.Session[PROY_SEARCH_VALUE] = searchValue;
            grdList_Load();
        }

        #endregion

        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/Default.aspx";
            Response.Redirect(url);
        }
    }
}
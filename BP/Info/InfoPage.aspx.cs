using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.Enums;
using Snip.Errors;

namespace BP.Info
{
    public partial class InfoPage : System.Web.UI.Page
    {
        private int errorType;
        private int appForm;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Int32.TryParse(Request.QueryString["error"].ToString(), out errorType) && Int32.TryParse(Request.QueryString["ref"].ToString(), out appForm))
                {
                    ShowMessage();
                }
            }
        }
        private void ShowMessage()
        {
            string msj = string.Empty;
            string frm = string.Empty;
            ErrorLevel level = ErrorLevel.SlightError;

            msj = ErrorHandler.GetErrorMessage((ErrorType)errorType, out level);
            frm = ((AppForms)appForm).ToString();

            this.labErrorMessage.Text = msj;
            this.lblFuenteEvento.Text = frm;
        }
    }
}
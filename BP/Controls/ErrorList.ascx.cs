using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Snip.BP.Validation;

namespace BP.Controls
{
    public partial class ErrorList : System.Web.UI.UserControl
    {
        private BrokenRulesCollection brokenRules;

        public BrokenRulesCollection BrokenRules
        {
            get { return brokenRules; }
            set
            {
                rptList.DataSource = value;
                rptList.DataBind();
                brokenRules = value;
            }
        }
    }
}
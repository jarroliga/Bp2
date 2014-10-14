using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Snip.Web.UI.TextBox
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:SnipDateTextBox runat=server></{0}:SnipDateTextBox>")]
    public class SnipDateTextBox : System.Web.UI.WebControls.TextBox
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }

        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);

            //Agrega un atributo al textbox para llamar al script para validar
            writer.AddAttribute("onblur", "return validateDateField(this);");
            writer.AddAttribute("onfocus", "return setEditionModeDate(this);");
        }
    }
}

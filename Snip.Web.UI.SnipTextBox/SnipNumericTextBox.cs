﻿using System;
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
    [ToolboxData("<{0}:SnipNumericTextBox runat=server></{0}:SnipNumericTextBox>")]
    public class SnipNumericTextBox : System.Web.UI.WebControls.TextBox
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
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            //Agrega un atributo al textbox para llamar al script para validar
            writer.AddAttribute("onblur", "return validateNumberField(this);");
            writer.AddAttribute("onfocus", "return setEditionModeNumber(this);");
            //writer.AddAttribute("onchange", "return sumarizar(this);");
            writer.AddAttribute("onkeypress", "return readOnlyNumbers(event);");
        }
    }
}

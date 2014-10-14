
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Snip.Web.UI.TextBox.design;

namespace Snip.Web.UI.TextBox
{
    /// <summary>
    /// derivamos de customvalidator
    /// </summary>
    [DefaultProperty("Text"),ToolboxItem(false),]
    public class CustomExValidator : CustomValidator
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="textbox"></param>
    
        public CustomExValidator(snipTextBox textbox): base()
        {
            TextBox = textbox;
        }

        private snipTextBox m_TextBox = null;
        
        internal snipTextBox TextBox
        {
            get { return m_TextBox; }
            set
            {
                this.ID = value.ID + "_CustomExValidator";

                m_TextBox = value;
            }
        }

       /// <summary>
       /// sobreescribimos el metodo a renderizar
       /// </summary>
       /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            Common.RenderExHelper(this, TextBox, writer);
            base.Render(writer);
        }
    }
}


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
    [DefaultProperty("Text"),ToolboxItem(false),]
    public class RangeExValidator : RangeValidator
    {
       
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="textbox"></param>
        public RangeExValidator(snipTextBox textbox): base()
        {
            TextBox = textbox;
        }

        private snipTextBox m_TextBox = null;
        
        internal snipTextBox TextBox
        {
            get { return m_TextBox; }
            set
            {
                this.ID = value.ID + "_RangeExValidator";

                m_TextBox = value;
            }
        }

       /// <summary>
       /// elemento para renderizar en html
       /// </summary>
       /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            Common.RenderExHelper(this, TextBox, writer);
            base.Render(writer);
        }
    }
}

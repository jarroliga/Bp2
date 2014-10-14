
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
    /// derivamos de comparevalidator
    /// </summary>
    [DefaultProperty("Text"),ToolboxItem(false),]
    public class CompareExValidator : CompareValidator
    {
        /// <summary>
        /// inicializar una nueva instacion
        /// </summary>
        /// <param name="textbox">textbox a construir</param>
        public CompareExValidator(snipTextBox textbox)
            : base()
        {
            TextBox = textbox;
        }

        private snipTextBox m_TextBox = null;
       

        internal snipTextBox TextBox
        {
            get { return m_TextBox; }
            set
            {
                this.ID = value.ID + "_CompareExValidator";

                m_TextBox = value;
            }
        }

        /// <summary>
        /// sobreescribo el metodo a renderizar en html
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            Common.RenderExHelper(this, TextBox, writer);
            base.Render(writer);
        }
    }
}

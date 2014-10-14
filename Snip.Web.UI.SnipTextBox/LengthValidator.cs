using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;


namespace Snip.Web.UI.TextBox
{   
    /// <summary>
    /// clase encargada de limitar la longuitud de un campo
    /// </summary>
    class LengthValidator : BaseValidator
    {
        /// <summary>
        /// texto en donde capturo la informacion
        /// </summary>
        private snipTextBox m_TextBox = null;

        public LengthValidator(snipTextBox textbox)
            : base()
        {
            TextBox = textbox;
        }
        /// <summary>
        /// campo manejo del textbox
        /// </summary>
        internal snipTextBox TextBox
        {
            get { return m_TextBox; }
            set
            {
                this.ID = value.ID + "_LengthValidator";

                m_TextBox = value;
            }
        }
        int _maximumLength = 0;
        /// <summary>
        /// maxima longuitud del campo permitida
        /// </summary>
        public int MaximumLength
        {
            get { return _maximumLength; }
            set { _maximumLength = value; }
        }
        
        /// <summary>
        /// escribimos el control con el texto
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            Common.RenderExHelper(this, TextBox, writer);
            base.Render(writer);
        }

        /// <summary>
        /// deterterminar si es valido el campo o no
        /// </summary>
        /// <returns></returns>
        protected override bool EvaluateIsValid()
        {
            String value = this.GetControlValidationValue(this.ControlToValidate);
            if (value.Length > _maximumLength)
                return false;
            else
                return true;
        }
    }
}

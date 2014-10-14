using System;
using Snip.Web.UI.TextBox.design;
using System.Web.UI.WebControls;
using System.Drawing.Design;
using System.ComponentModel;
using System.Web.UI;
namespace Snip.Web.UI.TextBox
{

    /// <summary>
    /// Esta clase es utilizada como clase base,se deriva de basevalidator
    /// </summary>
    [DefaultProperty("Text"),ToolboxItem(false),]
    public class snipBaseValidator : BaseValidator
    {
        #region Variables Privadas

        #endregion

        #region Propiedades
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="textbox"></param>
        public snipBaseValidator(snipTextBox textbox): base()
        {
            CurrentDateType = DateType.DDMMYYYY; //formato dia/mes/año
            DigitsAfterDecimalPoint = 2;
            SpecialChars = string.Empty;
            CurrentTextBoxType = TextBoxType.NONE;
            RequiredValidatorMessage = "El campo es requerido";
            TextBox = textbox;
            RenderDesignModeValidatorIcon = false;
        }

    private snipTextBox m_TextBox = null;
    internal snipTextBox TextBox
    {
      get { return m_TextBox; }
      set
      {
        this.ID = value.ID + "_DummyValidator";

        m_TextBox = value;
      }
    }
        /// <summary>
        /// mostrar icono en tiempo de diseno
        /// </summary>
        public bool RenderDesignModeValidatorIcon { get; set; }
        /// <summary>
        /// mensaje cuando el campo es requerido
        /// </summary>
        public string RequiredValidatorMessage { get; set; }
        /// <summary>
        /// tipo de textobox
        /// </summary>
        public TextBoxType CurrentTextBoxType { get; set; }
        /// <summary>
        /// caracteres especiales
        /// </summary>
        public string SpecialChars { get; set; }
        /// <summary>
        /// digitos despues del punto decimal
        /// </summary>
        public int DigitsAfterDecimalPoint { get; set; }
        /// <summary>
        /// tipo de fecha
        /// </summary>
        public DateType CurrentDateType { get; set; }

        #endregion

        #region Metodos para validar
      
        /// <summary>
      /// evaluar si es valido
      /// </summary>
      /// <returns></returns>
        protected override bool EvaluateIsValid()
        {
            return true;
        }
        /// <summary>
        /// sobreescribir el render
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            Common.RenderExHelper(this, TextBox, writer);
            base.Render(writer);
        }
        #endregion
    }
}

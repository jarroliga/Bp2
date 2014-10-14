
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using Snip.Web.UI.TextBox.design;
using Snip.Web.UI.TextBox;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Snip.Web.UI.TextBox.design
{
    public class snipTextBoxActionList : DesignerActionList
    {

        #region Miembros Privados
        private snipTextBox m_LinkedControl = null;
        #endregion

        #region Constructor and other helper method
        /// <summary>
        /// acciones disponibles a mostrar
        /// </summary>
        /// <param name="textbox">objeto del tipo textbox</param>
 
        public snipTextBoxActionList(snipTextBox textbox): base(textbox)
        {
            m_LinkedControl = textbox;
        }

       /// <summary>
       /// obtner la propiedad por nombre
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
      
        private PropertyDescriptor GetPropertyByName(string name)
        {
            PropertyDescriptor pd = TypeDescriptor.GetProperties(m_LinkedControl)[name];
            if (null == pd)
            {
                throw new ArgumentException("Propiedad '" + name + "' no fue encontrada en " + m_LinkedControl.GetType().Name);
            }
            return pd;
        }
        
        /// <summary>
        ///cargar el sitio 
        /// </summary>
   
        private void LaunchSite()
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.snip.gob.ni");
            }
            catch { }
        } 
        #endregion

        #region Propiedades general
        
        /// <summary>
        /// obtener el foco si se produce un error
        /// </summary>
        public bool ValidatorFocusOnError
        {
            get { return m_LinkedControl.ValidatorFocusOnError; }
            set { GetPropertyByName("ValidatorFocusOnError").SetValue(m_LinkedControl, value); }
        }

        /// <summary>
        ///validacion en el cliente usando javascript
        /// </summary>
        public bool ValidatorEnableClientScript
        {
            get { return m_LinkedControl.ValidatorEnableClientScript; }
            set { GetPropertyByName("ValidatorEnableClientScript").SetValue(m_LinkedControl, value); }
        }

        /// <summary>
        /// Mostrar el icono en tiempo de diseño
        /// </summary>
        public bool RenderDesignModeValidatorIcon
        {
            get { return m_LinkedControl.RenderDesignModeValidatorIcon; }
            set { GetPropertyByName("RenderDesignModeValidatorIcon").SetValue(m_LinkedControl, value); }
        }

        /// <summary>
        /// tipo de icono a mostrar
        /// </summary>
        public ValidatorDisplay ValidatorDisplayType
        {
            get { return m_LinkedControl.ValidatorDisplayType; }
            set { GetPropertyByName("ValidatorDisplayType").SetValue(m_LinkedControl, value); }
        }

        /// <summary>
        /// Errorprovidetype
        /// </summary>
        public ErrorProviderType ErrorProvider
        {
            get { return m_LinkedControl.ErrorProvider; }
            set { GetPropertyByName("ErrorProvider").SetValue(m_LinkedControl, value); }
        }


        #endregion

        #region Expresiones regulares

        /// <summary>
        /// Tipo 
        /// </summary>
        public TextBoxType CurrentTextBoxType
        {
            get { return m_LinkedControl.CurrentTextBoxType; }
            set { GetPropertyByName("CurrentTextBoxType").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// expresion regular personalizada
        /// </summary>
        public string CustomRegularExpression
        {
            get { return m_LinkedControl.CustomRegularExpression; }
            set { GetPropertyByName("CustomRegularExpression").SetValue(m_LinkedControl, value); }
        }

        /// <summary>
        /// tipo de mensaje
        /// </summary>
        public string TextTypeValidatorMessage
        {
            get { return m_LinkedControl.TextTypeValidatorMessage; }
            set { GetPropertyByName("TextTypeValidatorMessage").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// caracteres especiales
        /// </summary>
        public string SpecialChars
        {
            get { return m_LinkedControl.SpecialChars; }
            set { GetPropertyByName("SpecialChars").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// digitos despues del punto decimal
        /// </summary>
        public int DigitsAfterDecimalPoint
        {
            get { return m_LinkedControl.DigitsAfterDecimalPoint; }
            set { GetPropertyByName("DigitsAfterDecimalPoint").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// CurrentDateType.
        /// </summary>
        public DateType CurrentDateType
        {
            get { return m_LinkedControl.CurrentDateType; }
            set { GetPropertyByName("CurrentDateType").SetValue(m_LinkedControl, value); }
        }
        #endregion

        #region Campo requerido
        /// <summary>
        /// El campo es requerido
        /// </summary>
        public bool Required
        {
            get { return m_LinkedControl.Required; }
            set { GetPropertyByName("Required").SetValue(m_LinkedControl, value); }
        }

        /// <summary>
        /// Mensaje que se muestra si el campo es requerido
        /// </summary>
        public string RequiredValidatorMessage
        {
            get { return m_LinkedControl.RequiredValidatorMessage; }
            set { GetPropertyByName("RequiredValidatorMessage").SetValue(m_LinkedControl, value); }
        }
        #endregion

        #region Validacion por rango
        /// <summary>
        /// Validacion por rango ejemplo de 1 hasta 10
        /// </summary>
        public bool RangeValidation
        {
            get { return m_LinkedControl.RangeValidation; }
            set { GetPropertyByName("RangeValidation").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// tipo de datos.
        /// </summary>
        public ValidationDataType CurrentValidationDataType
        {
            get { return m_LinkedControl.RangeValidationDataType; }
            set { GetPropertyByName("CurrentValidationDataType").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// valor minimo
        /// </summary>
        public string MinimumValue
        {
            get { return m_LinkedControl.MinimumValue; }
            set { GetPropertyByName("MinimumValue").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        ///valor maximo
        /// </summary>
        public string MaximumValue
        {
            get { return m_LinkedControl.MaximumValue; }
            set { GetPropertyByName("MaximumValue").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// mensaje a mostrar en caso que el valor supere el rango
        /// </summary>
        public string RangeValidatorMessage
        {
            get { return m_LinkedControl.RangeValidatorMessage; }
            set { GetPropertyByName("RangeValidatorMessage").SetValue(m_LinkedControl, value); }
        }
        #endregion

        #region Validacion para comparar
        /// <summary>
        /// Tipo de datos a comparar.
        /// </summary>
        public ValidationDataType CompareValidationDataType
        {
            get { return m_LinkedControl.CompareValidationDataType; }
            set { GetPropertyByName("CompareValidationDataType").SetValue(m_LinkedControl, value); }
        }

        /// <summary>
        /// comparar
        /// </summary>
        public bool CompareValidation
        {
            get { return m_LinkedControl.CompareValidation; }
            set { GetPropertyByName("CompareValidation").SetValue(m_LinkedControl, value); }
        }

        /// <summary>
        /// mensaje
        /// </summary>
        public string CompareValidatorMessage
        {
            get { return m_LinkedControl.CompareValidatorMessage; }
            set { GetPropertyByName("CompareValidatorMessage").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        ///control con el que se compara
        /// </summary>
        public string ControlToCompare
        {
            get { return m_LinkedControl.ControlToCompare; }
            set { GetPropertyByName("ControlToCompare").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        ///valor a comparar
        /// </summary>
        public string ValueToCompare
        {
            get { return m_LinkedControl.ValueToCompare; }
            set { GetPropertyByName("ValueToCompare").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// operador de comparacion
        /// </summary>
        public ValidationCompareOperator CompareOperator
        {
            get { return m_LinkedControl.CompareOperator; }
            set { GetPropertyByName("CompareOperator").SetValue(m_LinkedControl, value); }
        }
        #endregion

        #region Validaciones Personalizadas

        /// <summary>
        ///validacion personalizada
        /// </summary>
        public bool CustomValidation
        {
            get { return m_LinkedControl.CustomValidation; }
            set { GetPropertyByName("CustomValidation").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        ///funcion de validacion en el cliente
        /// </summary>
        public string ClientValidationFunction
        {
            get { return m_LinkedControl.ClientValidationFunction; }
            set { GetPropertyByName("ClientValidationFunction").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// validar si el texto es vacio
        /// </summary>
        public bool ValidateEmptyText
        {
            get { return m_LinkedControl.ValidateEmptyText; }
            set { GetPropertyByName("ValidateEmptyText").SetValue(m_LinkedControl, value); }
        }
        /// <summary>
        /// Mensaje a mostrar
        /// </summary>
        public string CustomValidatorMessage
        {
            get { return m_LinkedControl.CustomValidatorMessage; }
            set { GetPropertyByName("CustomValidatorMessage").SetValue(m_LinkedControl, value); }
        }
        #endregion

        #region Etiquetas inteligentes del componente
        /// <summary>
        /// Obtener las acciones disponibles. en tiempo diseno
        /// </summary>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection coll = new DesignerActionItemCollection();

            // aca se agregan las etiquetas inteligentes necesarias

            #region Detalle de validacion

            coll.Add(new DesignerActionHeaderItem("Sistema de Preinversion"));

            string strHeaderValidationDetails = "Opciones de Validacion";
            coll.Add(new DesignerActionHeaderItem(strHeaderValidationDetails));
            coll.Add(new DesignerActionPropertyItem("ValidatorFocusOnError", "Obtener foco", strHeaderValidationDetails, "obtiene el foco despues que se produce un error"));
            coll.Add(new DesignerActionPropertyItem("ValidatorEnableClientScript", "Habilitar JavaScript", strHeaderValidationDetails, "Habilita validacion javasript en el cliente"));
            coll.Add(new DesignerActionPropertyItem("ValidatorDisplayType", "Forma a mostrar", strHeaderValidationDetails, "Estilo dinamico o estatico  para espacio"));
            coll.Add(new DesignerActionPropertyItem("ErrorProvider", "Icono a mostrar", strHeaderValidationDetails, "Mostrar el tipo de icono de error"));
           
            
            #endregion

            #region Opciones del Campo Requerido


            string strHeaderValidation = "Campo Requerido";
            coll.Add(new DesignerActionHeaderItem(strHeaderValidation));

            coll.Add(new DesignerActionPropertyItem("Required", "Requerido", strHeaderValidation, "Obligatorio la introduccion del dato."));
            if (Required)
            {
                coll.Add(new DesignerActionPropertyItem("RequiredValidatorMessage", "Mensaje a mostrar:", strHeaderValidation, "El mensaje a mostrar cuando el campo es requerido"));
            }

            #endregion

            #region Validacion de Numeros


            string strHeaderNumericValidation = "Tipo de Validaciones";
            coll.Add(new DesignerActionHeaderItem(strHeaderNumericValidation));

            coll.Add(new DesignerActionPropertyItem("CurrentTextBoxType", "Tipo datos TextBox", strHeaderNumericValidation, "Elija una de estas si el campo es requerido."));

            if (CurrentTextBoxType == TextBoxType.CUSTOM)
            {
                coll.Add(new DesignerActionPropertyItem("CustomRegularExpression", "Expresiones Regulares propias", strHeaderNumericValidation, "elije tu propia expresion regular."));
            }
            if (CurrentTextBoxType == TextBoxType.ALPHANUMERICWITHSPECIALCHAR)
            {
                coll.Add(new DesignerActionPropertyItem("SpecialChars", "Filtro Caracteres", strHeaderNumericValidation, "elija que tipo de caracteres alfanumericos son permitidos"));

            }
            if (CurrentTextBoxType == TextBoxType.NUMERICDECIMAL || CurrentTextBoxType == TextBoxType.NUMERICDECIMALONLYPOSITIVE)
            {

                coll.Add(new DesignerActionPropertyItem("DigitsAfterDecimalPoint", "Digito despues del punto decimal", strHeaderNumericValidation, "Elige los puntos despues del decimal."));
            }
            if (CurrentTextBoxType == TextBoxType.DATE)
            {

                coll.Add(new DesignerActionPropertyItem("CurrentDateType", "Tipo de fecha a validar", strHeaderNumericValidation, "Elije el tipo de formato de la fecha a validar."));
            }
            if (CurrentTextBoxType != TextBoxType.NONE)
            {
                coll.Add(new DesignerActionPropertyItem("TextTypeValidatorMessage", "Mensaje:", strHeaderNumericValidation, "Mensaje en caso el tipo de datos no concuerde."));
            }

            #endregion

            #region Validacion en rangos
            string strHeaderRangeValidation = "Rango de Validacion";
            coll.Add(new DesignerActionHeaderItem(strHeaderRangeValidation));

            coll.Add(new DesignerActionPropertyItem("RangeValidation", "Rangos", strHeaderRangeValidation, "La validacion se da por rangos"));
            if (RangeValidation)
            {
                coll.Add(new DesignerActionPropertyItem("CurrentValidationDataType", "Tipo de Rango:", strHeaderRangeValidation, "El tipo de rango a validar"));
                coll.Add(new DesignerActionPropertyItem("MinimumValue", "Valor Minimo", strHeaderRangeValidation, "Valor minimo del rango"));
                coll.Add(new DesignerActionPropertyItem("MaximumValue", "Valor Maximo", strHeaderRangeValidation, "Valor maximo del rango"));
                coll.Add(new DesignerActionPropertyItem("RangeValidatorMessage", "Mensaje", strHeaderRangeValidation, "mensaje de error en caso de error"));

            }
            #endregion

            #region Validacion para comparar
            string strHeaderCompareValidation = "Comparaciones para validar";
            coll.Add(new DesignerActionHeaderItem(strHeaderCompareValidation));

            coll.Add(new DesignerActionPropertyItem("CompareValidation", "Comparaciones", strHeaderCompareValidation, "chequea si este campo se va ha comparar."));
            if (CompareValidation)
            {
                coll.Add(new DesignerActionPropertyItem("CompareValidationDataType", "Tipo Comparacion:", strHeaderCompareValidation, "Tipo de validacion de la compracion"));
                coll.Add(new DesignerActionPropertyItem("ControlToCompare", "Control a Comparar:", strHeaderCompareValidation, "El control con el que se va ha comparar"));
                coll.Add(new DesignerActionPropertyItem("ValueToCompare", "Valores a comparar:", strHeaderCompareValidation, "El valor a comparar"));


                coll.Add(new DesignerActionPropertyItem("CompareOperator", "Operador", strHeaderCompareValidation, "Operador de comparacion."));
                coll.Add(new DesignerActionPropertyItem("CompareValidatorMessage", "Mensaje", strHeaderCompareValidation, "Mensaje de comparacion"));
            }
            #endregion

            #region Custom Validation
            string strHeaderCustomValidation = "Validaciones Propias";
            coll.Add(new DesignerActionHeaderItem(strHeaderCustomValidation));

            coll.Add(new DesignerActionPropertyItem("CustomValidation", "Validacion Propia", strHeaderCustomValidation, "chequea si el campo es requerido con validacion propia."));
            if (CustomValidation)
            {
                coll.Add(new DesignerActionPropertyItem("ClientValidationFunction", "Client Side Function", strHeaderCustomValidation, "Funcion Javascript para validar"));


                coll.Add(new DesignerActionPropertyItem("ValidateEmptyText", "Validaciion con texto vacio", strHeaderCustomValidation, "Realizarlo si el campo es incluso vacio."));

                coll.Add(new DesignerActionPropertyItem("CustomValidatorMessage", "Mensaje", strHeaderCustomValidation, "Mensaje de error"));
            }
            #endregion

            #region en Modo diseno
            coll.Add(new DesignerActionHeaderItem("Modo diseño"));
            coll.Add(new DesignerActionPropertyItem("RenderDesignModeValidatorIcon", "Mostrar icono", "Design Mode", "muestra el icono en modo diseño"));

            coll.Add(new DesignerActionHeaderItem("Informacion"));
            coll.Add(new DesignerActionMethodItem(this, "LaunchSite", "Xavier Areas", "Information", true));

            coll.Add(new DesignerActionTextItem("ID: " + m_LinkedControl.ID, "ID"));

            #endregion

            return coll;
        }
        #endregion

    }
}

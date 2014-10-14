using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Snip.Web.UI.TextBox.design;
using System.Drawing.Design;
using System.IO;




namespace Snip.Web.UI.TextBox
{
    
    [ToolboxData("<{0}:snipTextBox runat=server></{0}:snipTextBox>"),Designer(typeof(snipTextBoxDesigner)),
    ]
    public class snipTextBox :  System.Web.UI.WebControls.TextBox
    {

        #region Variables Privadas

        private const string DEFAULT_VALIDATOR_TEXT = "&nbsp;*";

        private RangeExValidator rngValidator = null;
        private RegExValidator regExValidator = null;
        private RequiredValidator reqValidator = null;
        private CompareExValidator cmpValidator = null;
        private CustomExValidator cusValidator = null;
        private LengthValidator lngValidator = null;
        private snipBaseValidator m_BaseValidation = null;
        private List<BaseValidator> m_ArrayFieldValidators = null;
        private bool m_blnIsRequired = false;
        private bool m_blnIsRangeValidation = false;
        private bool m_blnIsCompareValidation = false;
        private bool m_blnIsCustomValidation = false;
        private bool m_blnIsDynamicQuerySupport = false;
        private ErrorProviderType m_ErrorProvider = ErrorProviderType.StillIcon;
        public event ServerValidateEventHandler ServerValidate;

        #endregion

        #region Constructor de la clase
       /// <summary>
       /// constructor de la clase,inicializamos los datos
       /// que son requeridos.
       /// </summary>
        public snipTextBox()
        {
            LengthMaxValue = 0; 
            ValidatorDisplayType = ValidatorDisplay.Dynamic;
            ValidatorEnableClientScript = true;
            ValidatorFocusOnError = true;
        }
        #endregion

        #region Propiedades Generales,Listado de objetos validators


      
        [Browsable(false),]
        private List<BaseValidator> ArrayFieldValidators
        {
            get
            {
                if (m_ArrayFieldValidators == null)
                    m_ArrayFieldValidators = new List<BaseValidator>();

                return m_ArrayFieldValidators;
            }
            set
            {
                m_ArrayFieldValidators = value;
            }
        }

        /// <summary>
        /// objeto para validar los rangos
        /// </summary>
        private RangeExValidator RangeExValidatorObject
        {
            get
            {
                if (rngValidator == null)
                    rngValidator = new RangeExValidator(this);

                return rngValidator;
            }
            set
            {
                rngValidator = value;
            }
        }
        
        /// <summary>
        /// objeto para validar las expresiones
        /// </summary>
        private RegExValidator RegExValidatorObject
        {
            get
            {
                if (regExValidator == null)
                    regExValidator = new RegExValidator(this);

                return regExValidator;
            }
            set
            {
                regExValidator = value;
            }
        }

        /// <summary>
        /// objeto para validar si es requerido o no
        /// </summary>
        private RequiredValidator ReqValidatorObject
        {
            get
            {
                if (reqValidator == null)
                    reqValidator = new RequiredValidator(this);

                return reqValidator;
            }
            set
            {
                reqValidator = value;
            }
        }
        
        /// <summary>
        /// objeto para comparar
        /// </summary>
        private CompareExValidator CompareExValidatorObject
        {
            get
            {
                if (cmpValidator == null)
                    cmpValidator = new CompareExValidator(this);

                return cmpValidator;
            }
            set
            {
                cmpValidator = value;
            }
        }
       
        /// <summary>
        /// objeto para realizar validaciones personalizadas
        /// </summary>
        private CustomExValidator CustomExValidatorObject
        {
            get
            {
                if (cusValidator == null)
                    cusValidator = new CustomExValidator(this);

                return cusValidator;
            }
            set
            {
                cusValidator = value;
            }
        }

        /// <summary>
        /// objeto para validar la longuitud
        /// </summary>
        private LengthValidator  LengthValidatorObject
        {
            get
            {
                if (lngValidator == null)
                    lngValidator = new LengthValidator(this);

                return lngValidator;
            }
            set
            {
                lngValidator = value;
            }
        }

        /// <summary>
        /// objeto base de validacion
        /// </summary>
        private snipBaseValidator snipBaseValidator
        {
            get
            {
                if (m_BaseValidation == null) { m_BaseValidation = new snipBaseValidator(this); }
                return m_BaseValidation;
            }
            set { m_BaseValidation = value; }
        }

       /// <summary>
       /// esta en tiempo de diseno
       /// </summary>
        internal bool IsDesignMode
        {
            get { return DesignMode; }
        }

        /// <summary>
        /// formato que agrega comillas para hacerlo compatible con sql
        /// </summary>
        public string TextCompatibleWithSql
        {
            get
            {
                return base.Text.Replace("'", "''");
            }
        }
        #endregion

        #region Propiedades generales en tiempo de diseno

     
        [Description("El tipo de alerta visual cuando la validacion falla"),Category("Configuracion Validacion"),DefaultValue(ErrorProviderType.StillIcon),]
        public ErrorProviderType ErrorProvider
        {
            get { return m_ErrorProvider; }
            set
            {
                if (value == ErrorProviderType.Text) { snipBaseValidator.Text = DEFAULT_VALIDATOR_TEXT; }
                m_ErrorProvider = value;
            }
        }


      
        [Description("La validacion a mostrar"),Category("Configuracion Validacion"),]
        public ValidatorDisplay ValidatorDisplayType
        {
            get { return snipBaseValidator.Display; }
            set { snipBaseValidator.Display = value; }
        }

        
        [
         Description("Si se muestra o no el icono cuando esta en diseno."),Category("Configuracion Validacion"),]
        public bool RenderDesignModeValidatorIcon
        {
            get { return snipBaseValidator.RenderDesignModeValidatorIcon; }
            set
            {
                if (Required || RangeValidation || CompareValidation || CurrentTextBoxType != TextBoxType.NONE || CustomValidation || value == true)
                {
                    snipBaseValidator.RenderDesignModeValidatorIcon = true;
                }
                else
                {
                    snipBaseValidator.RenderDesignModeValidatorIcon = false;
                }
            }
        }


        [Description("Si el control tendra el foco cuando se produsca un error"), Category("Configuracion Validacion"),]
        public bool ValidatorFocusOnError
        {
            get { return snipBaseValidator.SetFocusOnError; }
            set { snipBaseValidator.SetFocusOnError = value; }
        }


        [Description("Habilitar la validacion en el cliente con javascript"), Category("Configuracion Validacion"),]
        public bool ValidatorEnableClientScript
        {
            get { return snipBaseValidator.EnableClientScript; }
            set { snipBaseValidator.EnableClientScript = value; }
        }


        #endregion

        #region Campo de Requerido

      
        [Description("Es necesario este campo ?"),Category("Validacion Requerida"),]
        public bool Required
        {
            get { return m_blnIsRequired; }
            set { RenderDesignModeValidatorIcon = m_blnIsRequired = value; }
        }

        [Description("Mensaje a mostrar cuando la validacion falla"), Category("Validacion Requerida"),
        ]
        public string RequiredValidatorMessage
        {
            get { return ReqValidatorObject.ErrorMessage; }
            set { ReqValidatorObject.ErrorMessage = value; }
        }
        #endregion

        #region Expresiones Regulares y otro tipo
        
        [Description("El tipo de validacion para el textbox."),Category("Validacion Expressiones"),]
        public TextBoxType CurrentTextBoxType
        {
            get { return snipBaseValidator.CurrentTextBoxType; }
            set
            {
                if (value != TextBoxType.NONE)
                {
                    RenderDesignModeValidatorIcon = true;
                }
                snipBaseValidator.CurrentTextBoxType = value;
            }
        }

        [Description("Mensaje cuando la validacion falla"), Category("Validacion Expressiones"),]
        public string TextTypeValidatorMessage
        {
            get { return RegExValidatorObject.ErrorMessage; }
            set { RegExValidatorObject.ErrorMessage = value; }
        }
        
        [Description("Expresion regular para validar el dato."),Category("Validacion Expressiones"),]
        public string CustomRegularExpression
        {
            get { return RegExValidatorObject.ValidationExpression; }
            set { RegExValidatorObject.ValidationExpression = value; }
        }
       
        [Description("Caracteres especialies en caso que se utilizen"),Category("Validacion Expressiones"),]
        public string SpecialChars
        {
            get { return snipBaseValidator.SpecialChars; }
            set { snipBaseValidator.SpecialChars = value; }
        }
      
        
        [Description("Digitos despues del punto decimal."),Category("Validacion Expressiones"),DefaultValue(2)]
        public int DigitsAfterDecimalPoint
        {
            get { return snipBaseValidator.DigitsAfterDecimalPoint; }
            set { snipBaseValidator.DigitsAfterDecimalPoint = value; }
        }

        
        [Description("Tipo de datos para la validacion."),Category("Validacion Expressiones"),]
        public DateType CurrentDateType
        {
            get { return snipBaseValidator.CurrentDateType; }
            set { snipBaseValidator.CurrentDateType = value; }
        }
        #endregion

        #region Validacion en Rango
        /// <summary>
        /// obtiene o configura el tipo de datos a validar en el rango
        /// </summary>
        [Description("Tipo de dato del rango a validar."),Category("Validacion Rango"),]
        public ValidationDataType RangeValidationDataType
        {
            get { return RangeExValidatorObject.Type; }
            set { RangeExValidatorObject.Type = value; }
        }
        
       
        [Description("Chequearlo si requiere una validacion en rango"),Category("Validacion Rango"),]
        public bool RangeValidation
        {
            get { return m_blnIsRangeValidation; }
            set { RenderDesignModeValidatorIcon = m_blnIsRangeValidation = value; }
        }

       
        [Description("Valor Minimo del rango o la cota"),Category("Validacion Rango"),]
        public string MinimumValue
        {
            get { return RangeExValidatorObject.MinimumValue; }
            set { RangeExValidatorObject.MinimumValue = value; }
        }

       
        [Description("Valor maximo del rango o la cota"),Category("Validacion Rango"),]
        public string MaximumValue
        {
            get { return RangeExValidatorObject.MaximumValue; }
            set { RangeExValidatorObject.MaximumValue = value; }
        }

        
        [Description("El mensaje a mostrar cuando el rango es superado"),Category("Validacion Rango"),]
        public string RangeValidatorMessage
        {
            get { return RangeExValidatorObject.ErrorMessage; }
            set { RangeExValidatorObject.ErrorMessage = value; }
        }
        #endregion

        #region Compare Validator

        /// <summary>
        ///tipo actual para comparar
        /// </summary>
        [
         Description("Tipo de fecha actual."),
         Category("Comparar"),
        ]
        public ValidationDataType CompareValidationDataType
        {
            get { return CompareExValidatorObject.Type; }
            set { CompareExValidatorObject.Type = value; }
        }
        /// <summary>
        /// compara o no validacion
        /// </summary>
        [
         Description("Si se va a comparar"),
         Category("Comparar"),
        ]
        public bool CompareValidation
        {
            get { return m_blnIsCompareValidation; }
            set { RenderDesignModeValidatorIcon = m_blnIsCompareValidation = value; }
        }
        /// <summary>
        /// mensaje de validacion
        /// </summary>
        /// <value>el mensaje de validacion a mostrar.</value>
        [
         Description("El mensaje de validacion al fallar"),
         Category("Compara"),
        ]
        public string CompareValidatorMessage
        {
            get { return CompareExValidatorObject.ErrorMessage; }
            set { CompareExValidatorObject.ErrorMessage = value; }
        }
        /// <summary>
        /// control a comparar
        /// </summary>
        [
         TypeConverter(typeof(ValidatedControlConverter)),
         Description("control a comparar"),
         Category("Compara"),
        ]
        public string ControlToCompare
        {
            get { return CompareExValidatorObject.ControlToCompare; }
            set { CompareExValidatorObject.ControlToCompare = value; }
        }
        /// <summary>
        /// valor a comparar
        /// </summary>
        [
         Description("valor a comparar"),
         Category("Compara"),
        ]
        public string ValueToCompare
        {
            get { return CompareExValidatorObject.ValueToCompare; }
            set { CompareExValidatorObject.ValueToCompare = value; }
        }

        /// <summary>
        /// Operador de la comparacion
        /// </summary>
        [Description("Operador de la comparacion"),Category("Validacion Operador"),]
        public ValidationCompareOperator CompareOperator
        {
            get { return CompareExValidatorObject.Operator; }
            set { CompareExValidatorObject.Operator = value; }
        }
        #endregion

        #region Validaciones propias o personalizadas
        /// <summary>
        /// configura la validacion personalizada
        /// </summary>
        /// <value></value>
        [Description("Validacion propia"),Category("Validacion Personalizada"),]
        public bool CustomValidation
        {
            get { return m_blnIsCustomValidation; }
            set
            {
               
                /*if (cusValidator == null)
                {
                   // StreamWriter wr = new StreamWriter("C:\\errorsnip.txt");
                   // wr.WriteLine("Null...");
                   // wr.Close();
                }
                else
                {
                   // StreamWriter wr = new StreamWriter("C:\\errorsnip.txt", true);
                   // wr.WriteLine("Creado");
                   // wr.Close();
                }*/
                RenderDesignModeValidatorIcon = m_blnIsCustomValidation = value;
            }
        }

        [Description("Funcion en el cliente que se encarga de la validacion,javascript"), Category("Validacion Personalizada"),]
        public string ClientValidationFunction
        {
            get { return CustomExValidatorObject.ClientValidationFunction; }
            set { CustomExValidatorObject.ClientValidationFunction = value; }
        }

        [Description("Validar si esta vacia"), Category("Validacion Personalizada"),]
        public bool ValidateEmptyText
        {
            get { return CustomExValidatorObject.ValidateEmptyText; }
            set { CustomExValidatorObject.ValidateEmptyText = value; }
        }

        [Description("Mensaje a mostrar en caso la validacion falle"), Category("Validacion Personalizada"),]
        public string CustomValidatorMessage
        {
            get { return CustomExValidatorObject.ErrorMessage; }
            set { CustomExValidatorObject.ErrorMessage = value; }
        }
        #endregion

        #region Validacion de longuitudes 
        [Description("Valor maximmo de longuitud"), Category("Longuitud Campo"),]
        public  int  LengthMaxValue
        {
            get { return LengthValidatorObject.MaximumLength; }
            set { LengthValidatorObject.MaximumLength = value; }
        }
       
        [Description("Mensaje a mostrar cuando la longuitud se exceda"), Category("Longuitud Campo"),]
       public string LengthValidatorMessage
        {
            get { return LengthValidatorObject.ErrorMessage; }
            set { LengthValidatorObject.ErrorMessage = value; }
        }

        #endregion

        #region Init y Prerender sobrescritas

        private string GetStrSpecialString()
        {
            string strSpecialString = string.Empty;
            if (CurrentTextBoxType == TextBoxType.ALPHANUMERICWITHSPECIALCHAR)
            {
                strSpecialString = SpecialChars;
            }
            else if (CurrentTextBoxType == TextBoxType.NUMERICDECIMAL || CurrentTextBoxType == TextBoxType.NUMERICDECIMALONLYPOSITIVE)
            {
                strSpecialString = DigitsAfterDecimalPoint.ToString();
            }
            else if (CurrentTextBoxType == TextBoxType.DATE)
            {
                strSpecialString = CurrentDateType.ToString();
            }
            else if (CurrentTextBoxType == TextBoxType.CUSTOM)
            {
                strSpecialString = CustomRegularExpression;
            }
            return strSpecialString;
        }

        /// <summary>
        /// constructor de creacion de los componentes a validar
        /// y reglas a validar crear un arreglo de reglas de validacion
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
           
            Controls.Clear();
            this.ID = base.ID;

            if (!IsDesignMode)
            {
                if (Required)
                {
                    ReqValidatorObject.TextBox = this;
                    ReqValidatorObject.ControlToValidate = this.ID;
                    ReqValidatorObject.EnableClientScript = ValidatorEnableClientScript;
                    ReqValidatorObject.Enabled = true;
                    ReqValidatorObject.ValidationGroup = this.ValidationGroup;
                    ReqValidatorObject.Text = (ErrorProvider == ErrorProviderType.Text) ? DEFAULT_VALIDATOR_TEXT : string.Empty;
                    ReqValidatorObject.Display = ValidatorDisplayType;
                    ReqValidatorObject.SetFocusOnError = ValidatorFocusOnError;
                    Controls.Add(reqValidator);
                    ArrayFieldValidators.Add(ReqValidatorObject);
                }

                 if (CurrentTextBoxType != TextBoxType.NONE)
                {


                    RegExValidatorObject.TextBox = this;

                    RegExValidatorObject.ValidationExpression = Common.GetRegularExpression(CurrentTextBoxType, GetStrSpecialString());
                    RegExValidatorObject.ControlToValidate = this.ID;
                    RegExValidatorObject.EnableClientScript = ValidatorEnableClientScript;
                    RegExValidatorObject.Enabled = true;
                    RegExValidatorObject.ValidationGroup = this.ValidationGroup;
                    RegExValidatorObject.Text = (ErrorProvider == ErrorProviderType.Text) ? DEFAULT_VALIDATOR_TEXT : string.Empty;
                    RegExValidatorObject.Display = ValidatorDisplayType;
                    RegExValidatorObject.SetFocusOnError = ValidatorFocusOnError;
                    Controls.Add(RegExValidatorObject);
                    ArrayFieldValidators.Add(RegExValidatorObject);
                }

             
                if (RangeValidation)
                {

                    RangeExValidatorObject.TextBox = this;
                    RangeExValidatorObject.ControlToValidate = this.ID;
                    RangeExValidatorObject.EnableClientScript = ValidatorEnableClientScript;
                    RangeExValidatorObject.Enabled = true;
                    RangeExValidatorObject.ValidationGroup = this.ValidationGroup;
                    RangeExValidatorObject.Text = (ErrorProvider == ErrorProviderType.Text) ? DEFAULT_VALIDATOR_TEXT : string.Empty;
                    RangeExValidatorObject.Display = ValidatorDisplayType;
                    RangeExValidatorObject.SetFocusOnError = ValidatorFocusOnError;
                    Controls.Add(RangeExValidatorObject);
                    ArrayFieldValidators.Add(RangeExValidatorObject);
                }

                if (LengthMaxValue >0)
                {
                    LengthValidatorObject.TextBox = this;
                    LengthValidatorObject.ControlToValidate = this.ID;
                    LengthValidatorObject.EnableClientScript = ValidatorEnableClientScript;
                    LengthValidatorObject.Enabled = true;
                    LengthValidatorObject.ValidationGroup = this.ValidationGroup;
                    LengthValidatorObject.Text = (ErrorProvider == ErrorProviderType.Text) ? DEFAULT_VALIDATOR_TEXT : string.Empty;
                    LengthValidatorObject.Display = ValidatorDisplayType;
                    LengthValidatorObject.SetFocusOnError = ValidatorFocusOnError;
                    Controls.Add(LengthValidatorObject);
                    ArrayFieldValidators.Add(LengthValidatorObject);
                }

                if (CompareValidation)
                {

                    CompareExValidatorObject.TextBox = this;
                    CompareExValidatorObject.ControlToValidate = this.ID;
                    CompareExValidatorObject.EnableClientScript = ValidatorEnableClientScript;
                    CompareExValidatorObject.Enabled = true;
                    CompareExValidatorObject.ValidationGroup = this.ValidationGroup;
                    CompareExValidatorObject.Text = (ErrorProvider == ErrorProviderType.Text) ? DEFAULT_VALIDATOR_TEXT : string.Empty;
                    CompareExValidatorObject.Display = ValidatorDisplayType;
                    CompareExValidatorObject.SetFocusOnError = ValidatorFocusOnError;
                    Controls.Add(CompareExValidatorObject);
                    ArrayFieldValidators.Add(CompareExValidatorObject);
                }

              
                if (CustomValidation)
                {
                    CustomExValidatorObject.TextBox = this;
                    CustomExValidatorObject.ServerValidate += ServerValidate;
                    CustomExValidatorObject.ControlToValidate = this.ID;
                    CustomExValidatorObject.EnableClientScript = ValidatorEnableClientScript;
                    CustomExValidatorObject.Enabled = true;
                    CustomExValidatorObject.ValidationGroup = this.ValidationGroup;
                    CustomExValidatorObject.Text = (ErrorProvider == ErrorProviderType.Text) ? DEFAULT_VALIDATOR_TEXT : string.Empty;
                    CustomExValidatorObject.Display = ValidatorDisplayType;
                    CustomExValidatorObject.SetFocusOnError = ValidatorFocusOnError;
                    Controls.Add(CustomExValidatorObject);
                    ArrayFieldValidators.Add(CustomExValidatorObject);
                }
            }
        }
        /// <summary>
        /// sobreescribimos el renderizado
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Span);

            base.Render(writer);

            if (IsDesignMode)
            {
               
                snipBaseValidator.RenderControl(writer);
            }
            else
            {
              
                foreach (BaseValidator bvTemp in ArrayFieldValidators)
                {
                    bvTemp.RenderControl(writer);
                }
            }
            writer.RenderEndTag();
        }
      
        public override void Dispose()
        {
            
            rngValidator = null;
            regExValidator = null;
            reqValidator = null;
            cmpValidator = null;
            cusValidator = null;
            lngValidator = null; 
            GC.Collect();
            base.Dispose();
        }
        #endregion
    }
}

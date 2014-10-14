
using System;
using System.Collections.Generic;
using System.Text;

namespace Snip.Web.UI.TextBox.design
{
    /// <summary>
    /// Tipo de icono del error
    /// </summary>
    public enum ErrorProviderType : int
    {
        Text = 0,
        AnimatedIcon,
        StillIcon,
    }

    /// <summary>
    /// formato de fecha para validaccion
    /// </summary>
    public enum DateType : int
    {
        /// <summary>
        /// utilizado en estados unidos u otro pais
        /// </summary>
        MMDDYYYY,
        /// <summary>
        /// este es el utilizado en nicaragua
        /// </summary>
        DDMMYYYY
    }

   /// <summary>
   /// Tipo de validacion que tendra el texto
   /// </summary>
    public enum TextBoxType : int
    {
        NONE = 0,
        ALPHANUMERIC,
        ALPHANUMERICWITHSPECIALCHAR,
        NUMERICINT,
        NUMERICINTONLYPOSITIVE,
        NUMERICDECIMAL,
        NUMERICDECIMALONLYPOSITIVE,
        EMAIL,
        URL,
        USZIPCODE,
        USPHONE,
        SSN,
        DATE,
        IPADDRESS,
        CREDITCARD,
        PASSWORD,
        PERCENTAGE,
        GUID,
        SOCIALSECURITYNUMBER,
        CUSTOM
    }
}

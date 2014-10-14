using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Snip.Web.UI.TextBox.design;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Snip.Web.UI.TextBox
{
    class Common
    {
        /// <summary>
        /// se utiliza como auxiliar para renderizar el contenido
        /// </summary>
        /// <param name="Validator">Validacion</param>
        /// <param name="ZTextBox">Textbox</param>
        /// <param name="writer">elemento HTML a escribir</param>
        public static void RenderExHelper(BaseValidator Validator, snipTextBox ZTextBox, HtmlTextWriter writer)
        {
            if (ZTextBox.ErrorProvider != ErrorProviderType.Text)
            {
                if (!ZTextBox.IsDesignMode || (ZTextBox.IsDesignMode && ZTextBox.RenderDesignModeValidatorIcon))
                {
                    string src = string.Empty;

                    
                    if (ZTextBox.ErrorProvider == ErrorProviderType.StillIcon)
                    {
                        src = ZTextBox.Page.ClientScript.GetWebResourceUrl(ZTextBox.GetType(), "Snip.Web.UI.TextBox.resource.errorprovider.png");
                    }
                    else if (ZTextBox.ErrorProvider == ErrorProviderType.AnimatedIcon)
                    {
                        src = ZTextBox.Page.ClientScript.GetWebResourceUrl(ZTextBox.GetType(), "Snip.Web.UI.TextBox.resource.errorprovider_anim.gif");
                    }

                    //Icono que se muestra, y se renderiza 
                    Validator.Text = "&nbsp;<img src=\"" + src + "\"" +
                                     " alt=\"" + Validator.ErrorMessage + "\"" +
                                     " title=\"" + Validator.ErrorMessage + "\"" +
                                     " />";

                   //una prueba que se realizo para personalizar alerta, no funciono
                   // RenderCallOutBox(writer,Validator.ErrorMessage, ZTextBox );
                   // RenderCallOutImage(writer,ZTextBox);


                }
            }
        }

       /// <summary>
       /// construimos del control para mostrar el mensaje
       /// </summary>
       /// <param name="writer"></param>
       /// <param name="msg"></param>
       /// <param name="MyTxt"></param>
        private static void RenderCallOutBox(HtmlTextWriter writer, string msg, snipTextBox MyTxt)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "absolute");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Top, "0px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Left, "27px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "10px");
            writer.AddStyleAttribute("padding-right", "18px");
            writer.AddStyleAttribute("border", "1px solid black");
            writer.AddStyleAttribute("font", "small Arial");
            writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "#B0C4DE");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.Write(msg); //escribo el mensaje de alerta
            RenderCloseBox(writer,MyTxt);
            writer.RenderEndTag();


        }
        /// <summary>
        ///  el CallOutImage, es una imagen que simula un gif en forma de alerta
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="MyTxt"></param>
        private static void RenderCallOutImage(HtmlTextWriter writer, snipTextBox MyTxt)
        {
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "absolute");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Top, "8px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Left, "0px");
            string src = MyTxt.Page.ClientScript.GetWebResourceUrl(MyTxt.GetType(), "Snip.Web.UI.TextBox.resource.CallOut.gif");
            writer.AddAttribute(HtmlTextWriterAttribute.Src, src);
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();

        }

        /// <summary>
        /// creo un boton para cerrar
        /// </summary>
        /// <param name="writer">el constructor writer</param>
        /// <param name="MyTxt">la instacion del control de texto</param>
        private static void RenderCloseBox(HtmlTextWriter writer, snipTextBox MyTxt)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "this.parentNode.parentNode.style.display='none';");

            writer.AddStyleAttribute(HtmlTextWriterStyle.Cursor, "hand");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "absolute");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Top, "0px");
            writer.AddStyleAttribute("right", "0px");
            string src = MyTxt.Page.ClientScript.GetWebResourceUrl(MyTxt.GetType(), "Snip.Web.UI.TextBox.resource.Close.gif");
            writer.AddAttribute(HtmlTextWriterAttribute.Src, src);
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();
        }





        /// <summary>
        /// retorna una expresion regular, los sitios siguientes se utilizaron para poder definir esta funcion
        /// esta funcion es importante dado que define las mascaras de captura de datos
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnpag2/html/PAGHT000001.asp?_r=1
        /// http://www.regular-expressions.info/floatingpoint.html
        /// http://regexlib.com/UserPatterns.aspx?authorId=81355952-f53d-4142-bc5c-aab2beae19f3
        /// </summary>
        /// <param name="enTextBoxType">Tipo de texto</param>
        /// <param name="SpecialString">Mascara o expresion regular</param>
        /// <returns></returns>
        public static string GetRegularExpression(TextBoxType enTextBoxType, string SpecialString)
        {
            string strReturnExpression = string.Empty;
            switch (enTextBoxType)
            {
                case TextBoxType.ALPHANUMERIC:
                    strReturnExpression =  @"^[a-zA-Z0-9]*$";
                    break;
                case TextBoxType.ALPHANUMERICWITHSPECIALCHAR:
                    strReturnExpression = @"^[a-zA-Z0-9" + SpecialString + "]*$";
                    break;
                case TextBoxType.NUMERICINT:
                    strReturnExpression = @"^[-+]?\d*$";
                    break;
                case TextBoxType.NUMERICINTONLYPOSITIVE:
                    strReturnExpression = @"^[+]?\d*$";
                    break;
                case TextBoxType.NUMERICDECIMAL:
                    strReturnExpression = @"[-+]?[0-9\,]*\.?[0-9]{1," + SpecialString + "}$";
                    break;
                case TextBoxType.NUMERICDECIMALONLYPOSITIVE:
                    strReturnExpression = @"[+]?[0-9\,]*\.?[0-9]{1," + SpecialString + "}$";
                    break;
                case TextBoxType.EMAIL:
                    strReturnExpression = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
                    break;
                case TextBoxType.URL:
                    strReturnExpression = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
                    break;
                case TextBoxType.USZIPCODE:
                    strReturnExpression = @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$";
                    break;
                case TextBoxType.USPHONE:
                    strReturnExpression = @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";
                    break;
               case TextBoxType.SSN:
                    strReturnExpression = @"^\d{3}-\d{2}-\d{4}$";
                    break;
                case TextBoxType.DATE:
                    if( SpecialString == DateType.MMDDYYYY.ToString() )
                        strReturnExpression = @"^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$";
                    else if (SpecialString == DateType.DDMMYYYY.ToString() )
                        strReturnExpression = @"^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$";
                    break;
                case TextBoxType.IPADDRESS:
                    strReturnExpression = @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$ ";
                    break;
                case TextBoxType.CREDITCARD:
                    strReturnExpression = @"^3(?:[47]\d([ -]?)\d{4}(?:\1\d{4}){2}|0[0-5]\d{11}|[68]\d{12})$|^4(?:\d\d\d)?([ -]?)\d{4}(?:\2\d{4}){2}$|^6011([ -]?)\d{4}(?:\3\d{4}){2}$|^5[1-5]\d\d([ -]?)\d{4}(?:\4\d{4}){2}$|^2014\d{11}$|^2149\d{11}$|^2131\d{11}$|^1800\d{11}$|^3\d{15}$ ";
                    break;
                case TextBoxType.PASSWORD:
                    strReturnExpression = @"^(([a-zA-Z0-9]+\W)){6,20}$";
                    break;
                case TextBoxType.PERCENTAGE:
                    strReturnExpression = @"(0*100{1,1}\.?((?<=\.)0*)?%?$)|(^0*\d{0,2}\.?((?<=\.)\d*)?%?)$";
                    break;
                case TextBoxType.GUID:
                    strReturnExpression = @"[{][a-fA-F0-9]{8}[-][a-fA-F0-9]{4}[-][a-fA-F0-9]{4}[-][a-fA-F0-9]{4}[-][a-fA-F0-9]{12}[}]";
                    break;
                case TextBoxType.CUSTOM:
                    strReturnExpression = SpecialString;
                    break;
                default:
                    break;
            }
            return strReturnExpression;
        }
    }
}

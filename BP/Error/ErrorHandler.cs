using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Snip.Enums;

namespace Snip.Errors
{
    public static class ErrorHandler
    {
        public static void HandleError(string msj)
        {
            string errorUrl = "~/Error/Error.aspx";
            HttpContext.Current.Session.Add("ErrorMsg", msj);
            HttpContext.Current.Response.Redirect(errorUrl);
        }
        public static string GetErrorMessage(ErrorType error, out ErrorLevel level)
        {
            string msj = string.Empty;

            switch (error)
            {
                // Errores de indole general
                case ErrorType.DatabaseError:
                    msj = Resources.Mensajes.DatabaseError;
                    level = ErrorLevel.CriticalError;
                    break;
                case ErrorType.GeneralError:
                    msj = Resources.Mensajes.GeneralError;
                    level = ErrorLevel.CriticalError;
                    break;
                case ErrorType.BadUrl:
                    msj = Resources.Mensajes.BadUrl;
                    level = ErrorLevel.ModerateError;
                    break;
                case ErrorType.PageNotFound:
                    msj = Resources.Mensajes.PageNotFound;
                    level = ErrorLevel.ModerateError;
                    break;
                // Errores especificos
                case ErrorType.NoMasterCatalog:
                    msj = Resources.Mensajes.NoMasterCatalog;
                    level = ErrorLevel.SlightError;
                    break;
                default:
                    msj = Resources.Mensajes.GeneralError;
                    level = ErrorLevel.CriticalError;
                    break;
            }

            return msj;
        }
    }
}
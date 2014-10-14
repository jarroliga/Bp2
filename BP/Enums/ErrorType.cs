using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snip.Enums
{
    public enum ErrorType
    {
        // Errores generales
        DatabaseError = 100,
        GeneralError,
        PageNotFound,
        BadUrl,
        // Especificos
        NoMasterCatalog
    }
}
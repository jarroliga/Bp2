using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.App
{
    public class Filtro
    {
        #region Propiedades

        public int CodSession { get; set; }
        public TipoFiltro TipoFiltro { get; set; }
        public string Expresion { get; set; }

        #endregion
    }
}

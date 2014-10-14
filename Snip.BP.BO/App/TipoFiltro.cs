using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.App
{
    public class TipoFiltro : BusinessBase
    {
        #region Propiedades

        public override int Codigo { get; set; }

        public string IdFiltro { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        #endregion
    }
}

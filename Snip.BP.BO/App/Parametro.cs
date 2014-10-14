using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.App
{
    public class Parametro : BusinessBase
    {
        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "DescripcionNotNullOrEmpty")]
        public string Descripcion { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string IdParametro { get; set; }

        [NotNullOrEmpty(Key = "ValorNotNullOrEmpty")]
        public string ValorParametro { get; set; }

        public bool Activo { get; set; }

        public Aplicacion Aplicacion { get; set; }

        #endregion
    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class UnidadEjecutora : BusinessBase
    {
        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        public string Siglas { get; set; }

        public bool Activo { get; set; }

        public int CodEntidadSigfa { get; set; }

        public Institucion Institucion { get; set; }

        #endregion
    }
}

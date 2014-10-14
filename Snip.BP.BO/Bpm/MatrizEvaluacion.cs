using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Dm;

namespace Snip.BP.BO.Bpm
{
    public class MatrizEvaluacion : BusinessBase
    {
        public MatrizEvaluacion()
        {
        }

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string IdMatrizEvaluacion { get; set; }

        #endregion

    }
}

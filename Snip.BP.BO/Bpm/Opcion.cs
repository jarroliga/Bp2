using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Dm;

namespace Snip.BP.BO.Bpm
{
    public class Opcion : BusinessBase
    {
        public Opcion()
        {
        }

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        public string IdOpcion { get; set; }

        public bool Activa { get; set; }

        public Pregunta Pregunta { get; set; }

        #endregion

    }
}

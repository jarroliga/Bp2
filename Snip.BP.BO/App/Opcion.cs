using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.App
{
    public class Opcion : BusinessBase
    {
                #region Constructor(es)

        public Opcion()
        {
            Perfiles = new PerfilOpcionCollection();
        }

        #endregion

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string IdOpcion { get; set; }

        public bool Activa { get; set; }

        public Aplicacion Aplicacion { get; set; }

        public PerfilOpcionCollection Perfiles { get; set; }

        #endregion
    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.App
{
    public class PerfilOpcion
    {
        #region Propiedades Públicas

        public PerfilOpcion()
        {
            Opcion = new Opcion();
        }

        public Opcion Opcion { get; set; }

        public int CodPerfil { get; set; }
        
        public int CodOpcion
        {
            set { Opcion.Codigo = value; }
            get { return Opcion.Codigo; }
        }

        #endregion
    }
}

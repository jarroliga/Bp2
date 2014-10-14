using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.App
{
    public class PerfilTransicionEstado
    {
        #region Propiedades Públicas

        public int CodPerfil { get; set; }
        public TransicionEstado TransicionEstado { get; set; }

        #endregion
    }
}

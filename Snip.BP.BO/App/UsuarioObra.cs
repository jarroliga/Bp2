using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;
using System.Collections.Generic;

namespace Snip.BP.BO.App
{
    public class UsuarioObra
    {

        #region Propiedades Públicas

        public int CodUsuario { get; set; }
        public Obra Obra { get; set; }
        public bool Editable { get; set; }

        #endregion
    }
}

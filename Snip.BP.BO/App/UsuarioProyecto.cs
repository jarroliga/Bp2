using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;
using System.Collections.Generic;

namespace Snip.BP.BO.App
{
    public class UsuarioProyecto
    {
        #region Propiedades Públicas

        public int CodUsuario { get; set; }
        public Proyecto Proyecto { get; set; }
        public bool EsEditable { get; set; }

        #endregion
    }
}

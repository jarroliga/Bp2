using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// 
    /// </summary>
    public class TipoObjeto : BusinessBase
    {
        public TipoObjeto()
        {
        }

        public override int Codigo { get; set; }

        public string Nombre { get; set; }

    }
}

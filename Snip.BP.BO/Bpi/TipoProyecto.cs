using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bpi
{
    public class TipoProyecto : BusinessBase
    {
        public TipoProyecto()
        {
        }

        public override int Codigo { get; set; }

        public string Nombre { get; set; }

    }
}

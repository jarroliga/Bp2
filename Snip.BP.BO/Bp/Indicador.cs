using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class Indicador : BusinessBase
    {
        public Indicador()
        {
        }

        public override int Codigo { get; set; }

        public string Nombre { get; set; }

        public string Siglas { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class TipoDictamen : BusinessBase
    {
        public TipoDictamen()
        {
        }

        public override int Codigo { get; set; }

        public string Nombre { get; set; }

    }
}

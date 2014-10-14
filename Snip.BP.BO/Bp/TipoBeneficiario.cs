using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class TipoBeneficiario : BusinessBase
    {
        public TipoBeneficiario()
        {
            TipoBeneficiarioP = null;
        }

        public override int Codigo { get; set; }

        public TipoBeneficiario TipoBeneficiarioP { get; set; }

        public string Nombre { get; set; }

    }
}

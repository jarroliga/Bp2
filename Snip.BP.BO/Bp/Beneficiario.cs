using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class Beneficiario : BusinessBase
    {
        public Beneficiario()
        {
            CategoriaBeneficiario = null;
        }

        public override int Codigo { get; set; }

        public CategoriaBeneficiario CategoriaBeneficiario { get; set; }

        public string Nombre { get; set; }

    }
}

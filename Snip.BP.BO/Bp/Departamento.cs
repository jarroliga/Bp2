using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bp
{
    public class Departamento : BusinessBase 
    {
        public Departamento()
        {
            
        }

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        public string IdDepartamento { get; set; }

        public string Nombre { get; set; }
    }
}

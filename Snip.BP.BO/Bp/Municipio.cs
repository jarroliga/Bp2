using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bp
{
    public class Municipio : BusinessBase 
    {

        public Municipio()
        {
            Departamento = new Departamento();
        }

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        public string IdMunicipio { get; set; }

        public string Nombre { get; set; }

        public Departamento Departamento { get; set; }
    }
}

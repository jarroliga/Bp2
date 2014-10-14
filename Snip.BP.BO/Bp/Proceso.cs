using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class Proceso : BusinessBase
    {
        public Proceso()
        {
            NaturalezaProceso = new NaturalezaProceso();
        }

        public override int Codigo { get; set; }

        public NaturalezaProceso NaturalezaProceso { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

    }
}

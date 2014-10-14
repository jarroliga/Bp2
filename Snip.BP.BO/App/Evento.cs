using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.App
{
    public class Evento : BusinessBase
    {
        public Evento()
        {
        }
        public override int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Identificador { get; set; }
        public string Descripcion { get; set; }
    }
}

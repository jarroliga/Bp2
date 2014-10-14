using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Bp;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bpp
{
    public class Sesion : BusinessBase
    {
        public Sesion()
        {
            Traslados = new TrasladoCollection();
        }

        public override int Codigo { get; set; }
        public int Anio { get; set; }
        public string IdSesion { get; set; }
        public DateTime Fecha { get; set; }
        public string Introduccion { get; set; }
        public string Desarrollo { get; set; }
        public string Acuerdos { get; set; }
        public string Observaciones { get; set; }

        public TrasladoCollection Traslados { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Enums;

namespace Snip.BP.BO.Dm
{
    public class PipAnual
    {
        public int Anio { get; set; }
        public decimal Asignado { get; set; }
        public decimal AsignadoRecursosInternos { get; set; }
        public decimal AsignadoRecursosExternos { get; set; }
        public decimal Actualizado { get; set; }
        public decimal ActualizadoRecursosInternos { get; set; }
        public decimal ActualizadoRecursosExternos { get; set; }
        public decimal Ejecutado { get; set; }
        public decimal EjecutadoRecursosInternos { get; set; }
        public decimal EjecutadoRecursosExternos { get; set; }
    }
}

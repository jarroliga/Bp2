using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Enums;

namespace Snip.BP.BO.Dm
{
    public class PipEstructuraFinanciamiento
    {
        public PipEstructuraFinanciamiento()
        {
            Asignado = new OrigenFondo();
            Modificado = new OrigenFondo();
            Actualizado = new OrigenFondo();
            Ejecutado = new OrigenFondo();
        }

        public int Anio { get; set; }
        public int IdTipoEntidad { get; set; }
        public string TipoEntidad { get; set; }

        public OrigenFondo Asignado { get; set; }
        public OrigenFondo Modificado { get; set; }
        public OrigenFondo Actualizado { get; set; }
        public OrigenFondo Ejecutado { get; set; }

        public decimal TasaCambio { get; set; }
    }
}

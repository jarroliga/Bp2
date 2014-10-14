using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Dm
{
    public class PipDistribucionByEntidad
    {
        public int Anio { get; set; }
        public int IdTipoEntidad { get; set; }
        public string TipoEntidad { get; set; }
        public string IdOrigenFondo { get; set; }
        public string OrigenFondo { get; set; }
        public decimal Programado { get; set; }
        public decimal PesoProgramado { get; set; }
        public decimal Ejecutado { get; set; }
        public decimal PorcentajeEjecutado { get; set; }
        public decimal TasaCambio { get; set; }
        public bool InicioGrupo { get; set; }
    }
}

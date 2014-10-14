using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpi
{
    public class Actividad : BusinessBase
    {
        public Actividad()
        {
            Componente = new Componente();
            Componentes = new ComponenteCollection();
        }

        public override int Codigo { get; set; }

        public int CodActividad
        {
            get { return Codigo; }
        }

        public Componente Componente { get; set; }

        public int CodComponente
        {
            get { return Componente.Codigo; }
            set { Componente.Codigo = value; }
        }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "FechaInicioNotEmpty")]
        public DateTime FechaInicio { get; set; }        
        
        public DateTime FechaFinalizacion { get; set; }

        [ValidRange(Key = "MontoNotZeroOrNegative", Max = 9999999999.99, Min = 1)]
        public decimal CostoEstimado { get; set; }

        public ComponenteCollection Componentes { get; set; }

        public ActividadCostoCollection ActividadCostos { get; set; }

    }
}

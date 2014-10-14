using System;
using System.Collections.Generic;
using System.Text;

using Snip.BP.BO.App;

namespace Snip.BP.BO.Bps
{
    public class Contrato : BusinessBase
    {
        public override int Codigo { get; set; }
        
        public Licitacion Licitacion {get; set;}
        public Contratista Contratista { get; set; }

        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        public DateTime FechaFirma { get; set; }
        public DateTime FechaInicioPrevista { get; set; }
        public DateTime FechaFinPrevista { get; set; }
        public DateTime FechaInicioReal { get; set; }
        public DateTime FechaFinReal { get; set; }

        public Decimal CostoInicial { get; set; }
        public Decimal CostoVariaciones { get; set; }
        public Decimal CostoActualizado { get; set; }

        public Decimal MontoAdelanto { get; set; }
        public Decimal PorcentajeAmortizacion { get; set; }

        public Estado Estado { get; set; }
        public Estado Etapa { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;
using Snip.BP.BO.Bps;

namespace Snip.BP.BO.Rpt
{
    public class RptTemporal
    {
        public int CodInstitucion { get; set; }
        public string Institucion { get; set; }
        public string Siglas { get; set; }

        public int CodProyP { get; set; }
        public string CodSnipP { get; set; }
        public string Proyecto { get; set; }

        public int CodProy { get; set; }
        public string CodSnip { get; set; }
        public string Obra { get; set; }

        public int CodContrato { get; set; }
        public string IdContrato { get; set; }
        public string Contrato { get; set; }
        public string TipoContrato { get; set; }
        public string ModalidadEjecucion { get; set; }
        
        public decimal CostoInicial { get; set; }
        public decimal CostoVariaciones { get; set; }
        public decimal CostoActualizado { get; set; }

        public DateTime FechaInicioProgramada { get; set; }
        public DateTime FechaFinProgramada { get; set; }
        public int PlazoProgramadoDias { get; set; }
        public DateTime FechaInicioOficial { get; set; }
        public DateTime FechaFinActualizada { get; set; }
        public int PlazoRealDias { get; set; }
        public int DiferenciaPlazos { get; set; }

        public int Reprogramaciones { get; set; }

    }
}

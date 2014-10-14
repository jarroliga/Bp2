using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Rpt
{
    public class RptLicitacion109
    {
        public int Anio { get; set; }
        public int CodInstitucion { get; set; }
        public string Institucion { get; set; }
        public string Siglas { get; set; }
        public int CodLicitacion { get; set; }
        public int CodLicitacionReprogramacion { get; set; }
        public int IdTipoReprogramacion { get; set; }
        public string TipoReprogramacion { get; set; }
        public string IdLicitacion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFirmaOriginal { get; set; }
        public DateTime FechaFirmaProgramada { get; set; }
        public DateTime FechaFirmaReprogramada { get; set; }
        public int VariacionDias { get; set; }
        public string IdReferencia { get; set; }
        public string Justificacion { get; set; }
        public string ObservacionesDGIP {get; set;}
        public DateTime FechaSolicitud { get; set; }
        public string SolicitadoPor { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public string AprobadoPor { get; set; }
        public int Duracion { get; set; }
    }
}

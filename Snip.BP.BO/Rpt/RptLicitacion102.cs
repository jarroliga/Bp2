using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;
using Snip.BP.BO.Bps;

namespace Snip.BP.BO.Rpt
{
    public class RptLicitacion102
    {
        public int CodInstitucion {get; set;}
        public string Institucion { get; set; }
        public string Siglas { get; set; }
        public string IdTipo { get; set; }
        public int CodLicitacion { get; set; }
        public int Anio { get; set; }
        public string IdLicitacion { get; set; }
        public string Nombre { get; set; }
        public int CodEstado { get; set; }
        public string Estado { get; set; }
        public int CodEtapa { get; set; }
        public string Etapa { get; set; }
        public DateTime? Etapa1P { get; set; }
        public DateTime? Etapa1C { get; set; }
        public DateTime? Etapa2P { get; set; }
        public DateTime? Etapa2C { get; set; }
        public DateTime? Etapa3P { get; set; }
        public DateTime? Etapa3C { get; set; }
        public DateTime? Etapa4P { get; set; }
        public DateTime? Etapa4C { get; set; }
        public DateTime? Etapa5P { get; set; }
        public DateTime? Etapa5C { get; set; }
        public DateTime? Etapa6P { get; set; }
        public DateTime? Etapa6C { get; set; }
        public int Iniciada { get; set; }
        public int NoIniciada { get; set; }
        public int Cancelada { get; set; }
        public int Desierta { get; set; }
        public int CodProyecto { get; set; }
        public string CodSnipP { get; set; }
        public string Proyecto { get; set; }
        public int CodObra { get; set; }
        public string CodSnip { get; set; }
        public string Obra { get; set; }
        public decimal Programado { get; set; }
        public decimal ProgramadoPeriodo { get; set; }

    }
}

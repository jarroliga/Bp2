using System;
using System.Collections.Generic;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bps
{
    public class AlertaEtapa
    {
        public AlertaEtapa()
        {
        }
        
        public Licitacion Licitacion { get; set; }

        public int CodLicitacion
        {
            get { return Licitacion.Codigo; }
            set { Licitacion.Codigo = value; }
        }

        public UnidadEjecutora UnidadEjecutora { get; set; }
        public Estado EtapaVencida { get; set; }
        public DateTime FechaFinProgramada { get; set; }
        public DateTime FechaFinReprogramada { get; set; }
        public int DiasVencidos { get; set; }
        public Usuario Usuario { get; set; }
    }
}

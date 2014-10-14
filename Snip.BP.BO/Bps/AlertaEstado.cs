using System;
using System.Collections.Generic;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bps
{
    public class AlertaEstado
    {
        public AlertaEstado()
        {
            TipoAlerta = null;
        }
        public TipoAlerta TipoAlerta {get; set;}

        public Licitacion Licitacion { get; set; }

        public int CodLicitacion
        {
            get { return Licitacion.Codigo; }
            set { Licitacion.Codigo = value; }
        }

        public Obra Obra { get; set; }

        public int CodObra
        {
            get { return Obra.Codigo; }
            set { Obra.Codigo = value; }
        }

        public UnidadEjecutora UnidadEjecutora { get; set; }
        public Estado Estado { get; set; }
        //public DateTime UltimaActualizacion { get; set; }
        public Usuario Usuario { get; set; }

    }
}

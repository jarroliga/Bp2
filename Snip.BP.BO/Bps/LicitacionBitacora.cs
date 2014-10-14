using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bps
{
    public class LicitacionBitacora : BusinessBase
    {
              
        public LicitacionBitacora()
        {
            Licitacion = new Licitacion();
            Estado = new Estado();
            Etapa = new Estado();
            Usuario = new Usuario();
        }
        public override int Codigo { get; set; }

        public Licitacion Licitacion { get; set; }

        public Estado Estado { get; set; }

        public Estado Etapa { get; set; }

        public int CodLicitacion 
        {
            get { return Licitacion.Codigo; }
            set { Licitacion.Codigo = value; } 
        }

        public int CodEstado 
        {
            get { return Estado.Codigo; }
            set { Estado.Codigo = value; }
        }
        public int CodEtapa
        {
            get { return Etapa.Codigo; }
            set { Etapa.Codigo = value; }
        }

        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

        public Usuario Usuario { get; set; }

        public int CodUsuario
        {
            get { return Usuario.Codigo; }
            set { Usuario.Codigo = value; }
        }

    }
}

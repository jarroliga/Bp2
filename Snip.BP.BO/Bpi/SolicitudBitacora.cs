using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bpi
{
    public class SolicitudBitacora : BusinessBase
    {
              
        public SolicitudBitacora()
        {
            Estado = new Estado();
            Usuario = new Usuario();
        }

        public override int Codigo { get; set; }

        public int CodSolicitud { get; set; }

        public Estado Estado { get; set; }

       public int CodEstado 
        {
            get { return Estado.Codigo; }
            set { Estado.Codigo = value; }
        }

        public DateTime Fecha { get; set; }

        public string Comentarios { get; set; }

        public int Eventos { get; set; }

        public Usuario Usuario { get; set; }

        public int CodUsuario
        {
            get { return Usuario.Codigo; }
            set { Usuario.Codigo = value; }
        }

    }
}

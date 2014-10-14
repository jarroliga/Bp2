using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpi
{
    public class SolicitudPrograma
    {
        public SolicitudPrograma()
        {
            Solicitud = new Solicitud();
            Programa = new Programa();
        }

        public Solicitud Solicitud { get; set; }

        public int CodSolicitud
        {
            get { return Solicitud.Codigo; }
            set { Solicitud.Codigo = value; }
        }

        public Programa Programa { get; set; }

        public int CodPrograma
        {
            get { return Programa.Codigo; }
            set { Programa.Codigo = value; }
        }

    }
}

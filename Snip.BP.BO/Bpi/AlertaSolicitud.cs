using System;
using System.Collections.Generic;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bpi
{
    public class AlertaSolicitud
    {
        public AlertaSolicitud()
        {
            TipoAlerta = null;
        }

        public TipoAlerta TipoAlerta { get; set; }

        public int CodTipoAlerta
        {
            get { return TipoAlerta.Codigo; }
            set { TipoAlerta.Codigo = value; }
        }

        public Solicitud Solicitud { get; set; }

        public int CodSolicitud
        {
            get { return Solicitud.Codigo; }
            set { Solicitud.Codigo = value; }
        }

    }
}

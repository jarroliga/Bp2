using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class Intervencion : BusinessBase
    {
        public Intervencion()
        {
            Sector = null;
            Proceso = null;
            TipoObjeto = null;
            Indicador = null;
        }

        public override int Codigo { get; set; }

        public Sector Sector { get; set; }

        public Proceso Proceso { get; set; }

        public TipoObjeto TipoObjeto { get; set; }

        public Indicador Indicador { get; set; }
        
        public string Nombre { get; set; }


    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bpi
{
    public class SolicitudDocumento : BusinessBase
    {
              
        public SolicitudDocumento()
        {
        }

        public override int Codigo { get; set; }

        public int CodDocumento
        {
            get { return Codigo; }
        }

        public int CodSolicitud { get; set; }

        public int CodTipoDocumento { get; set; }

        public string Ruta { get; set; }

        public int Version { get; set; }

        public string Archivo { get; set; }

        public string ArchivoGUID { get; set; }
        
        public DateTime FechaCarga { get; set; }

        public int CodUsuario { get; set; }
    }
}

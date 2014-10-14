using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Bp;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bpp
{
    /// <summary>
    /// La clase Traslado representa una solicitud de traslado que es objeto de revisión y aprobación por el CTI.
    /// </summary>
    public class Traslado : BusinessBase
    {
        #region Constructores

        public Traslado()
        {
            Institucion = new Institucion();
            FuenteSigfa = new FuenteSIGFA();
            EstadoSolicitud = new Estado();
            Partidas = new TrasladoPartidaCollection(); 
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }

        public string IdTraslado { get; set; }
        public int Anio { get; set; }

        public Institucion Institucion { get; set; }
        public FuenteSIGFA FuenteSigfa { get; set; }
        
        public Estado EstadoSolicitud { get; set; }

        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaRevision { get; set; }
        public DateTime? FechaAprobacion { get; set; }

        public string Justificacion { get; set; }
        public string CausaRechazo { get; set; }

        public decimal MontoSolicitado { get; set; }
        public decimal MontoAprobado { get; set; }

        public decimal Porcentaje { get; set; }

        public TrasladoPartidaCollection Partidas { get; set; }

        #endregion
    }
}

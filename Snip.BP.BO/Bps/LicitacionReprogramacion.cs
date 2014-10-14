using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bps
{
    public class LicitacionReprogramacion : BusinessBase
    {
        public LicitacionReprogramacion()
        {
            Licitacion = new Licitacion();
            EstadoSolicitud = new Estado();
            UsuarioSolicitud = new Usuario();
            UsuarioAprobacion = new Usuario();
            ObrasReprogramadas = new LicitacionObraReprogramacionCollection();
        }

        public override int Codigo {get; set; }

        public Licitacion Licitacion { get; set; }

        public int CodLicitacion
        {
            get { return Licitacion.Codigo; }
            set { Licitacion.Codigo = value; }
        }

        public Estado EstadoSolicitud { get; set; }

        public int IdTipoReprogramacion { get; set; }

        public string TipoReprogramacion
        {
            get
            {
                return (IdTipoReprogramacion == 1 ? "Reprogramación Fecha de Firma" : "Ajuste Financiero");
            }
        }

        public string IdReferencia { get; set; }

        public DateTime FechaInicioProgramada { get; set; }

        public DateTime FechaFinProgramada { get; set; }

        public DateTime FechaInicioReprogramada { get; set; }

        public DateTime FechaFinReprogramada { get; set; }

        public string Justificacion { get; set; }

        public string ObservacionesDGIP { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public Usuario UsuarioSolicitud { get; set; }

        public DateTime? FechaAprobacion { get; set; }

        public Usuario UsuarioAprobacion { get; set; }

        public LicitacionObraReprogramacionCollection ObrasReprogramadas { get; set; }
    }
}

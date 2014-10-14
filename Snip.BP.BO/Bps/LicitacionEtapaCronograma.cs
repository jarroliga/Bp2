using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bps
{
    /// <summary>
    /// La clase LicitacionEtapaCronograma representa una etapa del cronograma de un 
    /// proceso de licitación.
    /// </summary>
    public class LicitacionEtapaCronograma
    {
        public LicitacionEtapaCronograma()
        {
            Licitacion = new Licitacion();
            Etapa = new Estado();
            FechaRegistro = DateTime.Now;
            FechaActualizacion = DateTime.Now;
        }

        public Licitacion Licitacion { get; set; }

        public int CodLicitacion
        {
            get { return Licitacion.Codigo; }
        }

        public int CodEtapa
        {
            get { return Etapa.Codigo; }
            set { Etapa.Codigo = value; }
        }

        public Estado Etapa { get; set; }

        public DateTime? FechaFinProgramada { get; set; }

        public DateTime? FechaFinReprogramada { get; set; }

        public DateTime? FechaFinCumplimiento { get; set; }

        public string ObservacionesUSIP { get; set; }

        public string ObservacionesDGIP { get; set; }

        public bool Completada { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int CodUsuarioRegistro { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public int CodUsuarioActualizacion { get; set; }

        #region Propiedades de control

        public DateTime? FechaMin { get; set; }

        public DateTime? FechaMax { get; set; }
        
        #endregion

    }
}

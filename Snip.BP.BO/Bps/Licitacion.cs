using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bps
{   
    /// <summary>
    /// La clase Licitacion representa un proceso de licitación para la contratació de obras y/o actividades de un proyecto
    /// </summary>
    [DebuggerDisplay("Licitacion: {Nombre, nq} No: ({IdLicitacion, nq})")]
    public class Licitacion : BusinessBase
    {
        #region Constructores

        public Licitacion()
        {
            UnidadEjecutora = new UnidadEjecutora();
            Estado = new Estado();
            Etapa = new Estado();
            ModificacionesFechaFirma = 0;
            Activa = true;
            Multiple = false;

            FechaInicio = DateTime.Today;
            Cronograma = new LicitacionEtapaCronogramaCollection();
            Bitacora = new LicitacionBitacoraCollection();
            ObrasProgramadas = new LicitacionObraCollection();
            Reprogramaciones = new LicitacionReprogramacionCollection();
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Código de la Licitación
        /// </summary>
        public override int Codigo { get; set; }

        [ValidRange(Message="Debe digitar el año.",Max=2024,Min=2011)]
        public int Anio { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string IdLicitacion { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [NotNullOrEmpty(Key = "FechaInicioNotEmpty")]
        public DateTime FechaInicio { get; set; }

        [ValidRange(Key = "MontoNotZeroOrNegative", Max = 9999999999.99, Min = 1)]
        public decimal Costo { get; set; }

        public int ModificacionesFechaFirma { get; set; }

        public Estado Estado { get; set; }

        public Estado Etapa { get; set; }

        public bool Activa { get; set; }

        public bool Multiple { get; set; }

        public UnidadEjecutora UnidadEjecutora { get; set; }

        public LicitacionEtapaCronogramaCollection Cronograma { get; set; }

        public LicitacionBitacoraCollection Bitacora { get; set; }

        public LicitacionReprogramacionCollection Reprogramaciones { get; set; }

        public LicitacionObraCollection ObrasProgramadas { get; set; }

        public bool Editable { get; set; }

        public string Observaciones { get; set; }

        #endregion

    }
}

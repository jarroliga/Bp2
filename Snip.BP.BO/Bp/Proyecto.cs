using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase Proyecto representa un proyecto de inversión del Banco de Proyectos
    /// </summary>
    public class Proyecto : BusinessBase
    {
        #region Campos

        #endregion

        #region Constructores

        public Proyecto()
        {
            UnidadEjecutora = new UnidadEjecutora();
            Sector = new Sector();
            // Un proyecto tiene asociado una coleccion de obras o actividades
            Obras = new ObraCollection();
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }

        [NotNullOrEmpty(Message = "Debe digitar el código SNIP del Proyecto")]
        public string CodSnip { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        public DateTime? FechaInicioPrevista { get; set; }

        public DateTime? FechaInicioReal { get; set; }

        public DateTime? FechaFinPrevista { get; set; }

        public DateTime? FechaFinReal { get; set; }

        public UnidadEjecutora UnidadEjecutora { get; set; }

        public Sector Sector { get; set; }

        public string Siglas
        {
            get { return UnidadEjecutora.Siglas; }
        }

        public ObraCollection Obras { get; set; }

        public ProyectoFicha ProyectoFicha { get; set; }

        public Estado Etapa { get; set; }

        public string Etiqueta
        {
            get { return CodSnip + " - " + Nombre; }
        }

        #endregion


    }
}

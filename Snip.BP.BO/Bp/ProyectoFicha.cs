using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase ProyectoFicha representa la ficha de datos generales del proyecto
    /// </summary>
    public class ProyectoFicha
    {
        #region Constructores

        public ProyectoFicha()
        {
        }

        #endregion

        #region Propiedades

        public int CodProyecto {get; set;}

        public string Descripcion {get; set;}

        public string ObjetivosEspecificos {get; set;}

        public string ObjetivosDesarrollo { get; set; }

        public string Justificacion {get; set;}

        public string AspectosOperativos { get; set; }

        public string Beneficios { get; set; }

        #endregion
    }
}

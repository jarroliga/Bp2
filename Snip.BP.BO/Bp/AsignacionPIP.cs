using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase AsignacionPIP representa la asignación de recursos anual que tiene asociada una obra o actividad, se incluyen como
    /// propiedades los porcentajes en que se distribuye dicha asignación de acuerdo al origen de los fondos.
    /// </summary>
    public class AsignacionPIP
    {
        #region Constructores

        public AsignacionPIP()
        {
            IdPip = 7;
            IdMomento = 2;
            Asignado = 0M;
        }

        #endregion

        #region Propiedades

        public int CodObra {get; set;}

        public int IdPip { get; set; }

        public int IdMomento { get; set; }

        [ValidRange(Message = "Debe digitar el año.", Max = 2044, Min = 1989)]
        public int Anio {get; set;}
        
        public decimal Asignado {get; set;}

        public decimal AsignadoPrestamo { get; set; }

        public decimal PorcentajePrestamo { get; set; }

        public decimal AsignadoDonacion { get; set; }

        public decimal PorcentajeDonacion { get; set; }

        public decimal AsignadoTesoro { get; set; }

        public decimal PorcentajeTesoro { get; set; }

        public decimal AsignadoRecursosPropios { get; set; }

        public decimal PorcentajeRecursosPropios { get; set; }

        #endregion
    }
}

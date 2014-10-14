using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpm
{
    public class ProyectoEvaluacion : BusinessBase 
    {
        public ProyectoEvaluacion()
        {
            MatrizEvaluacion = new MatrizEvaluacion();
            Proyecto = new Proyecto();
            Estado = new Estado();
        }

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        public Proyecto Proyecto { get; set; }

        public MatrizEvaluacion MatrizEvaluacion { get; set; }

        public DateTime FechaEvaluacion {get; set;}

        public decimal Calificacion {get; set;}

        public Estado Estado { get; set; }

        #endregion

    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Dm;

namespace Snip.BP.BO.Bpm
{
    public class Respuesta : BusinessBase 
    {
        public Respuesta()
        {
            Opcion = new Opcion();
        }

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        public Opcion Opcion { get; set; }

        public decimal Valor { get; set; }

        public string Observaciones { get; set; }

        public ProyectoEvaluacion ProyectoEvaluacion { get; set; }

        #endregion

        
        
    }
}

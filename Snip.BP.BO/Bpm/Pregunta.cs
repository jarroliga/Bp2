using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Dm;

namespace Snip.BP.BO.Bpm
{
    public class Pregunta : BusinessBase
    {
        public Pregunta()
        {
            Seccion = new Seccion();
        }

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        public string IdPregunta { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")] 
        public string Nombre { get; set; }
        
        public string Ayuda { get; set; }

        public Seccion Seccion { get; set; }
        
        #endregion

        
       
    }
}

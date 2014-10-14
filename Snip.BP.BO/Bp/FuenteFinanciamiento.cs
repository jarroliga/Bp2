using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase FuenteFinanciamiento representa el origen de los fondos, si el origen de los mismos es externo o interno. Equivale a una combinación CatModalidad
    /// </summary>
    public class FuenteFinanciamiento : BusinessBase
    {
        #region Constructores

        public FuenteFinanciamiento()
        {
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Código de la Fuente de Financiamiento
        /// </summary>
        public override int Codigo { get; set; }

        public string Nombre { get; set; }
        public int IdFuenteFinanciamiento { get; set; }
        public bool Externa { get; set; }
        public bool Activa { get; set; }        

        #endregion

    }
}

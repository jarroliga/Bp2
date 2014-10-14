using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase TipoOrganismoFinanciador representa el tipo de Organismo del que se recibirá financiamiento.
    /// </summary>
    public class TipoOrganismoFinanciador : BusinessBase
    {
        #region Constructores

        public TipoOrganismoFinanciador()
        {
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Código de la Fuente de Financiamiento
        /// </summary>
        public override int Codigo { get; set; }

        public int IdTipoOrganismoFinanciador { get; set; }
        public string Nombre { get; set; }
        public bool Externo { get; set; }
        public bool Activo { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Bp
{
    public class OrganismoFinanciador : BusinessBase 
    {
        #region Constructores

        public OrganismoFinanciador()
        {
            TipoOrganismoFinanciador = new TipoOrganismoFinanciador();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Código del Organismo Financiador
        /// </summary>
        public override int Codigo { get; set; }

        public TipoOrganismoFinanciador TipoOrganismoFinanciador { get; set; }
        public int IdOrganismoFinanciador { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int CodFuenteAnterior { get; set; }
        
        #endregion
    }
}

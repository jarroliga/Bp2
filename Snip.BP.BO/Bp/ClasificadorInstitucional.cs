using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class ClasificadorInstitucional : BusinessBase
    {

        public ClasificadorInstitucional()
        {
            ClasificadorInstitucionalPadre = null;
        }

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        public string IdClasificadorInstitucional { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Nivel { get; set; }

        public bool Activo { get; set; }

        #endregion

        public ClasificadorInstitucional ClasificadorInstitucionalPadre { get; set; }
        
    }
}

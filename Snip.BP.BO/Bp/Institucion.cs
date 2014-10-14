using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Dm;

namespace Snip.BP.BO.Bp
{
    public class Institucion : BusinessBase
    {
        public Institucion()
        {
            ClasificadorInstitucional = new ClasificadorInstitucional();
            PresupuestoAnio = new PipInstitucion();
        }

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        public string IdInstitucion { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "NotNullOrEmpty")]
        public string Siglas { get; set; }

        public string Etiqueta { get; set; }

        public string IdTipo { get; set; }

        public bool Activo { get; set; }

        public int CodInstitucionAnterior { get; set; }

        public PipInstitucion PresupuestoAnio { get; set; }

        #endregion

        public ClasificadorInstitucional ClasificadorInstitucional  { get; set; }
        
    }
}

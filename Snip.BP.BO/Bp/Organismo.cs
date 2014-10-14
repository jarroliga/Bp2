using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase Organismo representa un organismo o pais financiador
    /// </summary>
    public class Organismo : BusinessBase
    {
        #region Constructores

        public Organismo()
        {
            Activo = true;
        }
        #endregion

        # region Propiedades

        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        public string NombreIngles { get; set; }

        [NotNullOrEmpty(Key = "SiglasNotNullOrEmpty")]
        public string Siglas { get; set; }

        [NotNullOrEmpty(Message = "Debe digitar el Tipo de Organismo")]
        public int IdTipoOrganismo { get; set; }

        public string ISO { get; set; }

        public string ISO3 { get; set; }

        public int ISONum { get; set; }

        public bool Activo { get; set; }

        # endregion
    }
}

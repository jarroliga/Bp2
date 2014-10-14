using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase Fuente representa el origen de los fondos de financiamiento, si son recursos externos, internos, prestamos o donaciones, etc.
    /// (Mapea temporalmente a CatModalidad)
    /// </summary>
    public class Fuente : BusinessBase
    {
        #region Constructores

        public Fuente()
        {
            Activo = true;
        }

        #endregion

        # region Propiedades

        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre {get; set;}

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string IdFuente {get; set;}

        public string IdFuenteNombre {get; set;}

        public bool Activo {get; set;}

        #endregion

    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.App
{
    /// <summary>
    /// La clase Aplicacion representa una aplicación o módulo del Banco de Proyectos SNIP
    /// </summary>
    [DebuggerDisplay("Aplicación: {Nombre, nq} {IdAplicacion, nq}")]
    public class Aplicacion : BusinessBase
    {
        #region Constructores

        public Aplicacion()
        {
        }
        #endregion

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, false, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string IdAplicacion { get; set; }
        
        #endregion
    }
}

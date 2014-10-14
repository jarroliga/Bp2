using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase Agencia representa la agencia de un determinado organismos de financiamiento (mapea a CatFuente)
    /// </summary>
    public class Agencia : BusinessBase
    {
        #region Constructores

        public Agencia()
        {
            Organismo = new Organismo();
            Activa = true;
        }

        #endregion

        # region Propiedades

        /// <summary>
        /// Código de la Agencia
        /// </summary>
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre {get; set;}

        [NotNullOrEmpty(Key = "SiglasNotNullOrEmpty")]
        public string Siglas {get; set;}

        public bool Activa {get; set;}

        public Organismo Organismo {get; set;}

        public int CodOrganismo 
        { 
            get { return Organismo.Codigo; } 
            set { Organismo.Codigo = value; } 
        }
        # endregion
    }
}

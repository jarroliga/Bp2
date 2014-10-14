using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class Entidad : BusinessBase
    {
        #region Atributos

        private Entidad entidadPadre;
        private EntidadCollection entidadesSubordinadas;

        #endregion

        #region Constructor(es)

        public Entidad()
        {
            this.entidadPadre = null;
            this.entidadesSubordinadas = new EntidadCollection();
        }
        #endregion

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        public string Siglas { get; set; }

        public string Etiqueta { get; set; }

        public int Nivel { get; set; }

        public string IdTipo { get; set; }

        public string CodInstitucionAnterior { get; set; }

        public int? CodGabinete { get; set; }

        public int? CodEntidadSigfa { get; set; }

        public int? CodProgramaSigfa { get; set; }

        public int? CodEntidadSigfita { get; set; }

        public int? CodProgramaSigfita { get; set; }

        public int Presupuestal { get; set; }

        public bool Activo { get; set; }

        public int CodExterno { get; set; }

        public string Descripcion
        {
            get { return this.Siglas + " - " + this.Nombre; }
        }
        public Entidad EntidadPadre 
        {
            get
            {
                if (this.entidadPadre == null)
                    this.entidadPadre = new Entidad();
                return this.entidadPadre;
            }
            set
            { 
                this.entidadPadre = value; 
            } 
        }

        public EntidadCollection EntidadesSubordinadas 
        {
            get { return this.entidadesSubordinadas; }
            set { this.entidadesSubordinadas = value; } 
        }

        #endregion

    }
}

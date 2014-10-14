using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;
using System.Collections.Generic;

namespace Snip.BP.BO.App
{
    public class Perfil : BusinessBase
    {
        #region Constructor(es)

        public Perfil()
        {
            Aplicacion = new Aplicacion();
            Opciones = new OpcionCollection();
            Estados = new EstadoCollection();
            TransicionesEstado = new TransicionEstadoCollection();
        }

        #endregion

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string IdPerfil { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "DescripcionNotNullOrEmpty")]
        public string Descripcion { get; set; }

        public bool EsInterno { get; set; }

        public bool Activo { get; set; }

        public Aplicacion Aplicacion { get; set; }

        public OpcionCollection Opciones { get; set; }

        public EstadoCollection Estados { get; set; }

        public TransicionEstadoCollection TransicionesEstado { get; set; }

        #endregion


    }
}

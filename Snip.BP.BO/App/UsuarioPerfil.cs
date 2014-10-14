using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.App
{
    public class UsuarioPerfil
    {
        #region Constructor(es)

        public UsuarioPerfil()
        {
            Perfil = new Perfil();
        }

        #endregion

        #region Propiedades Públicas

        public int CodUsuario { get; set; }
        public Perfil Perfil { get; set; }
        
        #endregion

    }
}

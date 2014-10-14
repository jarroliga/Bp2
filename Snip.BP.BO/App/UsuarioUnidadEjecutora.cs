using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.App
{
    public class UsuarioUnidadEjecutora
    {
        public UsuarioUnidadEjecutora() 
        {
            Usuario = new Usuario();
            UnidadEjecutora = new UnidadEjecutora();
        }

        public Usuario Usuario { get; set; }
        public UnidadEjecutora UnidadEjecutora { get; set; }

        public int CodUsuario
        {
            get { return Usuario.Codigo; }
            set { Usuario.Codigo = value; }
        }
        public int CodUnidadEjecutora
        {
            get { return UnidadEjecutora.Codigo; }
        }
        public string Nombre
        {
            get { return UnidadEjecutora.Nombre; }
        }
    }
}

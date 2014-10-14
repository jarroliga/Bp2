using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.App
{
    public class Usuario : BusinessBase
    {

        #region Constructor(es)

        public Usuario()
        {
            Institucion = new Institucion();
            Codigo = -1;
            //Proyectos = new ProyectoCollection();
            UnidadesEjecutoras = new UsuarioUnidadEjecutoraCollection();
            Perfiles = new UsuarioPerfilCollection();
        }

        #endregion

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "ApellidoNotNullOrEmpty")]
        public string Apellido { get; set; }

        public string Email { get; set; }

        [NotNullOrEmpty(Key = "LoginNotNullOrEmpty")]
        public string Login { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime? FechaUltimoAcceso { get; set; }

        public bool Habilitado { get; set; }

        public bool EsInterno { get; set; }

        /// <summary>
        /// Obtiene el nombre completo del usuario el cual es una combinación de
        /// <see cref="Nombre" /> y <see cref="Apellido" />.
        /// </summary>
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }

        public Institucion Institucion { get; set; }

       // public ProyectoCollection Proyectos { get; set; }

        public UsuarioUnidadEjecutoraCollection UnidadesEjecutoras { get; set; }

        public UsuarioPerfilCollection Perfiles { get; set; }

        #endregion

        #region Métodos Públicos

        public override string ToString()
        {
            return Apellido + ", " + Nombre;
        }

        #endregion

    }
}

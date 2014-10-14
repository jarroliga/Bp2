using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Web.Security;

using Snip.BP.BO.App;
using Snip.BP.Dal.App;
using Snip.BP.Validation;

namespace Snip.BP.Bll.App
{
    public static class UsuarioManager
    {
        /// <summary>
        /// Constantes utilizadas por los algoritmos de cifrado utilizado en la seguridad.
        /// </summary>
        const string DefaultHashFunction = "SHA1";
        const int DefaultSeedSize = 5;

        public static Usuario GetUsuarioWithUnidadesEjecutoras(int codUsuario)
        {
            return GetItem(codUsuario, false, true, -1);
        }
        public static Usuario GetUsuarioWithUnidadesEjecutoras(int codUsuario, int anioPip)
        {
            return GetItem(codUsuario, false, true, anioPip);
        }
        public static Usuario GetItem(int codUsuario)
        {
            return GetItem(codUsuario, false, false, -1);
        }
        
        public static Usuario GetItem(int codUsuario, bool getPerfil, bool getUnidadEjecutora, int anioPip)
        {
            Usuario usuario = new Usuario();

            usuario = UsuarioDB.GetItem(codUsuario);

            if (usuario != null)
            {
                if (getPerfil)
                {
                    usuario.Perfiles = UsuarioPerfilDB.GetList(codUsuario);
                }
                if (getUnidadEjecutora)
                {
                    usuario.UnidadesEjecutoras = UsuarioUnidadEjecutoraDB.GetList(codUsuario, anioPip);
                }
            }
            return usuario;
        }
        public static UsuarioCollection GetListPaged(int codInstitucion, int pageIndex, int pageSize, string sortField, bool sortDirection, string searchValue, string filterCriteria, string filterValue, ref int totalRecords)
        {
            UsuarioCollection usuarioList = new UsuarioCollection();
            usuarioList = UsuarioDB.GetList(codInstitucion, pageIndex, pageSize, sortField, sortDirection, searchValue, filterCriteria, filterValue, ref totalRecords);
            return usuarioList;
        }
        public static int Save(Usuario usuario)
        {
            if (!usuario.Validate())
            {
                throw new InvalidSaveOperationException("Registro inválido. Asegurese de que los valores sean los correctos.");
            }
            if (usuario.EsInterno)
            {
                usuario.Institucion.Codigo = -1;
            }
            return UsuarioDB.Save(usuario);
        }
        /// <summary>
        /// Genera un número aleatorio utilizando el proveedor de servicios criptográficos
        /// retornando dicho número aleatorio codificado en una cadena en base a 64 digitos.
        /// </summary>
        /// <param name="size">Tamaño de la semilla</param>
        /// <returns>Cadena encriptada</returns>
        public static string GetSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);

        }
        /// <summary>
        /// Genera una cadena crifada y de tamaño fijo para encriptar la contraseña 
        /// del usuario en base a una llave definida
        /// </summary>
        /// <param name="pwd">Contraseña a cifrar</param>
        /// <param name="salt">Llave privada utilizada para cifrar</param>
        /// <returns>Contraseña cifrada</returns>
        public static string GetPasswordHash(string pwd, string salt)
        {
            string saltAndPwd = string.Concat(pwd, salt);
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, DefaultHashFunction);
            return hashedPwd;
        }
        /// <summary>
        /// Verifica que las credenciales del usuario sean válidas.
        /// </summary>
        /// <param name="loginUsuario">Login del Usuario</param>
        /// <param name="pwd">Contraseña del Usuario</param>
        /// <returns>Si las credenciales son válidas retorna el código de usuario, en caso contrario retorna -1.</returns>
        public static Usuario ValidateUser(string loginUsuario, string pwdUsuario, ref string idPerfil, int codAplicacion)
        {
            Usuario usuario = new Usuario();
            usuario = UsuarioDB.GetItemByLogin(loginUsuario);
            bool isValid = false;

            if (usuario != null)
            {
                string pwdAndSalt = string.Concat(pwdUsuario, usuario.Salt);
                string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwdAndSalt, DefaultHashFunction);

                isValid = hashedPwd.Equals(usuario.Password);

                idPerfil = UsuarioPerfilDB.GetIdPerfilByAplication(usuario.Codigo, codAplicacion);
            }
            else
            {
                isValid = false;
            }

            if (!isValid)
                usuario = null;

            return usuario;
        }
        public static Usuario Validate(string loginUsuario, string pwdUsuario)
        {
            Usuario usuario = new Usuario();
            usuario = UsuarioDB.GetItemByLogin(loginUsuario);
            bool isValid = false;

            if (usuario != null)
            {
                string pwdAndSalt = string.Concat(pwdUsuario, usuario.Salt);
                string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwdAndSalt, DefaultHashFunction);

                isValid = hashedPwd.Equals(usuario.Password);

                if (!usuario.Habilitado)
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            if (!isValid)
                usuario = null;

            return usuario;
        }
        public static int ChangePassword(Usuario usuario, string pwdUsuario)
        {
            usuario.Salt = GetSalt(DefaultSeedSize);
            usuario.Password = GetPasswordHash(pwdUsuario, usuario.Salt);

            if (!usuario.Validate())
            {
                throw new InvalidSaveOperationException("Registro inválido. Asegurese de que los valores sean los correctos.");
            }
            if (usuario.EsInterno)
            {
                usuario.Institucion.Codigo = -1;
            }
            return UsuarioDB.Save(usuario);

        }
        public static UsuarioPerfil GetPerfilUsuarioByAplicacion(int codUsuario, int codAplicacion)
        {
            UsuarioPerfil perfil = new UsuarioPerfil();

            perfil = UsuarioPerfilDB.GetItem(codUsuario, codAplicacion);

            return perfil;
        }

        public static bool Delete(int codigo)
        {
            return UsuarioDB.Delete(codigo);
        }
    }
}

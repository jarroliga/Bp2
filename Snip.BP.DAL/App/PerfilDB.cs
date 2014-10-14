using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    /// <summary>
    /// La clase PerfilDB es la responsable de interactuar con la base de datos para recuperar
    /// y almacenar información sobre objetos <see cref="Perfil">Perfil</see>.
    /// </summary>
    public class PerfilDB
    {
        #region Métodos Públicos

        /// <summary>
        /// Recupera la información de un objeto Perfil desde la fuente de datos.
        /// </summary>
        /// <param name="codigo">Código del Perfil</param>
        /// <returns>Instancia de objeto Perfil</returns>
        public static Perfil GetItem(int codigo)
        {
            Perfil perfil = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].PerfilGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodPerfil", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            perfil = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return perfil;
        }
        /// <summary>
        /// Recupera una coleccion de instancias de objetos Perfil desde la fuente de datos
        /// en base al objeto Aplicacion al cual este relacionado.
        /// </summary>
        /// <param name="codAplicacion">Código de la Aplicación</param>
        /// <returns>Colección de instancias de objetos Perfil</returns>
        public static PerfilCollection GetList(int codAplicacion)
        {
            PerfilCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].PerfilGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodAplicacion", codAplicacion);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PerfilCollection();
                            while (reader.Read())
                            {
                                lista.Add(BuildEntityFromReader(reader));
                            }
                        }
                        reader.Close();
                    }
                }
            }
            return lista;
        }
        /// <summary>
        /// Recupera una coleccion de instancias de objetos Perfil desde la fuente de datos
        /// en base al objeto Aplicacion al cual este relacionado.
        /// </summary>
        /// <param name="codUsuario">Código del Usuario</param>
        /// <param name="codAplicacion">Código de la Aplicación</param>
        /// <returns>Colección de instancias de objeto Perfil</returns>
        public static PerfilCollection GetListByUsuario(int codUsuario, int codAplicacion)
        {
            PerfilCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].PerfilGetListByUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    command.Parameters.AddWithValue("@CodAplicacion", codAplicacion);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PerfilCollection();
                            while (reader.Read())
                            {
                                lista.Add(BuildEntityFromReader(reader));
                            }
                        }
                        reader.Close();
                    }
                }
            }
            return lista;
        }
        #endregion

        #region Métodos Privados

        private static Perfil BuildEntityFromReader(IDataReader reader)
        {
            Perfil perfil = new Perfil();

            perfil.Codigo = Helper.GetInteger(reader["CodPerfil"]);
            perfil.Nombre = Helper.GetString(reader["Nombre"]);
            perfil.IdPerfil = Helper.GetString(reader["IdPerfil"]);
            perfil.Descripcion = Helper.GetString(reader["Descripcion"]);
            perfil.EsInterno = Helper.GetBoolean(reader["EsInterno"]);
            perfil.Activo = Helper.GetBoolean(reader["Activo"]);
            
            Aplicacion aplicacion = new Aplicacion();
            aplicacion.Codigo = Helper.GetInteger(reader["CodAplicacion"]);
            aplicacion.Nombre = Helper.GetString(reader["Aplicacion"]);
            aplicacion.IdAplicacion = Helper.GetString(reader["IdAplicacion"]);

            perfil.Aplicacion = aplicacion;

            return perfil;
        }

        #endregion
    }
}

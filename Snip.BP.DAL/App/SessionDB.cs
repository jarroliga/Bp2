using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;

namespace Snip.BP.Dal.App
{
    public class SessionDB
    {
        #region Métodos públicos

        public static Session GetItem(string sessionId)
        {
            Session session = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[app].SessionGetItem", connection))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@SessionId", sessionId);
                    connection.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            session = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return session;
        }

        public static SessionCollection GetList(int codAplicacion)
        {
            SessionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[app].SessionGetList", connection))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodAplicacion", codAplicacion);
                    connection.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new SessionCollection();
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
        public static int Save(Session session)
        {
            int result = 0;

            using (SqlConnection conexion = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[app].SessionInsertUpdate", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@SessionId", session.SessionId);
                    comando.Parameters.AddWithValue("@CodAplicacion", session.Aplicacion.Codigo);
                    comando.Parameters.AddWithValue("@CodUsuario", session.Usuario.Codigo);
                    comando.Parameters.AddWithValue("@FechaCreacion", session.FechaEmision);
                    comando.Parameters.AddWithValue("@FechaExpiracion", session.FechaExpiracion);
                    comando.Parameters.AddWithValue("@Validez", session.Validez);

                    conexion.Open();

                    int registrosAfectados = comando.ExecuteNonQuery();

                    if (registrosAfectados == 0)
                    {
                        throw new DBConcurrencyException("No se puede guardar el registro en la Base de Datos.");
                    }

                    result = registrosAfectados;

                }
                conexion.Close();
            }
            return result;
        }

        public static bool Delete(int codigo)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[app].SessionDelete", connection))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@SessionId", codigo);
                    connection.Open();
                    result = comando.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result > 0;
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Permite poblar una <seealso cref="EntidadBase"/> con los
        /// datos provenientes de un IDataReader
        /// </summary>
        /// <param name="reader">Un objeto que implementa un IDataReader</param>
        /// <returns>Una EntidadBase</returns>
        private static Session BuildEntityFromReader(IDataReader reader)
        {
            Session session = new Session();

            session.Codigo = Helper.GetInteger(reader["CodSession"]);
            session.SessionId = Helper.GetString(reader["SessionId"]);
            session.FechaEmision = Helper.GetDateTime(reader["FechaEmision"]);
            session.Validez = Helper.GetDouble(reader["Validez"]);

            Aplicacion aplicacion = new Aplicacion();
            
            aplicacion.Codigo = Helper.GetInteger(reader["CodAplicacion"]);
            aplicacion.Nombre = Helper.GetString(reader["Aplicacion"]);

            session.Aplicacion = aplicacion;

            Usuario usuario = new Usuario();

            usuario.Codigo = Helper.GetInteger(reader["CodUsuario"]);
            usuario.Nombre = Helper.GetString(reader["Login"]);

            session.Usuario = usuario;

            return session;
        }

        #endregion
    }
}

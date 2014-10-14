using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    /// <summary>
    /// La clase AplicacionDB es la responsable de interactuar con la base de datos para recuperar
    /// y almacenar información sobre objetos <see cref="Aplicacion">Aplicación</see>.
    /// </summary>
    public class AplicacionDB
    {
        #region Métodos Públicos

        /// <summary>
        /// Obtiene una instancia de <see cref="Aplicacion">Aplicación</see> desde la fuentes de datos.
        /// </summary>
        /// <param name="codigo">Código identificador único</param>
        /// <returns>Una instanci del objeto <see cref="Aplicacion">Aplicación</see></returns>
        public static Aplicacion GetItem(int codigo)
        {
            Aplicacion aplicacion = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].AplicacionGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodAplicacion", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            aplicacion = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return aplicacion;
        }
        /// <summary>
        /// Retorna una lista de instancias del objeto Aplicacion
        /// </summary>
        /// <returns>Coleccion de objetos Aplicacion</returns>
        public static AplicacionCollection GetList()
        {
            AplicacionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].AplicacionGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new AplicacionCollection();
                            while (reader.Read())
                            {
                                lista.Add(BuildEntityFromReader(reader));
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return lista;
        }

        public static int Save(Aplicacion aplicacion)
        {
            int result = 0;

            if (aplicacion == null)
                return result;
            if (!aplicacion.Validate())
                return result;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].AplicacionInsertUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", aplicacion.Nombre);
                    command.Parameters.AddWithValue("@IdAplicacion", aplicacion.IdAplicacion);

                    Helper.SetSaveParameters(command, aplicacion);

                    connection.Open();

                    int registrosAfectados = command.ExecuteNonQuery();

                    if (registrosAfectados == 0)
                    {
                        throw new DBConcurrencyException("No se pudo salvar el registro en la Base de Datos.");
                    }

                    // aplicacion.IdConcurrencia = Helper.GetConcurrencyId(command);
                    result = Helper.GetBusinessBaseId(command);

                }
                connection.Close();
            }
            return result;
        }
        public static bool Delete(int codigo)
        {
            int result = 0;

            try
            {

                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[app].AplicacionDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Codigo", codigo);
                        connection.Open();
                        result = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                DataAccessExceptionHandler.HandleException(ex.Message);
            }
            return result > 0;
        }
        #endregion
        
        #region Métodos Privados

        /// <summary>
        /// Permite poblar un objeto <see cref="Aplicacion"/> con los
        /// datos provenientes de un reader
        /// </summary>
        /// <param name="reader">Un objeto que implementa un IDataReader</param>
        /// <returns>Un objeto</returns>
        private static Aplicacion BuildEntityFromReader(IDataReader reader)
        {
            Aplicacion aplicacion = new Aplicacion();

            aplicacion.Codigo = Helper.GetInteger(reader["CodAplicacion"]);
            aplicacion.Nombre = Helper.GetString(reader["Nombre"]);
            aplicacion.IdAplicacion = Helper.GetString(reader["IdAplicacion"]);

            return aplicacion;
        }

        #endregion
    }
}

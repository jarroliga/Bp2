using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.App
{
    public class TransicionEstadoDB
    {
        #region Métodos Públicos

        public static TransicionEstado GetItem(int codigo)
        {
            TransicionEstado entidad = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].TransicionEstadoGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodTransicionEstado", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entidad = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return entidad;
        }
        public static TransicionEstadoCollection GetList()
        {
            TransicionEstadoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].TransicionEstadoGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new TransicionEstadoCollection();
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
        public static TransicionEstadoCollection GetList(int codEstadoOrigen)
        {
            TransicionEstadoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].TransicionEstadoGetListByOrigen", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodEstadoOrigen", codEstadoOrigen);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new TransicionEstadoCollection();
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
        public static int Save(TransicionEstado transicion)
        {
            if (!transicion.Validate())
            {
                throw new InvalidSaveOperationException("No se ha podido salvar el registro. Datos invalidos.!!");
            }

            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].TransicionEstadoInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodEstadoOrigen", transicion.CodEstadoOrigen);
                        command.Parameters.AddWithValue("@CodEstadoDestino", transicion.CodEstadoDestino);
                        command.Parameters.AddWithValue("@IdTransicion", transicion.IdTransicion);
                        command.Parameters.AddWithValue("@Descripcion", transicion.Descripcion);
                        command.Parameters.AddWithValue("@TransicionPrimaria", transicion.TransicionPrimaria);
                        command.Parameters.AddWithValue("@Activo", transicion.Activo);
                        command.Parameters.AddWithValue("@CodUsuario", transicion.CodUsuarioActualizacion);

                        Helper.SetSaveParameters(command, transicion);

                        connection.Open();

                        int registrosAfectados = command.ExecuteNonQuery();

                        if (registrosAfectados == 0)
                        {
                            throw new DBConcurrencyException("No se pudo salvar el registro en la Base de Datos.");
                        }

                        // transicion.IdConcurrencia = Helper.GetConcurrencyId(command);
                        result = Helper.GetBusinessBaseId(command);

                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                DataAccessExceptionHandler.HandleException(e.Message);
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
                    using (SqlCommand command = new SqlCommand("[app].TransicionEstadoDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Codigo", codigo);
                        connection.Open();
                        result = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                DataAccessExceptionHandler.HandleException(ex.Message);
            }
            return result > 0;
        }
        #endregion

        #region Métodos Privados

        private static TransicionEstado BuildEntityFromReader(IDataReader reader)
        {
            TransicionEstado transicion = new TransicionEstado();

            transicion.Codigo = Helper.GetInteger(reader["CodTransicionEstado"]);
            transicion.IdTransicion = Helper.GetString(reader["IdTransicion"]);
            transicion.EstadoOrigen.Codigo = Helper.GetInteger(reader["CodEstadoOrigen"]);
            transicion.EstadoOrigen.Nombre = Helper.GetString(reader["EstadoOrigen"]);
            transicion.EstadoDestino.Codigo = Helper.GetInteger(reader["CodEstadoDestino"]);
            transicion.EstadoDestino.Nombre = Helper.GetString(reader["EstadoDestino"]);
            transicion.Descripcion = Helper.GetString(reader["Descripcion"]);
            transicion.TransicionPrimaria = Helper.GetBoolean(reader["TransicionPrimaria"]);
            transicion.Activo = Helper.GetBoolean(reader["Activo"]);

            return transicion;
        }

        #endregion
    }
}

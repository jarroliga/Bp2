using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.App
{
    /// <summary>
    /// La clase EstadoDB es la responsable de interactuar con la base de datos para recuperar
    /// y almacenar información sobre objetos <see cref="Estado">Estado del BP SNIP</see>.
    /// </summary>
    public class EstadoDB
    {
        #region Métodos Públicos

        public static Estado GetItem(int codigo)
        {
            Estado entidad = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].EstadoGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodEstado", codigo);
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
        public static EstadoCollection GetList(int codTarea)
        {
            EstadoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].EstadoGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodTarea", codTarea);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new EstadoCollection();
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
        public static EstadoCollection GetListByPerfil(int codTarea, int codPerfil)
        {
            EstadoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].EstadoGetListByPerfil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodTarea", codTarea);
                    command.Parameters.AddWithValue("@CodPerfil", codPerfil);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new EstadoCollection();
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
        public static int Save(Estado estado)
        {
            if (!estado.Validate())
            {
                throw new InvalidSaveOperationException("No se ha podido salvar el registro. Datos invalidos.!!");
            }

            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].EstadoInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodTarea", estado.Tarea.Codigo);
                        command.Parameters.AddWithValue("@Nombre", estado.Nombre);
                        command.Parameters.AddWithValue("@IdEstado", estado.IdEstado);
                        command.Parameters.AddWithValue("@Secuencia", estado.Secuencia);
                        command.Parameters.AddWithValue("@Activo", estado.Activo);
                        command.Parameters.AddWithValue("@CodUsuario", estado.CodUsuarioActualizacion);

                        Helper.SetSaveParameters(command, estado);

                        connection.Open();

                        int registrosAfectados = command.ExecuteNonQuery();

                        if (registrosAfectados == 0)
                        {
                            throw new DBConcurrencyException("No se pudo salvar el registro en la Base de Datos.");
                        }

                        // estado.IdConcurrencia = Helper.GetConcurrencyId(command);
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
                    using (SqlCommand command = new SqlCommand("[app].EstadoDelete", connection))
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

        private static Estado BuildEntityFromReader(IDataReader reader)
        {
            Estado estado = new Estado();

            estado.Codigo = Helper.GetInteger(reader["CodEstado"]);
            estado.Nombre = Helper.GetString(reader["Nombre"]);
            estado.IdEstado = Helper.GetString(reader["IdEstado"]);
            estado.Secuencia = Helper.GetInteger(reader["Secuencia"]);
            estado.Activo = Helper.GetBoolean(reader["Activo"]);

            Tarea tarea = new Tarea();

            tarea.Codigo = Helper.GetInteger(reader["CodTarea"]);
            tarea.Nombre = Helper.GetString(reader["Tarea"]);

            estado.Tarea = tarea;

            return estado;
        }

        #endregion
    }
}

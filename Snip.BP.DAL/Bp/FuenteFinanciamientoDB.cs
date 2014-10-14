using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bp
{
    public class FuenteFinanciamientoDB
    {
        #region Métodos Públicos

        /// <summary>
        /// Obtiene una instancia de <see ref="FuenteFinanciamiento">Fuente de Financiamiento</see> desde la fuente de datos
        /// </summary>
        /// <param name="codigo">Código identificador único de la Fuente</param>
        /// <returns>Instancia del objeto Fuente</returns>
        public static FuenteFinanciamiento GetItem(int codigo)
        {
            FuenteFinanciamiento fuente = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].FuenteFinanciamientoGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodFuenteFinanciamiento", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fuente = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return fuente;

        }
        public static FuenteFinanciamientoCollection GetListPaged(int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, ref int totalRecords)
        {
            FuenteFinanciamientoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].FuenteFinanciamientoGetListPaged", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageIndex", pageIndex);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@OrderField", orderField);
                    command.Parameters.AddWithValue("@OrderDirection", orderDirection);
                    command.Parameters.AddWithValue("@SearchValue", searchValue);
                    command.Parameters.AddWithValue("@FilterCriteria", filterCriteria);
                    command.Parameters.AddWithValue("@FilterValue", filterValue);
                    
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                totalRecords = Convert.ToInt32(reader.GetValue(0));
                            }
                            reader.NextResult();

                            lista = new FuenteFinanciamientoCollection();
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
        public static int Save(FuenteFinanciamiento fuente)
        {
            if (!fuente.Validate())
            {
                throw new InvalidSaveOperationException("No se ha podido salvar el registro. Datos invalidos.!!");
            }

            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bp].FuenteFinanciamientoInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IdFuenteFinanciamiento", fuente.IdFuenteFinanciamiento);
                        command.Parameters.AddWithValue("@Nombre", fuente.Nombre);
                        command.Parameters.AddWithValue("@Externa", fuente.Externa);
                        command.Parameters.AddWithValue("@Activa", fuente.Activa);
                        command.Parameters.AddWithValue("@CodUsuario", fuente.CodUsuarioActualizacion);

                        Helper.SetSaveParameters(command, fuente);

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
                    using (SqlCommand command = new SqlCommand("[bp].FuenteFinanciamientoDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CodFuenteFinanciamiento", codigo);
                        connection.Open();

                        result = command.ExecuteNonQuery();

                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                DataAccessExceptionHandler.HandleException(e.Message);
            }
            return result > 0;
        }
        #endregion

        #region Métodos privados

        private static FuenteFinanciamiento BuildEntityFromReader(IDataRecord reader)
        {
            FuenteFinanciamiento fuente = new FuenteFinanciamiento();
            
            fuente.Codigo = Helper.GetInteger(reader["CodFuenteFinanciamiento"]);
            fuente.IdFuenteFinanciamiento = Helper.GetInteger(reader["IdFuenteFinanciamiento"]);
            fuente.Nombre = Helper.GetString(reader["Nombre"]);
            fuente.Externa = Helper.GetBoolean(reader["Externa"]);
            fuente.Activa = Helper.GetBoolean(reader["Activa"]);
            
            return fuente;

        }

        #endregion

    }
}

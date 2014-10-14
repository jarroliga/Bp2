using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bp
{
    public class TipoOrganismoFinanciadorDB
    {
        #region Métodos Públicos

        /// <summary>
        /// Obtiene una instancia de un <see ref="TipoOrganismoFinanciador">Tipo de Organismo Financiador</see> desde la fuente de datos
        /// </summary>
        /// <param name="codigo">Código identificador único del tipo de Organismo</param>
        /// <returns>Instancia del objeto Tipo de Organismo</returns>
        public static TipoOrganismoFinanciador GetItem(int codigo)
        {
            TipoOrganismoFinanciador fuente = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].TipoOrganismoFinanciadorGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodTipoOrganismoFinanciador", codigo);
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
        public static TipoOrganismoFinanciadorCollection GetListPaged(int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, ref int totalRecords)
        {
            TipoOrganismoFinanciadorCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].TipoOrganismoFinanciadorGetListPaged", connection))
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

                            lista = new TipoOrganismoFinanciadorCollection();
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
        public static int Save(TipoOrganismoFinanciador objeto)
        {
            if (!objeto.Validate())
            {
                throw new InvalidSaveOperationException("No se ha podido salvar el registro. Datos invalidos.!!");
            }

            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bp].TipoOrganismoFinanciadorInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IdTipoOrganismoFinanciador", objeto.IdTipoOrganismoFinanciador);
                        command.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                        command.Parameters.AddWithValue("@Externo", objeto.Externo);
                        command.Parameters.AddWithValue("@Activo", objeto.Activo);
                        command.Parameters.AddWithValue("@CodUsuario", objeto.CodUsuarioActualizacion);

                        Helper.SetSaveParameters(command, objeto);

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
                    using (SqlCommand command = new SqlCommand("[bp].TipoOrganismoFinanciadorDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CodTipoOrganismoFinanciador", codigo);
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

        private static TipoOrganismoFinanciador BuildEntityFromReader(IDataRecord reader)
        {
            TipoOrganismoFinanciador objeto = new TipoOrganismoFinanciador();

            objeto.Codigo = Helper.GetInteger(reader["CodTipoOrganismoFinanciador"]);
            objeto.IdTipoOrganismoFinanciador = Helper.GetInteger(reader["IdTipoOrganismoFinanciador"]);
            objeto.Nombre = Helper.GetString(reader["Nombre"]);
            objeto.Externo = Helper.GetBoolean(reader["Externo"]);
            objeto.Activo = Helper.GetBoolean(reader["Activo"]);

            return objeto;

        }

        #endregion
    }
}

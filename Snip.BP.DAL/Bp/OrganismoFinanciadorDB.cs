using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bp
{
    public class OrganismoFinanciadorDB
    {
        #region Métodos Públicos

        public static OrganismoFinanciador GetItem(int codigo)
        {
            OrganismoFinanciador fuente = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].OrganismoFinanciadorGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodOrganismoFinanciador", codigo);
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
        public static OrganismoFinanciadorCollection GetListPaged(int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, ref int totalRecords)
        {
            OrganismoFinanciadorCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].OrganismoFinanciadorGetListPaged", connection))
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

                            lista = new OrganismoFinanciadorCollection();
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
        public static int Save(OrganismoFinanciador objeto)
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
                    using (SqlCommand command = new SqlCommand("[bp].OrganismoFinanciadorInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodTipoOrganismoFinanciador", objeto.TipoOrganismoFinanciador.Codigo);
                        command.Parameters.AddWithValue("@IdOrganismoFinanciador", objeto.IdOrganismoFinanciador);
                        command.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                        command.Parameters.AddWithValue("@Activo", objeto.Activo);
                        command.Parameters.AddWithValue("@CodFuenteAnterior", objeto.CodFuenteAnterior);
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
                    using (SqlCommand command = new SqlCommand("[bp].OrganismoFinanciadorDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CodOrganismoFinanciador", codigo);
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

        private static OrganismoFinanciador BuildEntityFromReader(IDataRecord reader)
        {
            OrganismoFinanciador objeto = new OrganismoFinanciador();

            objeto.Codigo = Helper.GetInteger(reader["CodOrganismoFinanciador"]);
            objeto.IdOrganismoFinanciador = Helper.GetInteger(reader["IdOrganismoFinanciador"]);
            objeto.Nombre = Helper.GetString(reader["Nombre"]);
            objeto.Activo = Helper.GetBoolean(reader["Activo"]);

            return objeto;

        }

        #endregion
    }
}

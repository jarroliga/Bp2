using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bps
{
    /// <summary>
    /// La clase LicitacionDB es la responsable de interactuar con la base de datos para recuperar
    /// y almacenar información sobre objetos <see cref="Licitacion">Licitación</see>.
    /// </summary>
    public class LicitacionDB
    {
        #region Métodos Públicos

        /// <summary>
        /// Obtiene una instancia de <see ref="Licitacion">Licitación</see> desde la fuente de datos
        /// </summary>
        /// <param name="codigo">Código identificador único de la licitación</param>
        /// <returns>Instancia del objeto Licitacion</returns>
        public static Licitacion GetItem(int codigo)
        {
            Licitacion licitacion = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].LicitacionGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacion", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            licitacion = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return licitacion;

        }
        public static LicitacionCollection GetListPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string SessionId)
        {
            LicitacionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].LicitacionGetListPaged", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@PageIndex", pageIndex);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@OrderField", orderField);
                    command.Parameters.AddWithValue("@OrderDirection", orderDirection);
                    command.Parameters.AddWithValue("@SearchValue", searchValue);
                    command.Parameters.AddWithValue("@FilterCriteria", filterCriteria);
                    command.Parameters.AddWithValue("@FilterValue", filterValue);
                    command.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                    command.Parameters.AddWithValue("@SessionId", SessionId);

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

                            lista = new LicitacionCollection();
                            while (reader.Read())
                            {
                                lista.Add(BuildEntityFromReader(reader,true));
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return lista;
        }
        public static int Save(Licitacion licitacion)
        {
            if (!licitacion.Validate())
            {
                throw new InvalidSaveOperationException("No se ha podido salvar el registro. Datos invalidos.!!");
            }
            
            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].LicitacionInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodUnidadEjecutora",licitacion.UnidadEjecutora.Codigo);
                        command.Parameters.AddWithValue("@Anio", licitacion.Anio);
                        command.Parameters.AddWithValue("@IdLicitacion", licitacion.IdLicitacion);
                        command.Parameters.AddWithValue("@Nombre", licitacion.Nombre);

                        if (string.IsNullOrEmpty(licitacion.Descripcion))
                        {
                            command.Parameters.AddWithValue("@Descripcion", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Descripcion", licitacion.Descripcion);
                        }

                        command.Parameters.AddWithValue("@FechaInicio", licitacion.FechaInicio);
                        command.Parameters.AddWithValue("@Costo", licitacion.Costo);
                        command.Parameters.AddWithValue("@CodEstado", licitacion.Estado.Codigo);
                        command.Parameters.AddWithValue("@CodEtapa", licitacion.Etapa.Codigo);
                        command.Parameters.AddWithValue("@Activa", licitacion.Activa);
                        command.Parameters.AddWithValue("@Multiple", licitacion.Multiple);
                        command.Parameters.AddWithValue("@CodUsuario", licitacion.CodUsuarioActualizacion);

                        Helper.SetSaveParameters(command, licitacion);

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
                    using (SqlCommand command = new SqlCommand("[bps].LicitacionDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CodLicitacion", codigo);
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

        private static Licitacion BuildEntityFromReader(IDataReader reader)
        {
            return BuildEntityFromReader(reader, false);
        }

        private static Licitacion BuildEntityFromReader(IDataRecord reader, bool lazyload)
        {
            Licitacion licitacion = new Licitacion();

            licitacion.Codigo = Helper.GetInteger(reader["CodLicitacion"]);
            licitacion.Anio = Helper.GetInteger(reader["Anio"]);
            licitacion.IdLicitacion = Helper.GetString(reader["IdLicitacion"]);
            licitacion.Nombre = Helper.GetString(reader["Nombre"]);

            licitacion.FechaInicio = Helper.GetDateTime(reader["FechaInicio"]);
            licitacion.Costo = Helper.GetDecimal(reader["Costo"]);
            licitacion.ModificacionesFechaFirma = Helper.GetInteger(reader["ModificacionesFechaFirma"]);

            UnidadEjecutora unidadEjecutora = new UnidadEjecutora();

            unidadEjecutora.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
            unidadEjecutora.Nombre = Helper.GetString(reader["UnidadEjecutora"]);
            unidadEjecutora.Siglas = Helper.GetString(reader["Siglas"]);

            Estado estado = new Estado();

            estado.Codigo = Helper.GetInteger(reader["CodEstado"]);
            estado.Nombre = Helper.GetString(reader["Estado"]);
            estado.IdEstado = Helper.GetString(reader["IdEstado"]);

            Estado etapa = new Estado();

            etapa.Codigo = Helper.GetInteger(reader["CodEtapa"]);
            etapa.Nombre = Helper.GetString(reader["Etapa"]);
            etapa.IdEstado = Helper.GetString(reader["IdEtapa"]);

            licitacion.UnidadEjecutora = unidadEjecutora;
            licitacion.Estado = estado;
            licitacion.Etapa = etapa;

            if (!lazyload)
            {
                licitacion.Descripcion = Helper.GetString(reader["Descripcion"]);

                licitacion.FechaCreacion = Helper.GetDateTime(reader["FechaRegistro"]);
                licitacion.CodUsuarioCreacion = Helper.GetInteger(reader["CodUsuarioRegistro"]);
                licitacion.FechaActualizacion = Helper.GetDateTime(reader["FechaActualizacion"]);
                licitacion.CodUsuarioActualizacion = Helper.GetInteger(reader["CodUsuarioActualizacion"]);

                licitacion.Editable = Helper.GetBoolean(reader["Editable"]);
            }

            licitacion.Multiple = Helper.GetBoolean(reader["Multiple"]);
            licitacion.Activa = Helper.GetBoolean(reader["Activa"]);

            return licitacion;

        }

        #endregion

    }
}

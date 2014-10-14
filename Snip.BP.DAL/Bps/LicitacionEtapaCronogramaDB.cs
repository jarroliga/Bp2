using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bps
{
    public class LicitacionEtapaCronogramaDB
    {
        #region Métodos Públicos

        public static LicitacionEtapaCronograma GetItem(int codLicitacion, int codEtapa)
        {
            LicitacionEtapaCronograma etapa = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].LicitacionEtapaCronogramaGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacion", codLicitacion);
                    command.Parameters.AddWithValue("@CodEtapa", codEtapa);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            etapa = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return etapa;

        }
        public static LicitacionEtapaCronogramaCollection GetList(int codLicitacion)
        {
            LicitacionEtapaCronogramaCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].LicitacionEtapaCronogramaGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacion", codLicitacion);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new LicitacionEtapaCronogramaCollection();
                            while (reader.Read())
                            {
                                lista.Add(BuildEntityFromReader(reader, true));
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return lista;
        }
        public static int Save(LicitacionEtapaCronograma etapa)
        {
            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].LicitacionEtapaCronogramaInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodLicitacion", etapa.CodLicitacion);
                        command.Parameters.AddWithValue("@CodEtapa", etapa.CodEtapa);
                        command.Parameters.AddWithValue("@FechaFinProgramada", etapa.FechaFinProgramada);
                        command.Parameters.AddWithValue("@FechaFinReprogramada", etapa.FechaFinReprogramada);

                        if (etapa.FechaFinCumplimiento == null)
                        {
                            command.Parameters.AddWithValue("@FechaFinCumplimiento", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@FechaFinCumplimiento", etapa.FechaFinCumplimiento);
                        }
                        if (string.IsNullOrEmpty(etapa.ObservacionesUSIP))
                        {
                            command.Parameters.AddWithValue("@ObservacionesUSIP", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ObservacionesUSIP", etapa.ObservacionesUSIP);
                        }

                        if (string.IsNullOrEmpty(etapa.ObservacionesDGIP))
                        {
                            command.Parameters.AddWithValue("@ObservacionesDGIP", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ObservacionesDGIP", etapa.ObservacionesDGIP);
                        }

                        command.Parameters.AddWithValue("@Completada", etapa.Completada);

                        int codEstadoDestino = -1;

                        if (etapa.Completada)
                        {
                            if (etapa.Etapa.EstadosDestino != null)
                            {
                                codEstadoDestino = etapa.Etapa.EstadosDestino[0].Codigo;
                            }
                            else
                            {
                                codEstadoDestino = -1;
                            }
                        }
                        command.Parameters.AddWithValue("@CodUsuario", etapa.CodUsuarioActualizacion);

                        connection.Open();

                        int registrosAfectados = command.ExecuteNonQuery();

                        if (registrosAfectados == 0)
                        {
                            throw new DBConcurrencyException("No se pudo salvar el registro en la Base de Datos.");
                        }

                        result = (int)command.Parameters["@CodEtapa"].Value;

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

        #endregion

        #region Métodos privados

        private static LicitacionEtapaCronograma BuildEntityFromReader(IDataReader reader)
        {
            return BuildEntityFromReader(reader, false);
        }

        private static LicitacionEtapaCronograma BuildEntityFromReader(IDataReader reader, bool lazyLoad)
        {
            LicitacionEtapaCronograma etapaCronograma = new LicitacionEtapaCronograma();

            etapaCronograma.Licitacion.Codigo = Helper.GetInteger(reader["CodLicitacion"]);
            
            Estado etapa = new Estado();

            etapa.Codigo = Helper.GetInteger(reader["CodEtapa"]);
            etapa.Nombre = Helper.GetString(reader["Etapa"]);
            etapa.IdEstado = Helper.GetString(reader["IdEtapa"]);

            etapaCronograma.Etapa = etapa;

            etapaCronograma.FechaFinProgramada = Helper.GetNullableDateTime(reader["FechaFinProgramada"]);
            etapaCronograma.FechaFinReprogramada = Helper.GetNullableDateTime(reader["FechaFinReprogramada"]);
            etapaCronograma.FechaFinCumplimiento = Helper.GetNullableDateTime(reader["FechaFinCumplimiento"]);

            etapaCronograma.ObservacionesUSIP = Helper.GetString(reader["ObservacionesUSIP"]);

            etapaCronograma.Completada = Helper.GetBoolean(reader["Completada"]);

            etapaCronograma.FechaRegistro = Helper.GetDateTime(reader["FechaRegistro"]);
            etapaCronograma.CodUsuarioRegistro = Helper.GetInteger(reader["CodUsuarioRegistro"]);
            etapaCronograma.FechaActualizacion = Helper.GetDateTime(reader["FechaActualizacion"]);
            etapaCronograma.CodUsuarioActualizacion = Helper.GetInteger(reader["CodUsuarioActualizacion"]);

            if (!lazyLoad)
            {
                etapaCronograma.Licitacion.Anio = Helper.GetInteger(reader["Anio"]);
                etapaCronograma.Licitacion.IdLicitacion = Helper.GetString(reader["IdLicitacion"]);
                etapaCronograma.Licitacion.Nombre = Helper.GetString(reader["Nombre"]);
                etapaCronograma.Licitacion.Costo = Helper.GetDecimal(reader["Costo"]);
                etapaCronograma.Licitacion.FechaInicio = Helper.GetDateTime(reader["FechaInicio"]);

                UnidadEjecutora unidadEjecutora = new UnidadEjecutora();
                unidadEjecutora.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
                unidadEjecutora.Nombre = Helper.GetString(reader["UnidadEjecutora"]);
                unidadEjecutora.Siglas = Helper.GetString(reader["Siglas"]);

                Estado estadoLic = new Estado();
                estadoLic.Codigo = Helper.GetInteger(reader["CodEstadoLic"]);
                estadoLic.IdEstado = Helper.GetString(reader["IdEstadoLic"]);
                estadoLic.Nombre = Helper.GetString(reader["EstadoLic"]);

                Estado etapaLic = new Estado();
                etapaLic.Codigo = Helper.GetInteger(reader["CodEtapaLic"]);
                etapaLic.IdEstado = Helper.GetString(reader["IdEtapaLic"]);
                etapaLic.Nombre = Helper.GetString(reader["EtapaLic"]);

                etapaCronograma.Licitacion.Estado = estadoLic;
                etapaCronograma.Licitacion.Etapa = etapaLic;
                etapaCronograma.Licitacion.UnidadEjecutora = unidadEjecutora;

                etapaCronograma.ObservacionesDGIP = Helper.GetString(reader["ObservacionesDGIP"]);

                etapaCronograma.FechaMin = Helper.GetDateTime(reader["FechaMin"]);
                etapaCronograma.FechaMax = Helper.GetDateTime(reader["FechaMax"]);

            }
            
            return etapaCronograma;

        }

        #endregion

    }
}

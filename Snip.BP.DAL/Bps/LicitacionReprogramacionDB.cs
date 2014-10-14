using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bps
{
    public class LicitacionReprogramacionDB
    {
        #region Métodos Públicos

        public static LicitacionReprogramacion GetItem(int codLicitacion, int codLicitacionReprogramacion)
        {
            LicitacionReprogramacion cronograma = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].LicitacionReprogramacionGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacion", codLicitacion);
                    command.Parameters.AddWithValue("@CodLicitacionReprogramacion", codLicitacionReprogramacion);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cronograma = BuildEntityFromReader(reader, false);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return cronograma;

        }
        public static LicitacionReprogramacionCollection GetList(int codLicitacion)
        {
            return GetList(codLicitacion, -1);
        }
        public static LicitacionReprogramacionCollection GetList(int codLicitacion, int idTipoReprogramacion)
        {
            LicitacionReprogramacionCollection reprogramacion = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[bps].LicitacionReprogramacionGetList", connection))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodLicitacion", codLicitacion);
                    comando.Parameters.AddWithValue("@IdTipoReprogramacion", idTipoReprogramacion);
                    connection.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reprogramacion = new LicitacionReprogramacionCollection();
                            while (reader.Read())
                            {
                                reprogramacion.Add(BuildEntityFromReader(reader, true));
                            }
                            reader.Close();
                        }
                    }
                }
                connection.Close();
            }

            return reprogramacion;
        }
        public static int Save(LicitacionReprogramacion reprogramacion, bool isAprobacion, bool isRechazo)
        {
            if (!reprogramacion.Validate())
            {
                throw new InvalidSaveOperationException("No se ha podido salvar el registro. Datos invalidos.!!");
            }

            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].LicitacionReprogramacionInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodLicitacion", reprogramacion.CodLicitacion);
                        command.Parameters.AddWithValue("@IdTipoReprogramacion", reprogramacion.IdTipoReprogramacion);
                        command.Parameters.AddWithValue("@IdReferencia", reprogramacion.IdReferencia);
                        
                        command.Parameters.AddWithValue("@FechaFinProgramada", reprogramacion.FechaFinProgramada);
                        command.Parameters.AddWithValue("@FechaFinReprogramada", reprogramacion.FechaFinReprogramada);

                        if (string.IsNullOrEmpty(reprogramacion.Justificacion))
                        {
                            command.Parameters.AddWithValue("@Justificacion", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Justificacion", reprogramacion.Justificacion);
                        }

                        if (string.IsNullOrEmpty(reprogramacion.ObservacionesDGIP))
                        {
                            command.Parameters.AddWithValue("@ObservacionesDGIP", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ObservacionesDGIP", reprogramacion.ObservacionesDGIP);
                        }

                        command.Parameters.AddWithValue("@CodEstadoSolicitud", reprogramacion.EstadoSolicitud.Codigo);
                        command.Parameters.AddWithValue("@CodUsuario", reprogramacion.CodUsuarioActualizacion);
                        command.Parameters.AddWithValue("@IsAprobacion", isAprobacion);
                        command.Parameters.AddWithValue("@IsRechazo", isRechazo);

                        Helper.SetSaveParameters(command, reprogramacion);

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
        public static bool Delete(int CodLicitacionReprogramacion)
        {
            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].LicitacionReprogramacionDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodLicitacionReprogramacion", CodLicitacionReprogramacion);
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
        
        #region Metodos privados

        private static LicitacionReprogramacion BuildEntityFromReader(IDataReader reader, bool lazyLoad)
        {
            LicitacionReprogramacion reprogramacion = new LicitacionReprogramacion();
            
            reprogramacion.Codigo = Helper.GetInteger(reader["CodLicitacionReprogramacion"]);
            reprogramacion.IdTipoReprogramacion = Helper.GetInteger(reader["IdTipoReprogramacion"]);
            reprogramacion.IdReferencia = Helper.GetString(reader["IdReferencia"]);

            Licitacion licitacion = new Licitacion();

            licitacion.Codigo = Helper.GetInteger(reader["CodLicitacion"]);

            if (!lazyLoad)
            {
                licitacion.Anio = Helper.GetInteger(reader["Anio"]);
                licitacion.IdLicitacion = Helper.GetString(reader["IdLicitacion"]);
                licitacion.Nombre = Helper.GetString(reader["Nombre"]);
                licitacion.Costo = Helper.GetDecimal(reader["Costo"]);
                licitacion.FechaInicio = Helper.GetDateTime(reader["FechaInicio"]);

                UnidadEjecutora unidadEjecutora = new UnidadEjecutora();
                unidadEjecutora.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
                unidadEjecutora.Nombre = Helper.GetString(reader["UnidadEjecutora"]);
                unidadEjecutora.Siglas = Helper.GetString(reader["Siglas"]);

                Estado estadoLic = new Estado();
                estadoLic.Codigo = Helper.GetInteger(reader["CodEstado"]);
                estadoLic.IdEstado = Helper.GetString(reader["IdEstadoLic"]);
                estadoLic.Nombre = Helper.GetString(reader["EstadoLic"]);

                Estado etapaLic = new Estado();
                etapaLic.Codigo = Helper.GetInteger(reader["CodEtapa"]);
                etapaLic.IdEstado = Helper.GetString(reader["IdEtapaLic"]);
                etapaLic.Nombre = Helper.GetString(reader["EtapaLic"]);

                licitacion.Estado = estadoLic;
                licitacion.Etapa = etapaLic;
                licitacion.UnidadEjecutora = unidadEjecutora;

            }

            reprogramacion.Licitacion = licitacion;

            Estado estado = new Estado();

            estado.Codigo = Helper.GetInteger(reader["CodEstadoSolicitud"]);
            estado.Nombre = Helper.GetString(reader["Estado"]);
            estado.IdEstado = Helper.GetString(reader["IdEstado"]);

            reprogramacion.EstadoSolicitud = estado;

            reprogramacion.FechaFinProgramada = Helper.GetDateTime(reader["FechaFinProgramada"]);
            reprogramacion.FechaFinReprogramada = Helper.GetDateTime(reader["FechaFinReprogramada"]);

            reprogramacion.ObservacionesDGIP = Helper.GetString(reader["ObservacionesDGIP"]);
            reprogramacion.Justificacion = Helper.GetString(reader["Justificacion"]);

            reprogramacion.FechaSolicitud = Helper.GetDateTime(reader["FechaSolicitud"]);
            reprogramacion.FechaAprobacion = Helper.GetNullableDateTime(reader["FechaAprobacion"]);

            reprogramacion.UsuarioSolicitud.Codigo = Helper.GetInteger(reader["CodUsuarioSolicitud"]);
            reprogramacion.UsuarioSolicitud.Login = Helper.GetString(reader["LoginSolicitud"]);

            if (reader["CodUsuarioAprobacion"] != DBNull.Value)
            {
                reprogramacion.UsuarioAprobacion.Codigo = Helper.GetInteger(reader["CodUsuarioAprobacion"]);
                reprogramacion.UsuarioAprobacion.Login = Helper.GetString(reader["LoginAprobacion"]);
            }
            return reprogramacion;
        }
        #endregion
    }
}
 
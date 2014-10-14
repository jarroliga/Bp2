using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bps
{
    public class AlertaReprogramacionDB
    {
        public static AlertaReprogramacionCollection GetListByLicitacion(int codLicitacion)
        {
            AlertaReprogramacionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].AlertaReprogramacionGetListByLicitacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacion", codLicitacion);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new AlertaReprogramacionCollection();
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
        public static AlertaReprogramacionCollection GetListPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string SessionId)
        {
            AlertaReprogramacionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].AlertaReprogramacionGetListPaged", connection))
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

                            lista = new AlertaReprogramacionCollection();
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

        private static AlertaReprogramacion BuildEntityFromReader(IDataRecord reader)
        {
            AlertaReprogramacion reprogramacion = new AlertaReprogramacion();

            reprogramacion.Codigo = Helper.GetInteger(reader["CodLicitacionReprogramacion"]);
            reprogramacion.IdTipoReprogramacion = Helper.GetInteger(reader["IdTipoReprogramacion"]);

            reprogramacion.Licitacion.Codigo = Helper.GetInteger(reader["CodLicitacion"]);
            reprogramacion.Licitacion.IdLicitacion = Helper.GetString(reader["IdLicitacion"]);
            reprogramacion.Licitacion.Nombre = Helper.GetString(reader["Licitacion"]);

            UnidadEjecutora ue = new UnidadEjecutora();
            ue.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
            ue.Siglas = Helper.GetString(reader["Siglas"]);

            Estado estado = new Estado();

            estado.Codigo = Helper.GetInteger(reader["CodEstadoSolicitud"]);
            estado.Nombre = Helper.GetString(reader["EstadoSolicitud"]);

            reprogramacion.Licitacion.UnidadEjecutora = ue;
            reprogramacion.EstadoSolicitud = estado;
            
            reprogramacion.UsuarioSolicitud.Codigo = Helper.GetInteger(reader["CodUsuarioSolicitud"]);
            reprogramacion.UsuarioSolicitud.Login = Helper.GetString(reader["SolicitadoPor"]);
            reprogramacion.UsuarioSolicitud.Institucion.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
            reprogramacion.UsuarioSolicitud.Institucion.Siglas = Helper.GetString(reader["SiglasInst"]);
            reprogramacion.UsuarioAprobacion.Codigo = Helper.GetInteger(reader["CodUsuarioAprobacion"]);
            reprogramacion.UsuarioAprobacion.Login = Helper.GetString(reader["AprobadoPor"]);

            return reprogramacion;
        }
    }
}

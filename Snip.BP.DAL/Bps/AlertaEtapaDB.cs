using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bps
{
    public class AlertaEtapaDB
    {
        public static AlertaEtapaCollection GetList(int anio, int codUsuario)
        {
            AlertaEtapaCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].AlertaEtapaGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new AlertaEtapaCollection();
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
        public static AlertaEtapaCollection GetListPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string SessionId)
        {
            AlertaEtapaCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].AlertaEtapaGetListPaged", connection))
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

                            lista = new AlertaEtapaCollection();
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

        private static AlertaEtapa BuildEntityFromReader(IDataRecord reader)
        {
            AlertaEtapa alerta = new AlertaEtapa();

            Licitacion licitacion = new Licitacion();
            licitacion.Codigo = Helper.GetInteger(reader["CodLicitacion"]);
            licitacion.IdLicitacion = Helper.GetString(reader["IdLicitacion"]);
            licitacion.Nombre = Helper.GetString(reader["Licitacion"]);

            UnidadEjecutora ue = new UnidadEjecutora();
            ue.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
            ue.Siglas = Helper.GetString(reader["Siglas"]);

            Estado estado = new Estado();

            estado.Codigo = Helper.GetInteger(reader["CodEstado"]);
            estado.Nombre = Helper.GetString(reader["Estado"]);

            Estado etapa = new Estado();

            etapa.Codigo = Helper.GetInteger(reader["CodEtapaActual"]);
            etapa.Nombre = Helper.GetString(reader["EtapaActual"]);

            licitacion.UnidadEjecutora = ue;
            licitacion.Estado = estado;
            licitacion.Etapa = etapa;

            Estado etapaVencida = new Estado();

            etapaVencida.Codigo = Helper.GetInteger(reader["CodEtapa"]);
            etapaVencida.Nombre = Helper.GetString(reader["Etapa"]);

            Usuario user = new Usuario();

            user.Codigo = Helper.GetInteger(reader["CodUsuario"]);
            user.Login = Helper.GetString(reader["Login"]);
            user.Nombre = Helper.GetString(reader["Nombre"]);
            user.Apellido = Helper.GetString(reader["Apellido"]);

            Institucion inst = new Institucion();

            inst.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
            inst.Siglas = Helper.GetString(reader["SiglasInst"]);

            user.Institucion = inst;

            alerta.Licitacion = licitacion;
            alerta.EtapaVencida = etapaVencida;
            alerta.FechaFinProgramada = Helper.GetDateTime(reader["FechaFinProgramada"]);
            alerta.FechaFinReprogramada = Helper.GetDateTime(reader["FechaFinReprogramada"]);
            alerta.DiasVencidos = Helper.GetInteger(reader["DiasVencidos"]);
            alerta.Usuario = user;

            return alerta;
        }
    }
}

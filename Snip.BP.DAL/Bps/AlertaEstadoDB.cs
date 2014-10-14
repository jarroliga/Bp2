using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bps
{
    public class AlertaEstadoDB
    {
        public static AlertaEstadoCollection GetList(int anio, int codUsuario)
        {
            AlertaEstadoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].AlertaEstadoGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new AlertaEstadoCollection();
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
        public static AlertaEstadoCollection GetListByLicitacion(int codLicitacion)
        {
            AlertaEstadoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].AlertaEstadoGetListByLicitacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacion", codLicitacion);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new AlertaEstadoCollection();
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
        public static AlertaEstadoCollection GetListPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string SessionId)
        {
            AlertaEstadoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].AlertaEstadoGetListPaged", connection))
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

                            lista = new AlertaEstadoCollection();
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

        private static AlertaEstado BuildEntityFromReader(IDataRecord reader)
        {
            AlertaEstado alerta = new AlertaEstado();

            TipoAlerta tipo = new TipoAlerta();
            tipo.Codigo = Helper.GetInteger(reader["CodTipoAlerta"]);
            tipo.Nombre = Helper.GetString(reader["TipoAlerta"]);

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

            //Estado etapa = new Estado();

            //etapa.Codigo = Helper.GetInteger(reader["CodEtapa"]);
            //etapa.Nombre = Helper.GetString(reader["Etapa"]);

            licitacion.UnidadEjecutora = ue;
            licitacion.Estado = estado;
            //licitacion.Etapa = etapa;

            Obra obra = new Obra();

            obra.Codigo = Helper.GetInteger(reader["CodObra"]);
            obra.TipoComponente = Helper.GetInteger(reader["TipoComponente"]);
            obra.Consecutivo = Helper.GetInteger(reader["Consecutivo"]);

            Proyecto proy = new Proyecto();
            proy.Codigo = Helper.GetInteger(reader["CodProy"]);
            proy.CodSnip = Helper.GetString(reader["CodSnip"]);

            obra.Proyecto = proy;

            Usuario user = new Usuario();

            user.Codigo = Helper.GetInteger(reader["CodUsuario"]);
            user.Login = Helper.GetString(reader["Login"]);
            user.Nombre = Helper.GetString(reader["Nombre"]);
            user.Apellido = Helper.GetString(reader["Apellido"]);

            Institucion inst = new Institucion();

            inst.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
            inst.Siglas = Helper.GetString(reader["SiglasInst"]);

            user.Institucion = inst;

            alerta.TipoAlerta = tipo;
            alerta.Licitacion = licitacion;
            alerta.Obra = obra;
            alerta.Usuario = user;

            return alerta;
        }
    }
}

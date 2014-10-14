using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;

namespace Snip.BP.Dal.Bp
{
    public class ProyectoDB
    {
        #region Métodos Públicos

        public static Proyecto GetItem(int codigo)
        {
            Proyecto proyecto = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ProyectoGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodProyecto", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            proyecto = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return proyecto;
        }
        public static ProyectoCollection GetList(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, int codUsuario, string idPerfil, string sessionId, ref int totalRecords)
        {
            ProyectoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ProyectoGetList", connection))
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
                    command.Parameters.AddWithValue("@SessionId", sessionId);

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
                            
                            lista = new ProyectoCollection();
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
        public static ProyectoCollection GetListByUsuario(int codUsuario)
        {
            ProyectoCollection lista = null;

            return lista;
        }
        #endregion
        #region Métodos Privados

        private static Proyecto BuildEntityFromReader(IDataReader reader)
        {
            return BuildEntityFromReader(reader, false);
        }

        private static Proyecto BuildEntityFromReader(IDataReader reader, bool lazyload)
        {
            Proyecto proyecto = new Proyecto();

            proyecto.Codigo = Helper.GetInteger(reader["CodProy"]);
            proyecto.CodSnip = Helper.GetString(reader["CodSnip"]);
            proyecto.Nombre = Helper.GetString(reader["NomProy"]);
            proyecto.FechaInicioPrevista = Helper.GetNullableDateTime(reader["FechaProgInicio"]);
            proyecto.FechaFinPrevista = Helper.GetNullableDateTime(reader["FechaProgFinal"]);
            proyecto.FechaInicioReal = Helper.GetNullableDateTime(reader["FechaRealInicio"]);
            proyecto.FechaFinReal = Helper.GetNullableDateTime(reader["FechaRealFin"]);

            UnidadEjecutora unidadEjecutora = new UnidadEjecutora();
            unidadEjecutora.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
            unidadEjecutora.Nombre = Helper.GetString(reader["UnidadEjecutora"]);
            unidadEjecutora.Siglas = Helper.GetString(reader["SiglasUE"]);

            Sector sector = new Sector();
            sector.Codigo = Helper.GetInteger(reader["CodSector"]);
            sector.Nombre = Helper.GetString(reader["Sector"]);

            if (!lazyload)
            {
                Institucion institucion = new Institucion();
                institucion.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
                institucion.Nombre = Helper.GetString(reader["Institucion"]);
                institucion.Siglas = Helper.GetString(reader["SiglasI"]);

                ClasificadorInstitucional clasificadorInst = new ClasificadorInstitucional();
                clasificadorInst.Codigo = Helper.GetInteger(reader["CodClasificadorInstitucional"]);
                clasificadorInst.Nombre = Helper.GetString(reader["ClasificadorInstitucional"]);

                Sector sectorP = new Sector();
                sectorP.Codigo = Helper.GetInteger(reader["CodSectorP"]);
                sectorP.Nombre = Helper.GetString(reader["SectorP"]);

                sector.SectorPadre = sectorP;

                institucion.ClasificadorInstitucional = clasificadorInst;
                unidadEjecutora.Institucion = institucion;

                Estado etapa = new Estado();

                etapa.Codigo = Helper.GetInteger(reader["CodEtapa"]);
                etapa.Nombre = Helper.GetString(reader["Etapa"]);

                proyecto.Etapa = etapa;
            }
            proyecto.UnidadEjecutora = unidadEjecutora;
            proyecto.Sector = sector;

            return proyecto;
        }

        #endregion

    }
}

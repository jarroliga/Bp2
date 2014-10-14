using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.Bp
{
    public class ObraDB
    {
        public static Obra GetItem(int codigo)
        {
            Obra obra = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ObraGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodObra", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            obra = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return obra;
        }
        public static ObraCollection GetList(int codProyecto, int anio, int pageIndex, int pageSize, string sortField, string sortOrder,
                        string searchValue, string filterField, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string sessionId)
        {
            ObraCollection lista = null;
            
            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ObraGetListPaged", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodProyecto", codProyecto);
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@PageIndex", pageIndex);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@SortField", sortField);
                    command.Parameters.AddWithValue("@SortOrder", sortOrder);
                    command.Parameters.AddWithValue("@SearchValue", searchValue);
                    command.Parameters.AddWithValue("@FilterField", filterField);
                    command.Parameters.AddWithValue("@FilterValue", filterValue);
                    command.Parameters.AddWithValue("@CodUsuario", codUsuario);
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

                            lista = new ObraCollection();
                            while (reader.Read())
                            {
                                lista.Add(BuildEntityFromReader(reader, true));
                            }
                        }
                        reader.Close();
                    }
                }
            }
            return lista;
        }
        

        #region Métodos Privados

        private static Obra BuildEntityFromReader(IDataReader reader)
        {
            return BuildEntityFromReader(reader, false);
        }

        private static Obra BuildEntityFromReader(IDataReader reader, bool lazyload)
        {
            Obra obra = new Obra();
            
            obra.Codigo = Helper.GetInteger(reader["CodProy"]);
            obra.Nombre = Helper.GetString(reader["Nombre"]);
            obra.TipoComponente = Helper.GetInteger(reader["TipoComponente"]);
            obra.Orden = Helper.GetInteger(reader["Orden"]);
            obra.Consecutivo = Helper.GetInteger(reader["Consecutivo"]);
            obra.FechaInicioPrevista = Helper.GetNullableDateTime(reader["FechaProgInicio"]);
            obra.FechaFinPrevista = Helper.GetNullableDateTime(reader["FechaProgFinal"]);
            obra.FechaInicioReal = Helper.GetNullableDateTime(reader["FechaRealInicio"]);
            obra.FechaFinReal = Helper.GetNullableDateTime(reader["FechaRealFin"]);

            Proyecto proyecto = new Proyecto();

            proyecto.Codigo = Helper.GetInteger(reader["CodProyecto"]);
            proyecto.CodSnip = Helper.GetString(reader["CodSnip"]);
            proyecto.Nombre = Helper.GetString(reader["Proyecto"]);

            if (!lazyload)
            {
                UnidadEjecutora unidadEjecutora = new UnidadEjecutora();

                unidadEjecutora.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
                unidadEjecutora.Nombre = Helper.GetString(reader["UnidadEjecutora"]);
                unidadEjecutora.Siglas = Helper.GetString(reader["SiglasUE"]);

                Institucion institucion = new Institucion();

                institucion.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
                institucion.Nombre = Helper.GetString(reader["Institucion"]);
                institucion.Siglas = Helper.GetString(reader["SiglasI"]);

                Sector sector = new Sector();

                sector.Codigo = Helper.GetInteger(reader["CodSector"]);
                sector.Nombre = Helper.GetString(reader["Sector"]);

                Sector sectorP = new Sector();

                sectorP.Codigo = Helper.GetInteger(reader["CodSectorP"]);
                sectorP.Nombre = Helper.GetString(reader["SectorP"]);

                unidadEjecutora.Institucion = institucion;
                sector.SectorPadre = sectorP;
                
                proyecto.Sector = sector;
                proyecto.UnidadEjecutora = unidadEjecutora;

            }          

            obra.Proyecto = proyecto;

            return obra;
        }

        #endregion

    }
}

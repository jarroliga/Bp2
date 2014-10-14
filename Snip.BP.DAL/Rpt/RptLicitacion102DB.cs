using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Snip.BP.BO.Rpt;

namespace Snip.BP.Dal.Rpt
{
    public class RptLicitacion102DB
    {
        public static List<RptLicitacion102> GetList(int anio, DateTime fechaIni, DateTime fechaFin, int codInstitucion, int codListaFiltro)
        {
            List<RptLicitacion102> lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[rpt].BpsListLicitacionesPorEtapaConcluida", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@FechaInicio", fechaIni);
                    command.Parameters.AddWithValue("@FechaCorte", fechaFin);
                    command.Parameters.AddWithValue("@CodInstitucion", codInstitucion);
                    command.Parameters.AddWithValue("@CodListaFiltro", codListaFiltro);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new List<RptLicitacion102>();
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

        private static RptLicitacion102 BuildEntityFromReader(IDataRecord reader)
        {
            RptLicitacion102 reporte = new RptLicitacion102();

            reporte.CodInstitucion = Helper.GetInteger(reader["CodInstitucion"]);
            reporte.Institucion = Helper.GetString(reader["Institucion"]);
            reporte.Siglas = Helper.GetString(reader["Siglas"]);
            reporte.IdTipo = Helper.GetString(reader["IdTipo"]);

            reporte.CodLicitacion = Helper.GetInteger(reader["CodLicitacion"]);
            reporte.Anio = Helper.GetInteger(reader["Anio"]);
            reporte.IdLicitacion = Helper.GetString(reader["IdLicitacion"]);
            reporte.Nombre = Helper.GetString(reader["Nombre"]);
            reporte.CodEstado = Helper.GetInteger(reader["CodEstado"]);
            reporte.Estado = Helper.GetString(reader["Estado"]);
            reporte.CodEtapa = Helper.GetInteger(reader["CodEtapa"]);
            reporte.Etapa = Helper.GetString(reader["Etapa"]);

            reporte.Etapa1P = Helper.GetNullableDateTime(reader["L1P"]);
            reporte.Etapa1C = Helper.GetNullableDateTime(reader["L1E"]);
            reporte.Etapa2P = Helper.GetNullableDateTime(reader["L2P"]);
            reporte.Etapa2C = Helper.GetNullableDateTime(reader["L2E"]);
            reporte.Etapa3P = Helper.GetNullableDateTime(reader["L3P"]);
            reporte.Etapa3C = Helper.GetNullableDateTime(reader["L3E"]);
            reporte.Etapa4P = Helper.GetNullableDateTime(reader["L4P"]);
            reporte.Etapa4C = Helper.GetNullableDateTime(reader["L4E"]);
            reporte.Etapa5P = Helper.GetNullableDateTime(reader["L5P"]);
            reporte.Etapa5C = Helper.GetNullableDateTime(reader["L5E"]);
            reporte.Etapa6P = Helper.GetNullableDateTime(reader["L6P"]);
            reporte.Etapa6C = Helper.GetNullableDateTime(reader["L6E"]);

            reporte.Iniciada = Helper.GetInteger(reader["Iniciada"]);
            reporte.NoIniciada = Helper.GetInteger(reader["NoIniciada"]);
            reporte.Desierta = Helper.GetInteger(reader["Desierta"]);
            reporte.Cancelada = Helper.GetInteger(reader["Cancelada"]);

            reporte.CodProyecto = Helper.GetInteger(reader["CodProyecto"]);
            reporte.CodSnipP = Helper.GetString(reader["CodSnipP"]);
            reporte.Proyecto = Helper.GetString(reader["Proyecto"]);
            
            reporte.CodObra = Helper.GetInteger(reader["CodObra"]);
            reporte.CodSnip = Helper.GetString(reader["CodSnip"]);
            reporte.Obra = Helper.GetString(reader["Obra"]);
            
            reporte.Programado = Helper.GetDecimal(reader["Programado"]);
            reporte.ProgramadoPeriodo = Helper.GetDecimal(reader["ProgramadoPeriodo"]);
            
            return reporte;

        }

    }
}

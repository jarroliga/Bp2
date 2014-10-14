using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Snip.BP.BO.Rpt;

namespace Snip.BP.Dal.Rpt
{
    public class RptTemporalDB
    {
        public static List<RptTemporal> GetList()
        {
            List<RptTemporal> lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].ReporteTmp", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new List<RptTemporal>();
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

        private static RptTemporal BuildEntityFromReader(IDataRecord reader)
        {
            RptTemporal reporte = new RptTemporal();

            reporte.CodInstitucion = Helper.GetInteger(reader["CodInstP"]);
            reporte.Institucion = Helper.GetString(reader["Institucion"]);
            reporte.Siglas = Helper.GetString(reader["Siglas"]);

            reporte.CodProyP = Helper.GetInteger(reader["CodProyP"]);
            reporte.CodSnipP = Helper.GetString(reader["CodSnipP"]);
            reporte.Proyecto = Helper.GetString(reader["Proyecto"]);

            reporte.CodProy = Helper.GetInteger(reader["CodProy"]);
            reporte.CodSnip = Helper.GetString(reader["CodSnip"]);
            reporte.Obra = Helper.GetString(reader["Obra"]);

            reporte.CodContrato = Helper.GetInteger(reader["CodContrato"]);
            reporte.IdContrato = Helper.GetString(reader["IdContrato"]);
            reporte.Contrato = Helper.GetString(reader["Contrato"]);
            reporte.TipoContrato = Helper.GetString(reader["TipoContrato"]);
            reporte.ModalidadEjecucion = Helper.GetString(reader["ModalidadEjecucion"]);

            reporte.CostoInicial = Helper.GetDecimal(reader["CostoInicial"]);
            reporte.CostoVariaciones = Helper.GetDecimal(reader["CostoVariaciones"]);
            reporte.CostoActualizado = Helper.GetDecimal(reader["CostoActualizado"]);

            reporte.FechaInicioProgramada = Helper.GetDateTime(reader["FechaInicioProgramada"]);
            reporte.FechaFinProgramada = Helper.GetDateTime(reader["FechaFinalProgramada"]);

            reporte.FechaInicioOficial = Helper.GetDateTime(reader["FechaInicioOficial"]);
            reporte.FechaFinActualizada = Helper.GetDateTime(reader["FechaFinalActualizada"]);

            reporte.PlazoProgramadoDias = Helper.GetInteger(reader["PlazoProgramadoDias"]);
            reporte.PlazoRealDias = Helper.GetInteger(reader["PlazoRealDias"]);
            reporte.Reprogramaciones = Helper.GetInteger(reader["Reprogramaciones"]);

            reporte.DiferenciaPlazos = Helper.GetInteger(reader["DiferenciaPlazos"]);

            return reporte;

        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Snip.BP.BO.Rpt;

namespace Snip.BP.Dal.Rpt
{
    public class RptLicitacion109DB
    {
        public static List<RptLicitacion109> GetList(int anio, int codInstitucion, DateTime fechaIni, DateTime fechaFin)
        {
            List<RptLicitacion109> lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[rpt].BpsListLicitaciones109", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@CodInstitucion", codInstitucion);
                    command.Parameters.AddWithValue("@FechaInicio", fechaIni);
                    command.Parameters.AddWithValue("@FechaCorte", fechaFin);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new List<RptLicitacion109>();
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

        private static RptLicitacion109 BuildEntityFromReader(IDataRecord reader)
        {
            RptLicitacion109 reporte = new RptLicitacion109();

            reporte.Anio = Helper.GetInteger(reader["Anio"]);
            reporte.CodInstitucion = Helper.GetInteger(reader["CodInstitucion"]);
            reporte.Institucion = Helper.GetString(reader["Institucion"]);
            reporte.Siglas = Helper.GetString(reader["Siglas"]);

            reporte.CodLicitacion = Helper.GetInteger(reader["CodLicitacion"]);
            reporte.CodLicitacionReprogramacion = Helper.GetInteger(reader["CodLicitacionReprogramacion"]);
            reporte.IdLicitacion = Helper.GetString(reader["IdLicitacion"]);
            reporte.Nombre = Helper.GetString(reader["Nombre"]);
            reporte.FechaInicio = Helper.GetDateTime(reader["FechaInicio"]);

            reporte.IdTipoReprogramacion = Helper.GetInteger(reader["IdTipoReprogramacion"]);
            reporte.TipoReprogramacion = Helper.GetString(reader["TipoReprogramacion"]);
            reporte.IdReferencia = Helper.GetString(reader["IdReferencia"]);
            reporte.Justificacion = Helper.GetString(reader["Justificacion"]);
            reporte.ObservacionesDGIP = Helper.GetString(reader["ObservacionesDGIP"]);
            reporte.FechaFirmaOriginal = Helper.GetDateTime(reader["FechaFirmaOriginal"]);
            reporte.FechaFirmaProgramada = Helper.GetDateTime(reader["FechaFirmaProgramada"]);
            reporte.FechaFirmaReprogramada = Helper.GetDateTime(reader["FechaFirmaReprogramada"]);
            reporte.VariacionDias = Helper.GetInteger(reader["VariacionDias"]);
            
            reporte.FechaSolicitud = Helper.GetDateTime(reader["FechaSolicitud"]);
            reporte.SolicitadoPor = Helper.GetString(reader["SolicitadoPor"]);
            reporte.FechaAprobacion = Helper.GetDateTime(reader["FechaAprobacion"]);
            reporte.AprobadoPor = Helper.GetString(reader["AprobadoPor"]);
            reporte.Duracion = Helper.GetInteger(reader["Duracion"]);

            return reporte;

        }
    }
}

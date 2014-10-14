using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bps
{
    public class LicitacionObraReprogramacionDB
    {
        public static LicitacionObraReprogramacion GetItem(int codLicitacion, int codObra, int codReprogramacion)
        {
            LicitacionObraReprogramacion reprogramacion = new LicitacionObraReprogramacion();

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[bps].LicitacionObraReprogramacionGetItem", connection))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodLicitacion", codLicitacion);
                    comando.Parameters.AddWithValue("@CodObra", codObra);
                    comando.Parameters.AddWithValue("@CodLicitacionReprogramacion", codReprogramacion);
                    connection.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reprogramacion = BuildEntityFromReader(reader, true);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return reprogramacion;
        }
        public static LicitacionObraReprogramacionCollection GetList(int codLicitacion, int codReprogramacion)
        {
            LicitacionObraReprogramacionCollection reprogramacion = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[bps].LicitacionObraReprogramacionGetList", connection))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodLicitacion", codLicitacion);
                    comando.Parameters.AddWithValue("@CodLicitacionReprogramacion", codReprogramacion);
                    connection.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reprogramacion = new LicitacionObraReprogramacionCollection();
                            while (reader.Read())
                            {
                                reprogramacion.Add(BuildEntityFromReader(reader, false));
                            }
                            reader.Close();
                        }
                    }
                }
                connection.Close();
            }

            return reprogramacion;
        }
        public static int Save(LicitacionObraReprogramacion obraReprogramada)
        {
            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].LicitacionObraReprogramacionUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodLicitacionReprogramacion", obraReprogramada.CodLicitacionReprogramacion);
                        command.Parameters.AddWithValue("@CodLicitacion", obraReprogramada.CodLicitacion);
                        command.Parameters.AddWithValue("@CodObra", obraReprogramada.CodObra);
                        command.Parameters.AddWithValue("@Anio", obraReprogramada.Programacion.Anio);
                        command.Parameters.AddWithValue("@Reprogramado", obraReprogramada.Reprogramado);
                        command.Parameters.AddWithValue("@PorcentajeAsignacion", obraReprogramada.PorcentajeAsignacion);
                        command.Parameters.AddWithValue("@PlazoEjecucionDias", obraReprogramada.PlazoEjecucionDias);
                        command.Parameters.AddWithValue("@Prestamo", obraReprogramada.ProgramadoPorFuente.Prestamo);
                        command.Parameters.AddWithValue("@Donacion", obraReprogramada.ProgramadoPorFuente.Donacion);
                        command.Parameters.AddWithValue("@Tesoro", obraReprogramada.ProgramadoPorFuente.Tesoro);
                        command.Parameters.AddWithValue("@RecursosPropios", obraReprogramada.ProgramadoPorFuente.RecursosPropios);
                        command.Parameters.AddWithValue("@Programado01", obraReprogramada.Programacion.Mes01);
                        command.Parameters.AddWithValue("@Programado02", obraReprogramada.Programacion.Mes02);
                        command.Parameters.AddWithValue("@Programado03", obraReprogramada.Programacion.Mes03);
                        command.Parameters.AddWithValue("@Programado04", obraReprogramada.Programacion.Mes04);
                        command.Parameters.AddWithValue("@Programado05", obraReprogramada.Programacion.Mes05);
                        command.Parameters.AddWithValue("@Programado06", obraReprogramada.Programacion.Mes06);
                        command.Parameters.AddWithValue("@Programado07", obraReprogramada.Programacion.Mes07);
                        command.Parameters.AddWithValue("@Programado08", obraReprogramada.Programacion.Mes08);
                        command.Parameters.AddWithValue("@Programado09", obraReprogramada.Programacion.Mes09);
                        command.Parameters.AddWithValue("@Programado10", obraReprogramada.Programacion.Mes10);
                        command.Parameters.AddWithValue("@Programado11", obraReprogramada.Programacion.Mes11);
                        command.Parameters.AddWithValue("@Programado12", obraReprogramada.Programacion.Mes12);
                        
                        connection.Open();

                        int registrosAfectados = command.ExecuteNonQuery();

                        if (registrosAfectados == 0)
                        {
                            throw new DBConcurrencyException("No se pudo salvar el registro en la Base de Datos.");
                        }

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
        private static LicitacionObraReprogramacion BuildEntityFromReader(IDataReader reader, bool getItem)
        {
            LicitacionObraReprogramacion obraReprogramada = new LicitacionObraReprogramacion();

            obraReprogramada.CodLicitacionReprogramacion = Helper.GetInteger(reader["CodLicitacionReprogramacion"]);
            obraReprogramada.CodLicitacion = Helper.GetInteger(reader["CodLicitacion"]);
            obraReprogramada.Licitacion.Anio = Helper.GetInteger(reader["Anio"]);
            obraReprogramada.CodObra = Helper.GetInteger(reader["CodObra"]);
            
            obraReprogramada.PorcentajeAsignacion = Helper.GetDecimal(reader["PorcentajeAsignacion"]);
            obraReprogramada.PlazoEjecucionDias = Helper.GetInteger(reader["PlazoEjecucionDias"]);

            obraReprogramada.Programado = Helper.GetDecimal(reader["Programado"]);
            obraReprogramada.Reprogramado = Helper.GetDecimal(reader["Reprogramado"]);

            OrigenFondo reprogramado = new OrigenFondo();

            reprogramado.Prestamo = Helper.GetDecimal(reader["Prestamo"]);
            reprogramado.Donacion = Helper.GetDecimal(reader["Donacion"]);
            reprogramado.Tesoro = Helper.GetDecimal(reader["Tesoro"]);
            reprogramado.RecursosPropios = Helper.GetDecimal(reader["RecursosPropios"]);

            if (getItem)
            {

                obraReprogramada.Programacion.Anio = obraReprogramada.Licitacion.Anio;
                obraReprogramada.Programacion.Mes01 = Helper.GetDecimal(reader["Programado01"]);
                obraReprogramada.Programacion.Mes02 = Helper.GetDecimal(reader["Programado02"]);
                obraReprogramada.Programacion.Mes03 = Helper.GetDecimal(reader["Programado03"]);
                obraReprogramada.Programacion.Mes04 = Helper.GetDecimal(reader["Programado04"]);
                obraReprogramada.Programacion.Mes05 = Helper.GetDecimal(reader["Programado05"]);
                obraReprogramada.Programacion.Mes06 = Helper.GetDecimal(reader["Programado06"]);
                obraReprogramada.Programacion.Mes07 = Helper.GetDecimal(reader["Programado07"]);
                obraReprogramada.Programacion.Mes08 = Helper.GetDecimal(reader["Programado08"]);
                obraReprogramada.Programacion.Mes09 = Helper.GetDecimal(reader["Programado09"]);
                obraReprogramada.Programacion.Mes10 = Helper.GetDecimal(reader["Programado10"]);
                obraReprogramada.Programacion.Mes11 = Helper.GetDecimal(reader["Programado11"]);
                obraReprogramada.Programacion.Mes12 = Helper.GetDecimal(reader["Programado12"]);
            }

            obraReprogramada.ProgramadoPorFuente = reprogramado;

            obraReprogramada.Obra.Nombre = Helper.GetString(reader["Obra"]);
            obraReprogramada.Obra.TipoComponente = Helper.GetInteger(reader["TipoComponente"]);
            obraReprogramada.Obra.Consecutivo = Helper.GetInteger(reader["Consecutivo"]);

            Proyecto proyecto = new Proyecto();

            proyecto.Codigo = Helper.GetInteger(reader["CodProyecto"]);
            proyecto.CodSnip = Helper.GetString(reader["CodSnip"]);
            proyecto.Nombre = Helper.GetString(reader["Proyecto"]);

            obraReprogramada.Obra.Proyecto = proyecto;

            return obraReprogramada;
        }
    }
}

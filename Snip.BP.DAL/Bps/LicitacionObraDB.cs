using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bps
{
    public class LicitacionObraDB
    {
        #region Métodos Públicos

        public static LicitacionObra GetItem(int codLicitacion, int codObra)
        {
            LicitacionObra entidad = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].LicitacionObraGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacion", codLicitacion);
                    command.Parameters.AddWithValue("@CodObra", codObra);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entidad = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return entidad;

        }
        public static LicitacionObraCollection GetList(int codLicitacion)
        {
            LicitacionObraCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].LicitacionObraGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacion", codLicitacion);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new LicitacionObraCollection();
                            while (reader.Read())
                            {
                                lista.Add(BuildEntityFromReader(reader, false, true, false));
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return lista;
        }

        public static int Save(LicitacionObra obraLicitada)
        {
            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].LicitacionObraInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodLicitacion", obraLicitada.CodLicitacion);
                        command.Parameters.AddWithValue("@CodObra", obraLicitada.CodObra);
                        command.Parameters.AddWithValue("@Programado", obraLicitada.Programado);
                        command.Parameters.AddWithValue("@PorcentajeAsignacion", obraLicitada.PorcentajeAsignacion);
                        command.Parameters.AddWithValue("@Prestamo", obraLicitada.ProgramadoPorFuente.Prestamo);
                        command.Parameters.AddWithValue("@Donacion", obraLicitada.ProgramadoPorFuente.Donacion);
                        command.Parameters.AddWithValue("@Tesoro", obraLicitada.ProgramadoPorFuente.Tesoro);
                        command.Parameters.AddWithValue("@RecursosPropios", obraLicitada.ProgramadoPorFuente.RecursosPropios);
                        command.Parameters.AddWithValue("@PlazoEjecucionDias", obraLicitada.PlazoEjecucionDias);
                        command.Parameters.AddWithValue("@Desierta", obraLicitada.Desierta);

                        command.Parameters.AddWithValue("@Anio", obraLicitada.Programacion.Anio);
                        command.Parameters.AddWithValue("@Programado01", obraLicitada.Programacion.Mes01);
                        command.Parameters.AddWithValue("@Programado02", obraLicitada.Programacion.Mes02);
                        command.Parameters.AddWithValue("@Programado03", obraLicitada.Programacion.Mes03);
                        command.Parameters.AddWithValue("@Programado04", obraLicitada.Programacion.Mes04);
                        command.Parameters.AddWithValue("@Programado05", obraLicitada.Programacion.Mes05);
                        command.Parameters.AddWithValue("@Programado06", obraLicitada.Programacion.Mes06);
                        command.Parameters.AddWithValue("@Programado07", obraLicitada.Programacion.Mes07);
                        command.Parameters.AddWithValue("@Programado08", obraLicitada.Programacion.Mes08);
                        command.Parameters.AddWithValue("@Programado09", obraLicitada.Programacion.Mes09);
                        command.Parameters.AddWithValue("@Programado10", obraLicitada.Programacion.Mes10);
                        command.Parameters.AddWithValue("@Programado11", obraLicitada.Programacion.Mes11);
                        command.Parameters.AddWithValue("@Programado12", obraLicitada.Programacion.Mes12);

                        command.Parameters.AddWithValue("@CodUsuario", obraLicitada.CodUsuarioRegistro);

                        connection.Open();

                        int registrosAfectados = command.ExecuteNonQuery();

                        if (registrosAfectados == 0)
                        {
                            throw new DBConcurrencyException("No se pudo salvar el registro en la Base de Datos.");
                        }

                        result = registrosAfectados;

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
        public static bool Delete(LicitacionObra obraLicitada)
        {
            int result = 0;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].LicitacionObraDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodLicitacion", obraLicitada.CodLicitacion);
                        command.Parameters.AddWithValue("@CodObra", obraLicitada.CodObra);

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

        #region Métodos privados

        private static LicitacionObra BuildEntityFromReader(IDataRecord reader)
        {
            return BuildEntityFromReader(reader, true, true, true);
        }

        private static LicitacionObra BuildEntityFromReader(IDataRecord reader, bool getLicitacion, bool getObra, bool getProgramacion)
        {
            LicitacionObra obraEnLicitacion = new LicitacionObra();

            Licitacion licitacion = new Licitacion();

            licitacion.Codigo = Helper.GetInteger(reader["CodLicitacion"]);

            if (getLicitacion)
            {
                licitacion.IdLicitacion = Helper.GetString(reader["IdLicitacion"]);
                licitacion.Anio = Helper.GetInteger(reader["Anio"]);
                licitacion.Nombre = Helper.GetString(reader["Licitacion"]);
                licitacion.Costo = Helper.GetDecimal(reader["Costo"]);
                licitacion.Estado.Codigo = Helper.GetInteger(reader["CodEstado"]);
                licitacion.Estado.IdEstado = Helper.GetString(reader["IdEstado"]);
                licitacion.Estado.Nombre = Helper.GetString(reader["Estado"]);
                licitacion.Etapa.Codigo = Helper.GetInteger(reader["CodEtapa"]);
                licitacion.Etapa.IdEstado = Helper.GetString(reader["IdEtapa"]);
                licitacion.Etapa.Nombre = Helper.GetString(reader["Etapa"]);

                UnidadEjecutora unidadEjecutora = new UnidadEjecutora();

                unidadEjecutora.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
                unidadEjecutora.Nombre = Helper.GetString(reader["UnidadEjecutora"]);
                unidadEjecutora.Siglas = Helper.GetString(reader["Siglas"]);

                licitacion.UnidadEjecutora = unidadEjecutora;

            }
            
            obraEnLicitacion.Licitacion = licitacion;

            Obra obra = new Obra();

            obra.Codigo = Helper.GetInteger(reader["CodObra"]);

            if (getObra)
            {
                obra.Nombre = Helper.GetString(reader["Obra"]);
                obra.TipoComponente = Helper.GetInteger(reader["TipoComponente"]);
                obra.Consecutivo = Helper.GetInteger(reader["Consecutivo"]);

                Proyecto proyecto = new Proyecto();

                proyecto.Codigo = Helper.GetInteger(reader["CodProyecto"]);
                proyecto.CodSnip = Helper.GetString(reader["CodSnip"]);
                proyecto.Nombre = Helper.GetString(reader["Proyecto"]);

                obra.Proyecto = proyecto;
            }

            obraEnLicitacion.Obra = obra;

            obraEnLicitacion.Programado = Helper.GetDecimal(reader["Programado"]);
            obraEnLicitacion.PorcentajeAsignacion = Helper.GetDecimal(reader["PorcentajeAsignacion"]);
            obraEnLicitacion.PlazoEjecucionDias = Helper.GetInteger(reader["PlazoEjecucionDias"]);
            obraEnLicitacion.Desierta = Helper.GetBoolean(reader["Desierta"]);
            obraEnLicitacion.ProgramadoPorFuente.Prestamo = Helper.GetDecimal(reader["Prestamo"]);
            obraEnLicitacion.ProgramadoPorFuente.Donacion = Helper.GetDecimal(reader["Donacion"]);
            obraEnLicitacion.ProgramadoPorFuente.Tesoro = Helper.GetDecimal(reader["Tesoro"]);
            obraEnLicitacion.ProgramadoPorFuente.RecursosPropios = Helper.GetDecimal(reader["RecursosPropios"]);

            //ProgramacionAnual programacion = new ProgramacionAnual();

            if (getProgramacion)
            {
                obraEnLicitacion.Programacion.Anio = Helper.GetInteger(reader["Anio"]);

                obraEnLicitacion.Programacion.Mes01 = Helper.GetDecimal(reader["Programado01"]);
                obraEnLicitacion.Programacion.Mes02 = Helper.GetDecimal(reader["Programado02"]);
                obraEnLicitacion.Programacion.Mes03 = Helper.GetDecimal(reader["Programado03"]);
                obraEnLicitacion.Programacion.Mes04 = Helper.GetDecimal(reader["Programado04"]);
                obraEnLicitacion.Programacion.Mes05 = Helper.GetDecimal(reader["Programado05"]);
                obraEnLicitacion.Programacion.Mes06 = Helper.GetDecimal(reader["Programado06"]);
                obraEnLicitacion.Programacion.Mes07 = Helper.GetDecimal(reader["Programado07"]);
                obraEnLicitacion.Programacion.Mes08 = Helper.GetDecimal(reader["Programado08"]);
                obraEnLicitacion.Programacion.Mes09 = Helper.GetDecimal(reader["Programado09"]);
                obraEnLicitacion.Programacion.Mes10 = Helper.GetDecimal(reader["Programado10"]);
                obraEnLicitacion.Programacion.Mes11 = Helper.GetDecimal(reader["Programado11"]);
                obraEnLicitacion.Programacion.Mes12 = Helper.GetDecimal(reader["Programado12"]);

            }

            return obraEnLicitacion;
        }

        #endregion
    }
}

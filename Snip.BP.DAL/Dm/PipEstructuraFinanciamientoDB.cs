using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Dm;

namespace Snip.BP.Dal.Dm
{
    public class PipEstructuraFinanciamientoDB
    {
        #region Métodos Públicos

        public static PipEstructuraFinanciamiento GetItem(int anio, int idTipoEntidad, int formato)
        {
            PipEstructuraFinanciamiento pip = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PIPGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@IdTipoEntidad", idTipoEntidad);
                    command.Parameters.AddWithValue("@FormatoNumerico", formato);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pip = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return pip;
        }
        public static PipEstructuraFinanciamientoCollection GetList(int anio, int formato)
        {
            PipEstructuraFinanciamientoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PIPGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@FormatoNumerico", formato);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PipEstructuraFinanciamientoCollection();
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

        #endregion

        #region Métodos Privados

        private static PipEstructuraFinanciamiento BuildEntityFromReader(IDataReader reader)
        {
            PipEstructuraFinanciamiento pip = new PipEstructuraFinanciamiento();

            pip.Anio = Helper.GetInteger(reader["Anio"]);
            pip.IdTipoEntidad = Helper.GetInteger(reader["IdTipoEntidad"]);
            pip.TipoEntidad = Helper.GetString(reader["TipoEntidad"]);

            OrigenFondo asignado = new OrigenFondo();

            asignado.Prestamo = Helper.GetDecimal(reader["AsignadoPrestamo"]);
            asignado.Donacion = Helper.GetDecimal(reader["AsignadoDonacion"]);
            asignado.Tesoro = Helper.GetDecimal(reader["AsignadoTesoro"]);
            asignado.RecursosPropios = Helper.GetDecimal(reader["AsignadoRecursosPropios"]);

            pip.Asignado = asignado;

            OrigenFondo modificado = new OrigenFondo();

            modificado.Prestamo = Helper.GetDecimal(reader["ModificadoPrestamo"]);
            modificado.Donacion = Helper.GetDecimal(reader["ModificadoDonacion"]);
            modificado.Tesoro = Helper.GetDecimal(reader["ModificadoTesoro"]);
            modificado.RecursosPropios = Helper.GetDecimal(reader["ModificadoRecursosPropios"]);

            pip.Modificado = modificado;

            OrigenFondo actualizado = new OrigenFondo();

            actualizado.Prestamo = Helper.GetDecimal(reader["ActualizadoPrestamo"]);
            actualizado.Donacion = Helper.GetDecimal(reader["ActualizadoDonacion"]);
            actualizado.Tesoro = Helper.GetDecimal(reader["ActualizadoTesoro"]);
            actualizado.RecursosPropios = Helper.GetDecimal(reader["ActualizadoRecursosPropios"]);

            pip.Actualizado = actualizado;

            OrigenFondo ejecutado = new OrigenFondo();

            ejecutado.Prestamo = Helper.GetDecimal(reader["EjecutadoPrestamo"]);
            ejecutado.Donacion = Helper.GetDecimal(reader["EjecutadoDonacion"]);
            ejecutado.Tesoro = Helper.GetDecimal(reader["EjecutadoTesoro"]);
            ejecutado.RecursosPropios = Helper.GetDecimal(reader["EjecutadoRecursosPropios"]);

            pip.Ejecutado = ejecutado;

            pip.TasaCambio = Helper.GetDecimal(reader["TasaCambio"]);

            return pip;
        }

        #endregion
    }
}

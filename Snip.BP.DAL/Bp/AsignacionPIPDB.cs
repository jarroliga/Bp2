using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.Bp
{
    public class AsignacionPIPDB
    {
        #region Métodos Públicos

        public static AsignacionPIP GetItem(int codObra, int anio)
        {
            return GetItem(codObra, anio, 7, 2);
        }
        public static AsignacionPIP GetItem(int codObra, int anio, int idPip, int idMomento)
        {
            AsignacionPIP asignacion = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].AsignacionPIPGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodObra", codObra);
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@IdPip", idPip);
                    command.Parameters.AddWithValue("@IdMomento", idMomento);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            asignacion = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return asignacion;
        }
        #endregion

        #region Métodos Privados

        private static AsignacionPIP BuildEntityFromReader(IDataReader reader)
        {
            AsignacionPIP asignacion = new AsignacionPIP();

            asignacion.CodObra = Helper.GetInteger(reader["CodObra"]);
            asignacion.Anio = Helper.GetInteger(reader["Anio"]);
            asignacion.IdPip = Helper.GetInteger(reader["IdPip"]);
            asignacion.IdMomento = Helper.GetInteger(reader["IdMomento"]);

            asignacion.Asignado = Helper.GetDecimal(reader["MontoAsignado"]);
            asignacion.AsignadoPrestamo = Helper.GetDecimal(reader["Prestamo"]);
            asignacion.PorcentajePrestamo = Helper.GetDecimal(reader["PorcPrestamo"]);
            asignacion.AsignadoDonacion = Helper.GetDecimal(reader["Donacion"]);
            asignacion.PorcentajeDonacion = Helper.GetDecimal(reader["PorcDonacion"]);
            asignacion.AsignadoTesoro = Helper.GetDecimal(reader["Tesoro"]);
            asignacion.PorcentajeTesoro = Helper.GetDecimal(reader["PorcTesoro"]);
            asignacion.AsignadoRecursosPropios = Helper.GetDecimal(reader["RecursosPropios"]);
            asignacion.PorcentajeRecursosPropios = Helper.GetDecimal(reader["PorcRecursosPropios"]);

            return asignacion;
        }

        #endregion
    }
}

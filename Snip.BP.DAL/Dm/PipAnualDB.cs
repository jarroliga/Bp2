using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Dm;

namespace Snip.BP.Dal.Dm
{
    public class PipAnualDB
    {

        #region Métodos Públicos

        public static PipAnual GetItem(int anio, int formato)
        {
            PipAnual pip = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PipAnualGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
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
        public static PipAnualCollection GetList(int anioIni, int anioFin, int formato)
        {
            PipAnualCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PipAnualGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AnioIni", anioIni);
                    command.Parameters.AddWithValue("@AnioFin", anioFin);
                    command.Parameters.AddWithValue("@FormatoNumerico", formato);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PipAnualCollection();
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

        private static PipAnual BuildEntityFromReader(IDataReader reader)
        {
            PipAnual pip = new PipAnual();

            pip.Anio = Helper.GetInteger(reader["Anio"]);

            pip.Asignado = Helper.GetDecimal(reader["Asignado"]);
            pip.AsignadoRecursosInternos = Helper.GetDecimal(reader["AsignadoRecursosInternos"]);
            pip.AsignadoRecursosExternos = Helper.GetDecimal(reader["AsignadoRecursosExternos"]);

            pip.Actualizado = Helper.GetDecimal(reader["Actualizado"]);
            pip.ActualizadoRecursosInternos = Helper.GetDecimal(reader["ActualizadoRecursosInternos"]);
            pip.ActualizadoRecursosExternos = Helper.GetDecimal(reader["ActualizadoRecursosExternos"]);

            pip.Ejecutado = Helper.GetDecimal(reader["Ejecutado"]);
            pip.EjecutadoRecursosInternos = Helper.GetDecimal(reader["EjecutadoRecursosInternos"]);
            pip.EjecutadoRecursosExternos = Helper.GetDecimal(reader["EjecutadoRecursosExternos"]);

            return pip;
        }

        #endregion
    }
}

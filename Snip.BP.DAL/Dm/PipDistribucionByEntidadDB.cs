using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Dm;

namespace Snip.BP.Dal.Dm
{
    public class PipDistribucionByEntidadDB
    {

        #region Métodos Públicos

        public static PipDistribucionByEntidadCollection GetList(int anio, int formato)
        {
            PipDistribucionByEntidadCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PipDistribucionByTipoEntidadGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@FormatoNumerico", formato);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PipDistribucionByEntidadCollection();
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

        private static PipDistribucionByEntidad BuildEntityFromReader(IDataReader reader)
        {
            PipDistribucionByEntidad pip = new PipDistribucionByEntidad();

            pip.Anio = Helper.GetInteger(reader["Anio"]);
            pip.IdTipoEntidad = Helper.GetInteger(reader["IdTipoEntidad"]);
            pip.TipoEntidad = Helper.GetString(reader["TipoEntidad"]);

            pip.IdOrigenFondo = Helper.GetString(reader["IdOrigenFondo"]);
            pip.OrigenFondo = Helper.GetString(reader["OrigenFondo"]);

            pip.Programado = Helper.GetDecimal(reader["Programado"]);
            pip.PesoProgramado = Helper.GetDecimal(reader["PesoProgramado"]);
            pip.Ejecutado = Helper.GetDecimal(reader["Ejecutado"]);
            pip.PorcentajeEjecutado = Helper.GetDecimal(reader["PorcentajeEjecutado"]);
            pip.TasaCambio = Helper.GetDecimal(reader["TasaCambio"]);

            pip.InicioGrupo = Helper.GetBoolean(reader["InicioGrupo"]);
            return pip;
        }

        #endregion
    }
}

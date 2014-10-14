using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.Bp
{
    public class FinanciamientoDB
    {
        #region Métodos Públicos

        public static FinanciamientoCollection GetList(int codObra, int anio)
        {
            FinanciamientoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].FinanciamientoGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodObra", codObra);
                    command.Parameters.AddWithValue("@Anio", anio);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new FinanciamientoCollection();
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

        private static Financiamiento BuildEntityFromReader(IDataReader reader)
        {
            Financiamiento financiamiento = new Financiamiento();
            
            financiamiento.CodAgencia = Helper.GetInteger(reader["CodAgencia"]);
            financiamiento.CodFuente = Helper.GetInteger(reader["CodFuente"]);
            financiamiento.CodConvenio = Helper.GetInteger(reader["CodConvenio"]);
            financiamiento.MontoAsignado = Helper.GetDecimal(reader["MontoAsignado"]);

            financiamiento.IdPip = Helper.GetInteger(reader["IdPip"]);
            financiamiento.IdMomento = Helper.GetInteger(reader["IdMomento"]);
            financiamiento.IdFase = Helper.GetString(reader["IdFase"]);

            financiamiento.Agencia.Nombre = Helper.GetString(reader["Agencia"]);
            financiamiento.Fuente.Nombre = Helper.GetString(reader["Fuente"]);
            financiamiento.Convenio.Nombre = Helper.GetString(reader["Convenio"]);
            financiamiento.Convenio.IdExterno = Helper.GetString(reader["IdExterno"]);

            return financiamiento;
        }

        #endregion

    }
}

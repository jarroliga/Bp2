using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;

namespace Snip.BP.Dal.Bps
{
    public class TipoProcedimientoDB
    {
        #region Métodos Públicos

        public static TipoProcedimiento GetItem(int codigo)
        {
            TipoProcedimiento entidad = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].TipoProcedimientoGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodTipoProcedimiento", codigo);
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
        public static TipoProcedimientoCollection GetList()
        {
            TipoProcedimientoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].TipoProcedimientoGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new TipoProcedimientoCollection();
                            while (reader.Read())
                            {
                                lista.Add(BuildEntityFromReader(reader));
                            }
                        }
                        reader.Close();
                    }
                }
            }
            return lista;
        }
        #endregion

        #region Métodos privados

        private static TipoProcedimiento BuildEntityFromReader(IDataRecord reader)
        {
            TipoProcedimiento tipoProcedimiento = new TipoProcedimiento();

            tipoProcedimiento.Codigo = Helper.GetInteger(reader["CodTipoProcedimiento"]);
            tipoProcedimiento.Nombre = Helper.GetString(reader["Nombre"]);
                        
            return tipoProcedimiento;
        }

        #endregion

    }
}

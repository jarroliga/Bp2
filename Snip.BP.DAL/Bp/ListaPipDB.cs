using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.Bp
{
    public class ListaPipDB
    {
        #region Métodos Públicos

        public static ListaPip GetItem(int codigo)
        {
            ListaPip listaPip = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ListaPipGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodListaPip", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            listaPip = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return listaPip;
        }
        public static ListaPipCollection GetList()
        {
            ListaPipCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ListaPipGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new ListaPipCollection();
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

        #region Métodos Privados

        private static ListaPip BuildEntityFromReader(IDataReader reader)
        {
            ListaPip listaPip = new ListaPip();

            listaPip.Codigo = Helper.GetInteger(reader["CodListaPip"]);
            listaPip.Nombre = Helper.GetString(reader["Nombre"].ToString());
            listaPip.Anio = Helper.GetInteger(reader["Anio"]);
            listaPip.Rol = Helper.GetString(reader["Rol"]);
            listaPip.Identificador = Helper.GetString(reader["IdListaPip"]);
            listaPip.Orden = Helper.GetInteger(reader["Orden"]);
            listaPip.Activa = Helper.GetBoolean(reader["Activa"]);
            listaPip.CodListaProyecto = Helper.GetInteger(reader["CodListaProyecto"]);
            listaPip.CodPip = Helper.GetInteger(reader["CodPip"]);
            listaPip.CodMomento = Helper.GetInteger(reader["CodMomento"]);

            return listaPip;
        }

        #endregion
    }
}

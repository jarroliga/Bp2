using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.Bp
{
    public class ListaFiltroDB
    {
        #region Métodos Públicos

        public static ListaFiltro GetItem(int codigo)
        {
            ListaFiltro ListaFiltro = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ListaFiltroGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodListaFiltro", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ListaFiltro = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return ListaFiltro;
        }
        public static ListaFiltroCollection GetList()
        {
            ListaFiltroCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ListaFiltroGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new ListaFiltroCollection();
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

        private static ListaFiltro BuildEntityFromReader(IDataReader reader)
        {
            ListaFiltro ListaFiltro = new ListaFiltro();

            ListaFiltro.Codigo = Helper.GetInteger(reader["CodListaFiltro"]);
            ListaFiltro.Nombre = Helper.GetString(reader["Nombre"].ToString());
            ListaFiltro.Descripcion = Helper.GetString(reader["Descripcion"].ToString());
            ListaFiltro.Anio = Helper.GetInteger(reader["Anio"]);
            ListaFiltro.Rol = Helper.GetString(reader["Rol"]);
            ListaFiltro.Identificador = Helper.GetString(reader["IdListaFiltro"]);
            ListaFiltro.Orden = Helper.GetInteger(reader["Orden"]);
            ListaFiltro.Activa = Helper.GetBoolean(reader["Activa"]);
            ListaFiltro.CodPip = Helper.GetInteger(reader["CodPip"]);
            ListaFiltro.CodMomento = Helper.GetInteger(reader["CodMomento"]);

            return ListaFiltro;
        }

        #endregion
    }
}

using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    public class ParametroDB
    {
        public static Parametro GetItem(int codigo)
        {
            Parametro parametro = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].ParametroGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodParametro", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            parametro = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return parametro;
        }
        public static Parametro GetItemById(string idParametro)
        {
            Parametro parametro = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].ParametroGetItemById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdParametro", idParametro);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            parametro = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return parametro;
        }
        private static Parametro BuildEntityFromReader(IDataReader reader)
        {
            Parametro parametro = new Parametro();

            parametro.Codigo = Helper.GetInteger(reader["CodParametro"]);
            parametro.Nombre = Helper.GetString(reader["Nombre"]);
            parametro.Descripcion = Helper.GetString(reader["Descripcion"]);
            parametro.IdParametro = Helper.GetString(reader["IdParametro"]);
            parametro.ValorParametro = Helper.GetString(reader["ValorParametro"]);
            parametro.Activo = Helper.GetBoolean(reader["Activo"]);

            Aplicacion app = new Aplicacion();
            app.Codigo = Helper.GetInteger(reader["CodAplicacion"]);
            app.Nombre = Helper.GetString(reader["Aplicacion"]);
            app.IdAplicacion = Helper.GetString(reader["IdAplicacion"]);

            parametro.Aplicacion = app;

            return parametro;
        }
    }
}

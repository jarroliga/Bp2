using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    public class OpcionDB
    {
        #region Métodos Públicos

        public static Opcion GetItem(int codigo)
        {
            Opcion opcion = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].OpcionGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodOpcion", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            opcion = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return opcion;
        }
        public static OpcionCollection GetList(int codAplicacion)
        {
            OpcionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].OpcionGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodAplicacion", codAplicacion);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new OpcionCollection();
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
        public static OpcionCollection GetListByPerfil(int codPerfil)
        {
            OpcionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].OpcionGetListByPerfil", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodPerfil", codPerfil);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new OpcionCollection();
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

        private static Opcion BuildEntityFromReader(IDataReader reader)
        {
            Opcion opcion = new Opcion();

            opcion.Codigo = Helper.GetInteger(reader["CodOpcion"]);
            opcion.Nombre = Helper.GetString(reader["Nombre"]);
            opcion.IdOpcion = Helper.GetString(reader["IdOpcion"]);
            opcion.Activa = Helper.GetBoolean(reader["Activa"]);

            Aplicacion app = new Aplicacion();

            app.Codigo = Helper.GetInteger(reader["CodAplicacion"]);
            app.Nombre = Helper.GetString(reader["Aplicacion"]);
            app.IdAplicacion = Helper.GetString(reader["IdAplicacion"]);

            opcion.Aplicacion = app;

            return opcion;
        }

        #endregion
    }
}

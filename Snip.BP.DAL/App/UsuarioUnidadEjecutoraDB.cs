using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    public class UsuarioUnidadEjecutoraDB
    {
        public static UsuarioUnidadEjecutora GetItem(int codUsuario, int codUnidadEjecutora)
        {
            UsuarioUnidadEjecutora usuarioUnidadEjecutora = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].UsuarioUnidadEjecutoraGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    command.Parameters.AddWithValue("@CodUnidadEjecutora", codUnidadEjecutora);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuarioUnidadEjecutora = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return usuarioUnidadEjecutora;
        }
        public static UsuarioUnidadEjecutoraCollection GetList(int codUsuario)
        {
            return GetList(codUsuario, -1);
        }
        public static UsuarioUnidadEjecutoraCollection GetList(int codUsuario, int anioPip)
        {
            UsuarioUnidadEjecutoraCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].UsuarioUnidadEjecutoraGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    command.Parameters.AddWithValue("@Anio", anioPip);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new UsuarioUnidadEjecutoraCollection();
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
        private static UsuarioUnidadEjecutora BuildEntityFromReader(IDataReader reader)
        {
            UsuarioUnidadEjecutora usuarioUE = new UsuarioUnidadEjecutora();

            usuarioUE.Usuario.Codigo = Helper.GetInteger(reader["CodUsuario"]);
            
            usuarioUE.UnidadEjecutora.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
            usuarioUE.UnidadEjecutora.Nombre = Helper.GetString(reader["UnidadEjecutora"]);
            usuarioUE.UnidadEjecutora.Siglas = Helper.GetString(reader["Siglas"]);

            return usuarioUE;
        }
    }
}

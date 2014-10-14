using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    public class UsuarioPerfilDB
    {

        public static UsuarioPerfil GetItem(int codUsuario, int codAplicacion)
        {
            UsuarioPerfil usuarioPerfil = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].UsuarioPerfilGetItemByAplicacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    command.Parameters.AddWithValue("@CodAplicacion", codAplicacion);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuarioPerfil = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return usuarioPerfil;
        }
        public static string GetIdPerfilByAplication(int codUsuario, int codAplicacion)
        {
            string idPerfil = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[app].UsuarioPerfilGetIdPerfilByAplication", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CodUsuario", codUsuario);
                        command.Parameters.AddWithValue("@CodAplicacion", codAplicacion);
                        connection.Open();

                        idPerfil = (string)command.ExecuteScalar();

                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                DataAccessExceptionHandler.HandleException(e.Message);
            }
            finally
            {
            }
            return idPerfil;
        }
        public static UsuarioPerfilCollection GetList(int codUsuario)
        {
            UsuarioPerfilCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].UsuarioPerfilGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodUsuario", codUsuario);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new UsuarioPerfilCollection();
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
        private static UsuarioPerfil BuildEntityFromReader(IDataReader reader)
        {
            UsuarioPerfil usuarioPerfil = new UsuarioPerfil();

            usuarioPerfil.CodUsuario = Helper.GetInteger(reader["CodUsuario"]);

            Perfil perfil = new Perfil();

            perfil.Codigo = Helper.GetInteger(reader["CodPerfil"]);
            perfil.Nombre = Helper.GetString(reader["Nombre"]);
            perfil.IdPerfil = Helper.GetString(reader["IdPerfil"]);
            perfil.Descripcion = Helper.GetString(reader["Descripcion"]);
            perfil.EsInterno = Helper.GetBoolean(reader["EsInterno"]);
            perfil.Activo = Helper.GetBoolean(reader["Activo"]);

            Aplicacion aplicacion = new Aplicacion();
            aplicacion.Codigo = Helper.GetInteger(reader["CodAplicacion"]);
            aplicacion.Nombre = Helper.GetString(reader["Aplicacion"]);
            aplicacion.IdAplicacion = Helper.GetString(reader["IdAplicacion"]);

            perfil.Aplicacion = aplicacion;

            usuarioPerfil.Perfil = perfil;

            return usuarioPerfil;
        }
    }
}

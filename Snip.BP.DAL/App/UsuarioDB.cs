using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;
using Snip.BP.Validation;

namespace Snip.BP.Dal.App
{
    /// <summary>
    /// La clase UsuarioDB es la responsable de interactuar con la base de datos para recuperar
    /// y almacenar información sobre objetos <see cref="Opcion">Usuario del BP SNIP</see>.
    /// </summary>
    public class UsuarioDB
    {
        #region Métodos Públicos

        public static Usuario GetItem(int codigo)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].UsuarioGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodUsuario", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return usuario;
        }
        public static Usuario GetItemByLogin(string login)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].UsuarioGetItemByLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Login", login);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return usuario;
        }
        public static UsuarioCollection GetList(int codInstitucion, int pageIndex, int pageSize, string orderField, bool orderDirection,
                string searchValue, string filterCriteria, string filterValue, ref int totalRecords)
        {
            UsuarioCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].UsuarioGetListPaged", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodInstitucion", codInstitucion);
                    command.Parameters.AddWithValue("@PageIndex", pageIndex);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@OrderField", orderField);
                    command.Parameters.AddWithValue("@OrderDirection", orderDirection);
                    command.Parameters.AddWithValue("@SearchValue", searchValue);
                    command.Parameters.AddWithValue("@FilterCriteria", filterCriteria);
                    command.Parameters.AddWithValue("@FilterValue", filterValue);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                totalRecords = Convert.ToInt32(reader.GetValue(0));
                            }
                            reader.NextResult();

                            lista = new UsuarioCollection();
                            while (reader.Read())
                            {
                                lista.Add(BuildEntityFromReader(reader, true));
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return lista;
        }
        public static int Save(Usuario usuario)
        {
            if (!usuario.Validate())
            {
                throw new InvalidSaveOperationException("No se ha podido salvar el registro. Datos invalidos.!!");
            }
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[app].UsuarioInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@Email", usuario.Email);
                        command.Parameters.AddWithValue("@Login", usuario.Login);
                        command.Parameters.AddWithValue("@Password", usuario.Password);
                        command.Parameters.AddWithValue("@Salt", usuario.Salt);
                        command.Parameters.AddWithValue("@Habilitado", usuario.Habilitado);
                        command.Parameters.AddWithValue("@EsInterno", usuario.EsInterno);
                        command.Parameters.AddWithValue("@CodInstitucion", usuario.Institucion.Codigo);
                        command.Parameters.AddWithValue("@CodUsuario", usuario.CodUsuarioActualizacion);

                        Helper.SetSaveParameters(command, usuario);
                        connection.Open();

                        int registrosAfectados = command.ExecuteNonQuery();
                        if (registrosAfectados == 0)
                        {
                            throw new DBConcurrencyException("No se pudo salvar el registro en la Base de Datos.");
                        }
                        result = Helper.GetBusinessBaseId(command);
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                DataAccessExceptionHandler.HandleException(e.Message);
            }
            return result;
        }
        public static bool Delete(int codigo)
        {
            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[app].UsuarioDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CodUsuario", codigo);
                        connection.Open();

                        result = command.ExecuteNonQuery();

                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                DataAccessExceptionHandler.HandleException(e.Message);
            }
            return result > 0;
        }
        #endregion

        #region Métodos Privados

        private static Usuario BuildEntityFromReader(IDataReader reader)
        {
            return BuildEntityFromReader(reader, false);
        }

        private static Usuario BuildEntityFromReader(IDataReader reader, bool isList)
        {
            Usuario usuario = new Usuario();
            
            usuario.Codigo = Helper.GetInteger(reader["CodUsuario"]);
            usuario.Nombre = Helper.GetString(reader["Nombre"]);
            usuario.Apellido = Helper.GetString(reader["Apellido"]);
            usuario.Email = Helper.GetString(reader["EMail"]);
            usuario.Habilitado = Helper.GetBoolean(reader["Habilitado"]);
            usuario.EsInterno = Helper.GetBoolean(reader["EsInterno"]);
            usuario.FechaUltimoAcceso = Helper.GetNullableDateTime(reader["FechaUltimoAcceso"]);
            usuario.FechaCreacion = Helper.GetDateTime(reader["FechaCreacion"]);
            usuario.Login = Helper.GetString(reader["Login"]);

            if (!isList)
            {
                usuario.Password = Helper.GetString(reader["Password"]);
                usuario.Salt = Helper.GetString(reader["Salt"]);
            }
       
            Institucion institucion = new Institucion();
            institucion.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
            institucion.Nombre = Helper.GetString(reader["Institucion"]);
            institucion.Siglas = Helper.GetString(reader["Siglas"]);

            usuario.Institucion = institucion;

            return usuario;
        }

        #endregion

    }
}

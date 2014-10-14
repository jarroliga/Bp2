using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    public class BitacoraDB
    {
        #region Métodos Públicos

        public static Bitacora GetItem(int codigo)
        {
            Bitacora bitacora = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].BitacoraGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodBitacora", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bitacora = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return bitacora;
        }
        public static BitacoraCollection GetList()
        {
            BitacoraCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].BitacoraGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new BitacoraCollection();
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

        public static int Save(Bitacora bitacora)
        {
            int result = 0;

            if (bitacora == null)
                return result;
            if (!bitacora.Validate())
                return result;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].BitacoraInsertUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CodTabla", bitacora.Tabla.Codigo);
                    command.Parameters.AddWithValue("@CodEvento", bitacora.Evento.Codigo);
                    command.Parameters.AddWithValue("@CodRegistro", bitacora.CodRegistro);
                    command.Parameters.AddWithValue("@Referencia", bitacora.Referencia);
                    command.Parameters.AddWithValue("@CodUsuario", bitacora.Usuario.Codigo);
                    
                    Helper.SetSaveParameters(command, bitacora);

                    connection.Open();

                    int registrosAfectados = command.ExecuteNonQuery();

                    if (registrosAfectados == 0)
                    {
                        throw new DBConcurrencyException("No se pudo salvar el registro en la Base de Datos.");
                    }

                    // aplicacion.IdConcurrencia = Helper.GetConcurrencyId(command);
                    result = Helper.GetBusinessBaseId(command);

                }
                connection.Close();
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
                    using (SqlCommand command = new SqlCommand("[app].BitacoraDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Codigo", codigo);
                        connection.Open();
                        result = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                DataAccessExceptionHandler.HandleException(ex.Message);
            }
            return result > 0;
        }
        #endregion

        #region Métodos Privados

        private static Bitacora BuildEntityFromReader(IDataReader reader)
        {
            Bitacora bitacora = new Bitacora();

            bitacora.Codigo = Helper.GetInteger(reader["CodBitacora"]);
            bitacora.CodRegistro = Helper.GetInteger(reader["CodRegistro"]);
            bitacora.Referencia = Helper.GetString(reader["Referencia"]);

            Tabla tabla = new Tabla();

            tabla.Codigo = Helper.GetInteger(reader["CodTabla"]);
            tabla.Nombre = Helper.GetString(reader["Tabla"]);

            bitacora.Tabla = tabla;

            Evento evento = new Evento();

            evento.Codigo = Helper.GetInteger(reader["CodEvento"]);
            evento.Nombre = Helper.GetString(reader["Evento"]);

            bitacora.Evento = evento;

            Usuario usuario = new Usuario();

            usuario.Codigo = Helper.GetInteger(reader["CodUsuario"]);
            usuario.Login = Helper.GetString(reader["Login"]);

            bitacora.Usuario = usuario;

            return bitacora;
        }

        #endregion
    }
}

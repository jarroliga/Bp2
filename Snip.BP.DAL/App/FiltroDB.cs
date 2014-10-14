using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;

namespace Snip.BP.Dal.App
{
    public class FiltroDB
    {
        #region Métodos públicos

        public static Filtro GetItem(string codSession, string codTipoFiltro)
        {
            Filtro filtro = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[app].FiltroGetItem", connection))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@CodSession", codSession);
                    comando.Parameters.AddWithValue("@CodTipoFiltro", codTipoFiltro);

                    connection.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            filtro = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return filtro;
        }

        public static FiltroCollection GetList(int codSession)
        {
            FiltroCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].FiltroGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodSession", codSession);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new FiltroCollection();
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
        public static int Save(Filtro filtro)
        {
            int result = 0;

            using (SqlConnection conexion = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[app].FiltroInsert", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@CodSession", filtro.CodSession);
                    comando.Parameters.AddWithValue("@CodTipoFiltro", filtro.TipoFiltro.Codigo);
                    comando.Parameters.AddWithValue("@Expresion", filtro.Expresion);

                    conexion.Open();

                    int registrosAfectados = comando.ExecuteNonQuery();

                    if (registrosAfectados == 0)
                    {
                        throw new DBConcurrencyException("No se puede guardar el registro en la Base de Datos.");
                    }

                    result = registrosAfectados;

                }
                conexion.Close();
            }
            return result;
        }

        public static bool Delete(int codSession, int codTipoFiltro)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[app].FiltroDelete", connection))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("CodSession", codSession);
                    comando.Parameters.AddWithValue("CodTipoFiltro", codTipoFiltro);
                    connection.Open();
                    result = comando.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result > 0;
        }

        #endregion

        #region Métodos privados

        private static Filtro BuildEntityFromReader(IDataReader reader)
        {
            Filtro filtro = new Filtro();

            // filtro.TipoFiltro.Codigo = Helper.GetInteger(reader["CodTipoFiltro"]);

            TipoFiltro tipoFiltro = new TipoFiltro();

            tipoFiltro.Codigo = Helper.GetInteger(reader["CodTipoFiltro"]);
            tipoFiltro.IdFiltro = Helper.GetString(reader["IdFiltro"]);
            tipoFiltro.Nombre = Helper.GetString(reader["TipoFiltro"]);

            filtro.TipoFiltro = tipoFiltro;

            filtro.Expresion = Helper.GetString(reader["FiltroExpresion"]);

            return filtro;
        }

        #endregion
    }
}

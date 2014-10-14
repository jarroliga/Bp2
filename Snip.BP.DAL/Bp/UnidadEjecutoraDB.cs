using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.Bp
{
    public class UnidadEjecutoraDB
    {
        #region Metodos Publicos

        public static UnidadEjecutora GetItem(int codigo)
        {
            UnidadEjecutora unidadEjecutora = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].UnidadEjecutoraGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            unidadEjecutora = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return unidadEjecutora;
        }
        public static UnidadEjecutoraCollection GetList(int codInstitucion)
        {
            UnidadEjecutoraCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].UnidadEjecutoraGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodInstitucion", codInstitucion);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new UnidadEjecutoraCollection();
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
        public static UnidadEjecutoraCollection GetListPaged(int codInstitucion, int pageIndex, int pageSize, string orderField, bool orderDirection,
             string searchValue, string filterCriteria, string filterValue, ref int totalRecords)
        {
            UnidadEjecutoraCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].UnidadEjecutoraGetListPaged", connection))
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

                            lista = new UnidadEjecutoraCollection();
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
        public static int Save(UnidadEjecutora unidadEjecutora)
        {
            int result = 0;

            using (SqlConnection conexion = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[bp].UnidadEjecutoraSave", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Codigo", unidadEjecutora.Codigo);
                    comando.Parameters.AddWithValue("@CodInstitucion", unidadEjecutora.Institucion.Codigo);
                    comando.Parameters.AddWithValue("@Nombre", unidadEjecutora.Codigo);
                    comando.Parameters.AddWithValue("@Siglas", unidadEjecutora.Siglas);
                    comando.Parameters.AddWithValue("@CodEntidadSigfa", unidadEjecutora.CodEntidadSigfa);

                    comando.Parameters.AddWithValue("@Activo", unidadEjecutora.Activo);

                    conexion.Open();

                    int registrosAfectados = comando.ExecuteNonQuery();

                    if (registrosAfectados == 0)
                    {
                        throw new DBConcurrencyException("No se puede guardar el registro en la Base de Datos.");
                    }

                    result = Helper.GetBusinessBaseId(comando);

                }
                conexion.Close();
            }
            return result;
        }
        public static bool Delete(int codigo)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodUnidadEjecutora", codigo);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result > 0;
        }

        #endregion

        #region Metodos Privados

        private static UnidadEjecutora BuildEntityFromReader(IDataReader reader)
        {
            return BuildEntityFromReader(reader, false);
        }
        private static UnidadEjecutora BuildEntityFromReader(IDataReader reader, bool lazyLoad)
        {
            UnidadEjecutora unidadEjecutora = new UnidadEjecutora();

            unidadEjecutora.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
            unidadEjecutora.Nombre = Helper.GetString(reader["Nombre"]);
            unidadEjecutora.Siglas = Helper.GetString(reader["Siglas"]);
            unidadEjecutora.Activo = Helper.GetBoolean(reader["Activo"]);

            Institucion institucion = new Institucion();
            institucion.Codigo = Helper.GetInteger(reader["CodInstitucion"]);

            if (!lazyLoad)
            {
                unidadEjecutora.CodEntidadSigfa = Helper.GetInteger(reader["CodEntidadSigfa"]);
                
                institucion.Nombre = Helper.GetString(reader["Institucion"]);
                institucion.Siglas = Helper.GetString(reader["Siglas"]);

                unidadEjecutora.Institucion = institucion;    
            }
            
            return unidadEjecutora;
        }
        #endregion
    }
}

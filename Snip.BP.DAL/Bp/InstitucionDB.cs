using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.Bp
{
    public class InstitucionDB
    {
        #region Metodos Publicos

        public static Institucion GetItem(int codigo)
        {
            Institucion institucion = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].InstitucionGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            institucion = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return institucion;
        }
        public static InstitucionCollection GetList(int codigoP)
        {
            InstitucionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].InstitucionGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodSectorInstitucional", codigoP);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new InstitucionCollection();
                            while(reader.Read())
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
        public static InstitucionCollection GetListPaged(int codSectorInstitucional, int pageIndex, int pageSize, string orderField, bool orderDirection, 
             string searchValue, string filterCriteria, string filterValue, ref int totalRecords)
        {
            InstitucionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].InstitucionGetListPaged", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodSectorInstitucional", codSectorInstitucional);
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

                            lista = new InstitucionCollection();
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
        public static int Save(Institucion institucion)
        {
            int result = 0;

            using (SqlConnection conexion = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[bp].InstitucionInsertUpdate", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Codigo", institucion.Codigo);
                    comando.Parameters.AddWithValue("@CodClasificadorInstitucional", institucion.ClasificadorInstitucional.Codigo);
                    comando.Parameters.AddWithValue("@Nombre", institucion.Codigo);
                    comando.Parameters.AddWithValue("@Siglas", institucion.Siglas);
                    comando.Parameters.AddWithValue("@Etiqueta", institucion.Etiqueta);
                    comando.Parameters.AddWithValue("@IdTipo", institucion.IdTipo);
                    comando.Parameters.AddWithValue("@CodInstitucionAnterior", institucion.CodInstitucionAnterior);

                    comando.Parameters.AddWithValue("@Activo", institucion.Activo);

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
                    command.Parameters.AddWithValue("@CodInstitucion", codigo);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result > 0;
        }

        #endregion

        #region Metodos Privados

        private static Institucion BuildEntityFromReader(IDataReader reader)
        {
            return BuildEntityFromReader(reader, false); 
        }
        private static Institucion BuildEntityFromReader(IDataReader reader, bool lazyLoad)
        {
            Institucion institucion = new Institucion();

            institucion.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
            institucion.Nombre = Helper.GetString(reader["Nombre"]);
            institucion.Siglas = Helper.GetString(reader["Siglas"]);
            institucion.IdTipo = Helper.GetString(reader["IdTipo"]);
            institucion.Activo = Helper.GetBoolean(reader["Activo"]);

            ClasificadorInstitucional clasificadorInst = new ClasificadorInstitucional();
            clasificadorInst.Codigo = Helper.GetInteger(reader["CodClasificadorInstitucional"]);

            if (!lazyLoad)
            {
                institucion.Etiqueta = Helper.GetString(reader["Etiqueta"]);
                institucion.CodInstitucionAnterior = Helper.GetInteger(reader["CodInstitucionAnterior"]);
                                
                clasificadorInst.Nombre = Helper.GetString(reader["ClasificadorInstitucional"]);

                institucion.ClasificadorInstitucional = clasificadorInst;
            }

            return institucion;
        }
        #endregion

    }
}

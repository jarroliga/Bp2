using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.Bp
{
    public class ClasificadorInstitucionalDB
    {
        #region Metodos Publicos

        public static ClasificadorInstitucional GetItem(int codigo)
        {
            ClasificadorInstitucional sectorInstitucional = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ClasificadorInstitucionalGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sectorInstitucional = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return sectorInstitucional;
        }
        public static ClasificadorInstitucionalCollection GetList()
        {
            ClasificadorInstitucionalCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ClasificadorInstitucionalGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new ClasificadorInstitucionalCollection();
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
        public static int Save(ClasificadorInstitucional sectorInstitucional)
        {
            int result = 0;

            using (SqlConnection conexion = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("[bp].ClasificadorInstitucionalInsertUpdate", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdClasificadorInstitucional", sectorInstitucional.IdClasificadorInstitucional);
                    comando.Parameters.AddWithValue("@Nombre", sectorInstitucional.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", sectorInstitucional.Descripcion);
                    comando.Parameters.AddWithValue("@Nivel", sectorInstitucional.Descripcion);
                    comando.Parameters.AddWithValue("@Activo", sectorInstitucional.Activo);

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
                using (SqlCommand command = new SqlCommand("[bp].ClasificadorInstitucionalDelete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodClasificadorInstitucional", codigo);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result > 0;
        }

        #endregion

        #region Metodos Privados

        private static ClasificadorInstitucional BuildEntityFromReader(IDataReader reader)
        {
            ClasificadorInstitucional obj = new ClasificadorInstitucional();

            obj.Codigo = Helper.GetInteger(reader["CodClasificadorInstitucional"]);
            obj.IdClasificadorInstitucional = Helper.GetString(reader["IdClasificadorInstitucional"]);
            obj.Nombre = Helper.GetString(reader["Nombre"]);
            obj.Descripcion = Helper.GetString(reader["Descripcion"]);
            obj.Nivel = Helper.GetInteger(reader["Nivel"]);
            obj.Activo = Helper.GetBoolean(reader["Activo"]);
            
            return obj;
        }
        #endregion
    }
}

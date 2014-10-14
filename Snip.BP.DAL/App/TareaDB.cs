using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    public class TareaDB
    {
        public static Tarea GetItem(int codigo)
        {
            Tarea tarea = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].TareaGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodTarea", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tarea = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return tarea;
        }
        public static Tarea GetItemById(string id)
        {
            Tarea tarea = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].TareaGetItemById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdTarea", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tarea = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return tarea;
        }
        private static Tarea BuildEntityFromReader(IDataReader reader)
        {
            Tarea tarea = new Tarea();

            tarea.Codigo = Helper.GetInteger(reader["CodTarea"]);
            tarea.Nombre = Helper.GetString(reader["Nombre"]);
            tarea.Identificador = Helper.GetString(reader["IdTarea"]);

            return tarea;
        }
    }
}

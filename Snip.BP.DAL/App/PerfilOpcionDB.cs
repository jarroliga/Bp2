using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    public class PerfilOpcionDB
    {
        #region Métodos Públicos

        public static PerfilOpcion GetItem(int codPerfil, int codOpcion)
        {
            PerfilOpcion perfilOpcion = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].PerfilOpcionGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodPerfil", codPerfil);
                    command.Parameters.AddWithValue("@CodOpcion", codOpcion);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            perfilOpcion = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return perfilOpcion;
        }
        public static PerfilOpcionCollection GetList(int codPerfil)
        {
            PerfilOpcionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].PerfilOpcionGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodPerfil", codPerfil);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PerfilOpcionCollection();
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
        #endregion

        #region Métodos Privados

        private static PerfilOpcion BuildEntityFromReader(IDataReader reader)
        {
            PerfilOpcion perfilOpcion = new PerfilOpcion();

            Opcion opcion = new Opcion();

            perfilOpcion.CodPerfil = Helper.GetInteger(reader["CodPerfil"]);                        
            perfilOpcion.CodOpcion = Helper.GetInteger(reader["CodOpcion"]);
            
            opcion.Nombre = Helper.GetString(reader["Nombre"]);
            opcion.IdOpcion = Helper.GetString(reader["IdOpcion"]);

            perfilOpcion.Opcion = opcion;

            return perfilOpcion;
        }

        #endregion
    }
}

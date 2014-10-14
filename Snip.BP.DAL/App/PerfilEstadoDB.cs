using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.App
{
    public class PerfilEstadoDB
    {
        #region Métodos Públicos

        public static PerfilEstado GetItem(int codPerfil, int codEstado)
        {
            PerfilEstado perfil = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].PerfilEstadoGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodPerfil", codPerfil);
                    command.Parameters.AddWithValue("@CodEstado", codEstado);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            perfil = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return perfil;
        }
        public static PerfilEstadoCollection GetList(int codPerfil)
        {
            PerfilEstadoCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[app].PerfilEstadoGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodPerfil", codPerfil);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PerfilEstadoCollection();
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

        private static PerfilEstado BuildEntityFromReader(IDataReader reader)
        {
            PerfilEstado perfilEstado = new PerfilEstado();

            perfilEstado.CodPerfil = Helper.GetInteger(reader["CodPerfil"]);
            perfilEstado.CodEstado = Helper.GetInteger(reader["CodEstado"]);

            return perfilEstado;
        }

        #endregion
    }
}

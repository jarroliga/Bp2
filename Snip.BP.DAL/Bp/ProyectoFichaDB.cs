using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;

namespace Snip.BP.Dal.Bp
{
    public class ProyectoFichaDB
    {
        #region Métodos Públicos

        public static ProyectoFicha GetItem(int codigo)
        {
            ProyectoFicha ficha = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bp].ProyectoFichaGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodProyecto", codigo);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ficha = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return ficha;
        }
        #endregion

        private static ProyectoFicha BuildEntityFromReader(IDataReader reader)
        {
            ProyectoFicha ficha = new ProyectoFicha();

            ficha.CodProyecto = Helper.GetInteger(reader["CodProy"]);
            ficha.Descripcion = Helper.GetString(reader["Descripcion"]);
            ficha.ObjetivosEspecificos = Helper.GetString(reader["ObjetivosEspecificos"]);
            ficha.ObjetivosDesarrollo = Helper.GetString(reader["ObjetivosDesarrollo"]);
            ficha.Justificacion = Helper.GetString(reader["Justificacion"]);
            ficha.AspectosOperativos = Helper.GetString(reader["AspectosOperativos"]);
            ficha.Beneficios = Helper.GetString(reader["Beneficios"]);
            
            return ficha;
        }
    }
}

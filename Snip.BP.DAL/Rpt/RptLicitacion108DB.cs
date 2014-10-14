using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Snip.BP.BO.Rpt;

namespace Snip.BP.Dal.Rpt
{
    public class RptLicitacion108DB
    {
        public static DataSet GetList(int anio, int codInstitucion, int codFiltro, int codListaFiltro)
        {
            DataSet ds = new dsRptLicitaciones107();

            using (SqlConnection conexion = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[rpt].BpsListLicitacionesObrasPIPCompromisos", conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@CodInstitucion", codInstitucion);
                    command.Parameters.AddWithValue("@CodFiltro", codFiltro);
                    command.Parameters.AddWithValue("@CodListaFiltro", codListaFiltro);
                    conexion.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            ds.Tables[0].Load(reader);
                        }
                        conexion.Close();
                        return ds;
                    }
                }
            }
        }
    }
}

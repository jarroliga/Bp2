using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Snip.BP.BO.Rpt;

namespace Snip.BP.Dal.Rpt
{
    public class RptLicitacion104DB
    {
        public static DataSet GetList(int anio, int codInstitucion)
        {
            DataSet ds = new dsRptLicitaciones104();

            using (SqlConnection conexion = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[rpt].BpsListLicitacionesAContratarPorTrimestre", conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@CodInstitucion", codInstitucion);
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

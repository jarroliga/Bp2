using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Dm;

namespace Snip.BP.Dal.Dm
{
    public class PipInstitucionEntidadDB
    {
        #region Métodos Públicos

        public static PipInstitucionEntidad GetItem(int codInstitucion, int idTipoEntidad, int anio, int formato)
        {
            PipInstitucionEntidad presupInst = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PipInstitucionEntidadGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodInstitucion", codInstitucion);
                    command.Parameters.AddWithValue("@IdTipoEntidad", idTipoEntidad);
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@FormatoNumerico", formato);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            presupInst = BuildEntityFromReader(reader);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return presupInst;
        }
        public static PipInstitucionEntidadCollection GetList(int anio, int idTipoEntidad, int formato)
        {
            PipInstitucionEntidadCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PipInstitucionEntidadGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@IdTipoEntidad", idTipoEntidad);
                    command.Parameters.AddWithValue("@FormatoNumerico", formato);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PipInstitucionEntidadCollection();
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

        #endregion

        #region Métodos Privados

        private static PipInstitucionEntidad BuildEntityFromReader(IDataReader reader)
        {
            PipInstitucionEntidad pipInst = new PipInstitucionEntidad();

            pipInst.Anio = Helper.GetInteger(reader["Anio"]);

            pipInst.IdTipoEntidad = Helper.GetInteger(reader["IdTipoEntidad"]);
            pipInst.TipoEntidad = Helper.GetString(reader["TipoEntidad"]);

            Institucion inst = new Institucion();

            inst.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
            inst.Nombre = Helper.GetString(reader["Institucion"]);
            inst.Siglas = Helper.GetString(reader["Siglas"]);
            inst.IdTipo = Helper.GetString(reader["IdTipo"]);

            pipInst.Institucion = inst;

            OrigenFondo asignado = new OrigenFondo();

            asignado.Prestamo = Helper.GetDecimal(reader["AsignadoPrestamo"]);
            asignado.Donacion = Helper.GetDecimal(reader["AsignadoDonacion"]);
            asignado.Tesoro = Helper.GetDecimal(reader["AsignadoTesoro"]);
            asignado.RecursosPropios = Helper.GetDecimal(reader["AsignadoRecursosPropios"]);

            pipInst.Asignado = asignado;

            OrigenFondo modificaciones = new OrigenFondo();

            modificaciones.Prestamo = Helper.GetDecimal(reader["ModificadoPrestamo"]);
            modificaciones.Donacion = Helper.GetDecimal(reader["ModificadoDonacion"]);
            modificaciones.Tesoro = Helper.GetDecimal(reader["ModificadoTesoro"]);
            modificaciones.RecursosPropios = Helper.GetDecimal(reader["ModificadoRecursosPropios"]);

            pipInst.Modificado = modificaciones;

            OrigenFondo actualizado = new OrigenFondo();

            actualizado.Prestamo = Helper.GetDecimal(reader["ActualizadoPrestamo"]);
            actualizado.Donacion = Helper.GetDecimal(reader["ActualizadoDonacion"]);
            actualizado.Tesoro = Helper.GetDecimal(reader["ActualizadoTesoro"]);
            actualizado.RecursosPropios = Helper.GetDecimal(reader["ActualizadoRecursosPropios"]);

            pipInst.Actualizado = actualizado;

            OrigenFondo ejecutado = new OrigenFondo();

            ejecutado.Prestamo = Helper.GetDecimal(reader["EjecutadoPrestamo"]);
            ejecutado.Donacion = Helper.GetDecimal(reader["EjecutadoDonacion"]);
            ejecutado.Tesoro = Helper.GetDecimal(reader["EjecutadoTesoro"]);
            ejecutado.RecursosPropios = Helper.GetDecimal(reader["EjecutadoRecursosPropios"]);

            pipInst.Ejecutado = ejecutado;

            return pipInst;
        }

        #endregion

    }
}

using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Dm;

namespace Snip.BP.Dal.Dm
{
    public class PipInstitucionDB
    {
        #region Métodos Públicos

        public static PipInstitucion GetItem(int codInstitucion, int anio, int formato)
        {
            PipInstitucion presupInst = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PIPInstitucionGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodInstitucion", codInstitucion);
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
        public static PipInstitucionCollection GetListByAnio(int anio, int formato)
        {
            PipInstitucionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PIPInstitucionGetListByAnio", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@FormatoNumerico", formato);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PipInstitucionCollection();
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
        public static PipInstitucionCollection GetList(int codInstitucion, int formato)
        {
            PipInstitucionCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[dm].PIPInstitucionGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodInstitucion", codInstitucion);
                    command.Parameters.AddWithValue("@FormatoNumerico", formato);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new PipInstitucionCollection();
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

        private static PipInstitucion BuildEntityFromReader(IDataReader reader)
        {
            PipInstitucion pipInst = new PipInstitucion();

            pipInst.Anio = Helper.GetInteger(reader["Anio"]);

            Institucion inst = new Institucion();

            inst.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
            inst.Nombre = Helper.GetString(reader["Institucion"]);
            inst.Siglas = Helper.GetString(reader["Siglas"]);
            inst.IdTipo = Helper.GetString(reader["IdTipo"]);

            pipInst.Institucion = inst;

            pipInst.Proyectos = Helper.GetInteger(reader["Proyectos"]);
            pipInst.Obras = Helper.GetInteger(reader["Obras"]);

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

            pipInst.Licitaciones = Helper.GetInteger(reader["Licitaciones"]);

            OrigenFondo licitado = new OrigenFondo();

            licitado.Prestamo = Helper.GetDecimal(reader["LicitadoPrestamo"]);
            licitado.Donacion = Helper.GetDecimal(reader["LicitadoDonacion"]);
            licitado.Tesoro = Helper.GetDecimal(reader["LicitadoTesoro"]);
            licitado.RecursosPropios = Helper.GetDecimal(reader["LicitadoRecursosPropios"]);

            pipInst.Licitado = licitado;

            pipInst.Contratos = Helper.GetInteger(reader["Contratos"]);

            OrigenFondo contratado = new OrigenFondo();

            contratado.Prestamo = Helper.GetDecimal(reader["ContratadoPrestamo"]);
            contratado.Donacion = Helper.GetDecimal(reader["ContratadoDonacion"]);
            contratado.Tesoro = Helper.GetDecimal(reader["ContratadoTesoro"]);
            contratado.RecursosPropios = Helper.GetDecimal(reader["ContratadoRecursosPropios"]);

            pipInst.Contratado = contratado;

            OrigenFondo ejecutadoContrato = new OrigenFondo();

            ejecutadoContrato.Prestamo = Helper.GetDecimal(reader["EjecutadoCtoPrestamo"]);
            ejecutadoContrato.Donacion = Helper.GetDecimal(reader["EjecutadoCtoDonacion"]);
            ejecutadoContrato.Tesoro = Helper.GetDecimal(reader["EjecutadoCtoTesoro"]);
            ejecutadoContrato.RecursosPropios = Helper.GetDecimal(reader["EjecutadoCtoRecursosPropios"]);

            pipInst.EjecutadoContrato = ejecutadoContrato;

            return pipInst;
        }

        #endregion

    }
}

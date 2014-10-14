using System;
using System.Data;
using System.Data.SqlClient;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Bps;
using Snip.BP.BO.App;
using Snip.BP.Validation;

namespace Snip.BP.Dal.Bps
{
    public class LicitacionBitacoraDB
    {
        #region Métodos Públicos

        public static LicitacionBitacora GetItem(int codLicitacionBitacora)
        {
            LicitacionBitacora bitacora = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].LicitacionBitacoraGetItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacionBitacora", codLicitacionBitacora);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bitacora = BuildEntityFromReader(reader, false);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return bitacora;

        }
        public static LicitacionBitacoraCollection GetList(int codLicitacion)
        {
            LicitacionBitacoraCollection lista = null;

            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("[bps].LicitacionBitacoraGetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodLicitacion", codLicitacion);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            lista = new LicitacionBitacoraCollection();
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
        public static int Save(LicitacionBitacora bitacora)
        {
            int result = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[bps].LicitacionBitacoraInsertUpdate", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CodLicitacion", bitacora.CodLicitacion);
                        command.Parameters.AddWithValue("@CodEstadoActual", bitacora.Licitacion.Estado.Codigo);
                        command.Parameters.AddWithValue("@CodEtapaActual", bitacora.Licitacion.Etapa.Codigo);
                        command.Parameters.AddWithValue("@CodEstadoDestino", bitacora.CodEstado);
                        command.Parameters.AddWithValue("@CodEtapaDestino", bitacora.CodEtapa);
                        command.Parameters.AddWithValue("@Fecha", bitacora.Fecha);

                        if (string.IsNullOrEmpty(bitacora.Observaciones))
                        {
                            command.Parameters.AddWithValue("@Observaciones", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Observaciones", bitacora.Observaciones);
                        }

                        command.Parameters.AddWithValue("@CodUsuario", bitacora.CodUsuario);

                        connection.Open();

                        int registrosAfectados = command.ExecuteNonQuery();

                        if (registrosAfectados == 0)
                        {
                            throw new DBConcurrencyException("No se pudo salvar el registro en la Base de Datos.");
                        }

                        result = registrosAfectados;

                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                DataAccessExceptionHandler.HandleException(e.Message);
            }
            return result;
        }
        #endregion

        #region Métodos privados

        private static LicitacionBitacora BuildEntityFromReader(IDataReader reader, bool lazyLoad)
        {
            LicitacionBitacora bitacora = new LicitacionBitacora();

            bitacora.Codigo = Helper.GetInteger(reader["CodLicitacionBitacora"]);
            bitacora.CodLicitacion = Helper.GetInteger(reader["CodLicitacion"]);

            Licitacion licitacion = new Licitacion();

            licitacion.Codigo = Helper.GetInteger(reader["CodLicitacion"]);

            if(!lazyLoad)
            {
                licitacion.IdLicitacion = Helper.GetString(reader["IdLicitacion"]);
                licitacion.Anio = Helper.GetInteger(reader["Anio"]);
                licitacion.Nombre = Helper.GetString(reader["Licitacion"]);
                licitacion.Costo = Helper.GetDecimal(reader["Costo"]);
                licitacion.Estado.Codigo = Helper.GetInteger(reader["CodEstado"]);
                licitacion.Estado.IdEstado = Helper.GetString(reader["IdEstado"]);
                licitacion.Estado.Nombre = Helper.GetString(reader["Estado"]);
                licitacion.Etapa.Codigo = Helper.GetInteger(reader["CodEtapa"]);
                licitacion.Etapa.IdEstado = Helper.GetString(reader["IdEtapa"]);
                licitacion.Etapa.Nombre = Helper.GetString(reader["Etapa"]);

                UnidadEjecutora unidadEjecutora = new UnidadEjecutora();

                unidadEjecutora.Codigo = Helper.GetInteger(reader["CodUnidadEjecutora"]);
                unidadEjecutora.Nombre = Helper.GetString(reader["UnidadEjecutora"]);
                unidadEjecutora.Siglas = Helper.GetString(reader["Siglas"]);

                licitacion.UnidadEjecutora = unidadEjecutora;

            }

            bitacora.Licitacion = licitacion;

            Estado etapa = new Estado();

            etapa.Codigo = Helper.GetInteger(reader["CodEtapa"]);
            etapa.Nombre = Helper.GetString(reader["Etapa"]);
            etapa.IdEstado = Helper.GetString(reader["IdEtapa"]);

            bitacora.Etapa = etapa;

            Estado estado= new Estado();

            estado.Codigo = Helper.GetInteger(reader["CodEstado"]);
            estado.Nombre = Helper.GetString(reader["Estado"]);
            estado.IdEstado = Helper.GetString(reader["IdEstado"]);

            bitacora.Estado = estado;

            bitacora.Fecha = Helper.GetDateTime(reader["Fecha"]);
            bitacora.Observaciones = Helper.GetString(reader["Observaciones"]);

            Usuario usuario = new Usuario();

            usuario.Codigo = Helper.GetInteger(reader["CodUsuario"]);
            usuario.Nombre = Helper.GetString(reader["Nombre"]);
            usuario.Apellido = Helper.GetString(reader["Apellido"]);
            usuario.Login = Helper.GetString(reader["Login"]);

            Institucion inst = new Institucion();

            inst.Codigo = Helper.GetInteger(reader["CodInstitucion"]);
            inst.Nombre = Helper.GetString(reader["Institucion"]);
            inst.Siglas = Helper.GetString(reader["Siglas"]);

            usuario.Institucion = inst;
            bitacora.Usuario = usuario;

            return bitacora;

        }

        #endregion
    }
}

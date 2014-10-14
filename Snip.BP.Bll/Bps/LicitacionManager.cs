using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Transactions;

using Snip.BP.BO;
using Snip.BP.BO.Enums;
using Snip.BP.BO.Bps;
using Snip.BP.Dal;
using Snip.BP.Dal.Bps;
using Snip.BP.Validation;

namespace Snip.BP.Bll.Bps
{
    public static class LicitacionManager
    {
        #region Métodos para la Licitacion

        public static Licitacion GetLicitacion(int codigo, bool getCronograma, bool getReprogramaciones, bool getAjustes, bool getBitacora)
        {
            Licitacion licitacion = new Licitacion();
            licitacion = LicitacionDB.GetItem(codigo);

            if (licitacion != null)
            {
                if (getCronograma)
                {
                    licitacion.Cronograma = LicitacionEtapaCronogramaDB.GetList(licitacion.Codigo);
                }
                if (getReprogramaciones)
                {
                    licitacion.Reprogramaciones = LicitacionReprogramacionDB.GetList(licitacion.Codigo, 1);
                }
                if (getAjustes)
                {
                    licitacion.Reprogramaciones = LicitacionReprogramacionDB.GetList(licitacion.Codigo, 2);
                }
                if (getBitacora)
                {
                    licitacion.Bitacora = LicitacionBitacoraDB.GetList(licitacion.Codigo);
                }
            }
            return licitacion;
        }
        public static Licitacion GetLicitacion(int codigo)
        {
            return GetLicitacion(codigo, false, false, false, false);
        }
        public static Licitacion GetLicitacionWithCronograma(int codigo)
        {
            return GetLicitacion(codigo, true, false, false, false);
        }
        public static Licitacion GetLicitacionWithReprogramaciones(int codigo)
        {
            return GetLicitacion(codigo, false, true, false, false);
        }
        public static Licitacion GetLicitacionWithAjustes(int codigo)
        {
            return GetLicitacion(codigo, false, false, true, false);
        }
        public static Licitacion GetLicitacionWithBitacora(int codigo)
        {
            return GetLicitacion(codigo, false, false, false, true);
        }
        public static LicitacionCollection GetLicitacionesPagedByProyecto(int anio, int codProy, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, ref int totalRecords)
        {
            return GetLicitacionesPaged(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, "CodProy", codProy.ToString(), ref totalRecords, -1, null, null);
        }
        public static LicitacionCollection GetLicitacionesPagedByUnidadEjecutora(int anio, int codUnidadEjecutora, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, ref int totalRecords)
        {
            return GetLicitacionesPaged(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, "CodUnidadEjecutora", codUnidadEjecutora.ToString(), ref totalRecords, -1, null, null);
        }
        public static LicitacionCollection GetLicitacionesPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string sessionId)
        {
            LicitacionCollection licitaciones = new LicitacionCollection();
            licitaciones = LicitacionDB.GetListPaged(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, filterCriteria, filterValue, ref totalRecords, codUsuario, idPerfil, sessionId);
            return licitaciones;
        }
        public static int SaveLicitacion(Licitacion licitacion)
        {
            if (!licitacion.Validate())
            {
                throw new InvalidSaveOperationException("No se puede salvar el registro ya que contiene datos inválidos. Corregir.");
            }
            licitacion.Codigo = LicitacionDB.Save(licitacion);

            return licitacion.Codigo;
        }
        public static bool DeleteLicitacion(int codigo)
        {
            return LicitacionDB.Delete(codigo);
        }

        #endregion

        #region Metodos para el Cronograma

        public static LicitacionEtapaCronograma GetEtapaCronograma(int codLicitacion, int codEtapa)
        {
            return LicitacionEtapaCronogramaDB.GetItem(codLicitacion, codEtapa);
        }
        public static int SaveEtapaCronograma(LicitacionEtapaCronograma cronograma)
        {
            return LicitacionEtapaCronogramaDB.Save(cronograma);
        }
        
        #endregion

        #region Metodos para la Reprogramacion de la Licitacion

        public static bool EnabledToCreateNewReprogramacion(int codLicitacion)
        {
            LicitacionReprogramacionCollection reprogramaciones = new LicitacionReprogramacionCollection();
            reprogramaciones = LicitacionReprogramacionDB.GetList(codLicitacion);

            bool reprogramacionesPendientes = false;

            if (reprogramaciones != null && reprogramaciones.Count > 0)
            {
                foreach (LicitacionReprogramacion rpg in reprogramaciones)
                {
                    if (rpg.EstadoSolicitud.Codigo == (int)EstadoReprogramacion.EnRegistro || rpg.EstadoSolicitud.Codigo == (int)EstadoReprogramacion.PendienteRevision)
                    {
                        reprogramacionesPendientes = true;
                    }
                }
            }
            return !reprogramacionesPendientes;
        }
        public static LicitacionReprogramacion GetReprogramacion(int codLicitacion, int codReprogramacion, bool getObrasReprogramadas)
        {
            LicitacionReprogramacion reprogramacion = new LicitacionReprogramacion();
            reprogramacion = LicitacionReprogramacionDB.GetItem(codLicitacion, codReprogramacion);

            if (reprogramacion != null)
            {
                if (getObrasReprogramadas)
                {
                    reprogramacion.ObrasReprogramadas = LicitacionObraReprogramacionDB.GetList(codLicitacion, codReprogramacion);
                }
            }
            return reprogramacion;
        }
        public static LicitacionReprogramacion GetReprogramacion(int codLicitacion, int codReprogramacion)
        {
            return GetReprogramacion(codLicitacion, codReprogramacion, false);
        }
        public static LicitacionReprogramacion GetReprogramacionWithObras(int codLicitacion, int codReprogramacion)
        {
            return GetReprogramacion(codLicitacion, codReprogramacion, true);
        }
        public static int AddReprogramacion(LicitacionReprogramacion reprogramacion)
        {
            return UpdateReprogramacion(reprogramacion);
        }
        public static int UpdateReprogramacion(LicitacionReprogramacion reprogramacion)
        {
            if (!reprogramacion.Validate())
            {
                throw new InvalidSaveOperationException("No se puede salvar el registro ya que contiene datos inválidos. Corregir.");
            }

            reprogramacion.Codigo = LicitacionReprogramacionDB.Save(reprogramacion, false, false);

            return reprogramacion.Codigo;
        }
        public static int RejectReprogramacion(LicitacionReprogramacion reprogramacion)
        {
            if (!reprogramacion.Validate())
            {
                throw new InvalidSaveOperationException("No se puede salvar el registro ya que contiene datos inválidos. Corregir.");
            }

            reprogramacion.Codigo = LicitacionReprogramacionDB.Save(reprogramacion, false, true);

            return reprogramacion.Codigo;
        }
        public static int ApproveReprogramacion(LicitacionReprogramacion reprogramacion)
        {
            if (!reprogramacion.Validate())
            {
                throw new InvalidSaveOperationException("No se puede salvar el registro ya que contiene datos inválidos. Corregir.");
            }

            return LicitacionReprogramacionDB.Save(reprogramacion, true, false);
        }
        public static bool RemoveReprogramacion(int codLicitacionReprogramacion)
        {
            return LicitacionReprogramacionDB.Delete(codLicitacionReprogramacion);
        }
        #endregion

        #region Metodos para la Bitacora de la licitacion

        public static int ChangeState(LicitacionBitacora bitacora)
        {
            return LicitacionBitacoraDB.Save(bitacora);
        }

        public static LicitacionBitacora GetBitacora(int codigo)
        {
            return LicitacionBitacoraDB.GetItem(codigo);
        }

        #endregion

    }
}

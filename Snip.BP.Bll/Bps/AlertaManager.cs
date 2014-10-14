using System;
using System.Collections.Generic;
using System.Text;

using Snip.BP.BO;
using Snip.BP.BO.Bps;
using Snip.BP.Dal;
using Snip.BP.Dal.Bps;
using Snip.BP.Validation;

namespace Snip.BP.Bll.Bps
{
    public static class AlertaManager
    {
        public static AlertaEstadoCollection AlertaEstadoGetList(int anio, int codUsuario)
        {
            return AlertaEstadoDB.GetList(anio, codUsuario);
        }
        public static AlertaEstadoCollection AlertaEstadoGetListByLicitacion(int codLicitacion)
        {
            return AlertaEstadoDB.GetListByLicitacion(codLicitacion);
        }
        public static AlertaEstadoCollection AlertaEstadoGetListPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
           string searchValue, string filterCriteria, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string sessionId)
        {
            return AlertaEstadoDB.GetListPaged(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, filterCriteria, filterValue, ref totalRecords, codUsuario, idPerfil, sessionId);
        }
        public static AlertaEtapaCollection AlertaEtapaGetList(int anio, int codUsuario)
        {
            return AlertaEtapaDB.GetList(anio, codUsuario);
        }
        public static AlertaEtapaCollection AlertaEtapaGetListPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
           string searchValue, string filterCriteria, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string sessionId)
        {
            return AlertaEtapaDB.GetListPaged(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, filterCriteria, filterValue, ref totalRecords, codUsuario, idPerfil, sessionId);
        }
        
        public static int AlertaEstadoGetTotalEvents(int anio, int codUsuario)
        {
            AlertaEstadoCollection eventos = new AlertaEstadoCollection();
            eventos = AlertaEstadoDB.GetList(anio, codUsuario);

            if (eventos != null)
            {
                return eventos.Count;
            }
            else
            {
                return 0;
            }

        }
        public static int AlertaEtapaGetTotalEvents(int anio, int codUsuario)
        {
            AlertaEtapaCollection eventos = new AlertaEtapaCollection();
            eventos = AlertaEtapaDB.GetList(anio, codUsuario);

            if (eventos != null)
            {
                return eventos.Count;
            }
            else
            {
                return 0;
            }
        }
        public static AlertaReprogramacionCollection AlertaReprogramacionGetListPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
           string searchValue, string filterCriteria, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string sessionId)
        {
            return AlertaReprogramacionDB.GetListPaged(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, filterCriteria, filterValue, ref totalRecords, codUsuario, idPerfil, sessionId);
        }
        public static AlertaReprogramacionCollection AlertaReprogramacionGetList(int anio, int codUsuario, int codEstadoSolicitud)
        {
            string filtro = string.Empty;
            
            if (codEstadoSolicitud != -1)
                filtro = "CodEstadoSolicitud";

            int totalRecords = 0;
            return AlertaReprogramacionDB.GetListPaged(anio, 0, 0, string.Empty, true, string.Empty, filtro, codEstadoSolicitud.ToString(), ref totalRecords, codUsuario, string.Empty, string.Empty);
        }
        public static int AlertaReprogramacionGetTotalEvents(int anio, int codUsuario, int codEstadoSolicitud)
        {
            AlertaReprogramacionCollection eventos = new AlertaReprogramacionCollection();
            eventos = AlertaReprogramacionGetList(anio, codUsuario, codEstadoSolicitud);

            if (eventos != null)
            {
                return eventos.Count;
            }
            else
            {
                return 0;
            }
        }
        public static int AlertaReprogramacionGetTotalEvents(int anio, int codUsuario)
        {
            AlertaReprogramacionCollection eventos = new AlertaReprogramacionCollection();
            eventos = AlertaReprogramacionGetList(anio, codUsuario, -1);

            if (eventos != null)
            {
                return eventos.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}

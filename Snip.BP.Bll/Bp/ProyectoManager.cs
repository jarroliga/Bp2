using System;
using System.Collections.Generic;
using System.ComponentModel;

using Snip.BP.BO;
using Snip.BP.BO.Bp;
using Snip.BP.Dal;
using Snip.BP.Dal.Bp;
using Snip.BP.Validation;

namespace Snip.BP.Bll.Bp
{
    public static class ProyectoManager
    {
        public static ProyectoCollection GetListPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, string filterCriteria, string filterValue, ref int totalRecords)
        {
            return GetListPaged(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, filterCriteria, filterValue, -1, string.Empty, string.Empty, ref totalRecords);

        }
        public static ProyectoCollection GetListPaged(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
           string searchValue, string filterCriteria, string filterValue, int codUsuario, string idPerfil, string sessionId, ref int totalRecords)
        {
            ProyectoCollection proyectos = new ProyectoCollection();
            proyectos = ProyectoDB.GetList(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, filterCriteria, filterValue, codUsuario, idPerfil, sessionId, ref totalRecords);
            return proyectos;
        }
        public static ProyectoCollection GetListPagedByAnio(int anio, int pageIndex, int pageSize, string orderField, bool orderDirection,
            string searchValue, int codUsuario, string idPerfil, string sessionId, ref int totalRecords)
        {
            return ProyectoDB.GetList(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, "Anio", anio.ToString(), codUsuario, idPerfil, sessionId, ref totalRecords);
        }
        public static ProyectoCollection GetListAllByAnio(int anio, string orderField, bool orderDirection, string searchValue, int codUsuario, string idPerfil, string sessionId, ref int totalRecords) 
        {
            return GetListPagedByAnio(anio, 1, 0, orderField, orderDirection, searchValue, codUsuario, idPerfil, sessionId, ref totalRecords);
        }
        public static ProyectoCollection GetListByPipUnidadEjecutora(int anio, int codUnidadEjecutora, ref int totalRecords, int codUsuario, string idPerfil, string sessionId)
        {
            return ProyectoDB.GetList(anio, 1, 0, "CodSnip", true, string.Empty, "CodUnidadEjecutora", codUnidadEjecutora.ToString(), codUsuario, idPerfil, sessionId, ref totalRecords);
        }
        public static ProyectoCollection GetListPagedByPipInstitucion(int anio, int codInstitucion, int pageIndex, int pageSize, string orderField, bool orderDirection, string searchValue, ref int totalRecords, int codUsuario, string idPerfil, string sessionId)
        {
            return ProyectoDB.GetList(anio, pageIndex, pageSize, orderField, orderDirection, searchValue, "CodInstitucion", codInstitucion.ToString(), codUsuario, idPerfil, sessionId, ref totalRecords);
        }
        public static Proyecto GetItem(int codigo)
        {
            return ProyectoDB.GetItem(codigo);
        }
        public static Proyecto GetItem(int codigo, bool getFicha)
        {
            Proyecto proyecto = new Proyecto();

            proyecto = ProyectoDB.GetItem(codigo);

            if (proyecto != null && getFicha)
            {
                ProyectoFicha ficha = new ProyectoFicha();

                ficha = ProyectoFichaDB.GetItem(codigo);

                proyecto.ProyectoFicha = ficha;

            }

            return proyecto;

        }
    }
}

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
    public static class ObraManager
    {
        public static Obra GetItem(int codObra)
        {
            return GetItemFull(codObra, false, -1);
        }
        public static Obra GetItemFull(int codObra, bool getFinanciamiento, int anio)
        {
            Obra obra = new Obra();

            obra = ObraDB.GetItem(codObra);

            if (obra != null && getFinanciamiento)
            {
                obra.Financiamientos = FinanciamientoDB.GetList(codObra, anio);
            }

            return obra;
        }

        public static ObraCollection GetListPaged(int codProyecto, int anio, int pageIndex, int pageSize, string sortField, string sortDirection,
            string searchValue, string filterField, string filterValue, ref int totalRecords, int codUsuario, string idPerfil, string sessionId)
        {
            ObraCollection obras = new ObraCollection();
            obras = ObraDB.GetList(codProyecto, anio, pageIndex, pageSize, sortField, sortDirection, searchValue, filterField, filterValue, ref totalRecords, codUsuario, idPerfil, sessionId);
            return obras;
        }
        public static ObraCollection GetList(int codProyecto, int anio, string sortField, string sortDirection, ref int totalRecords, int codUsuario, string idPerfil, string sessionId)
        {
            return GetListPaged(codProyecto, anio, 1,0, sortField, sortDirection, string.Empty, string.Empty, string.Empty, ref totalRecords, codUsuario, idPerfil, sessionId);
        }
        public static ObraCollection GetListNotInLicitacion(int codProyecto, int anio, int codLicitacion, int codUsuario, string idPerfil, string sessionId)
        {
            int totalRecords = 0;
            return GetListPaged(codProyecto, anio, 1,0, "CodSnip", Constantes.ASCENDING, string.Empty, "NotInLicitacion", codLicitacion.ToString(), ref totalRecords, codUsuario, idPerfil, sessionId);
        }
        public static ObraCollection GetListAll(int codProyecto)
        {
            int totalRecords = 0;
            return GetList(codProyecto, 0, "CodSnip", Constantes.ASCENDING, ref totalRecords, -1, string.Empty, string.Empty);
        }
        /* Métodos utilitarios para la clase obra */

        public static decimal GetAsignacionPip(int codObra, int anio)
        {
            Obra obra = new Obra();

            obra = GetItemFull(codObra, true, anio);

            decimal montoAsignadoTotal = 0M;

            if (obra.Financiamientos != null)
            {
                foreach (Financiamiento financiamiento in obra.Financiamientos)
                {
                    montoAsignadoTotal += financiamiento.MontoAsignado;
                }
            }
            return montoAsignadoTotal;

        }
        public static AsignacionPIP GetAsignacionPipFuente(int codObra, int anio)
        {
            return AsignacionPIPDB.GetItem(codObra, anio);
        }

    }
}

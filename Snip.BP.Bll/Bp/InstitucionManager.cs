using System;
using System.Collections.Generic;
using System.ComponentModel;

using Snip.BP.BO;
using Snip.BP.BO.Enums;
using Snip.BP.BO.Bp;
using Snip.BP.BO.Dm;
using Snip.BP.Dal;
using Snip.BP.Dal.Bp;
using Snip.BP.Dal.Dm;
using Snip.BP.Validation;

namespace Snip.BP.Bll.Bp
{
    [DataObjectAttribute()]
    public static class InstitucionManager
    {
        #region Métodos Públicos

        public static Institucion GetItem(int codigo)
        {
            return InstitucionDB.GetItem(codigo);
        }
        public static PipInstitucion GetPresupuestoInstitucion(int codigo, int anio, FormatoNumero formato)
        {
            return PipInstitucionDB.GetItem(codigo, anio, (int)formato);
        }
        public static PipInstitucion GetPresupuestoInstitucion(int codigo, int anio)
        {
            return GetPresupuestoInstitucion(codigo, anio, FormatoNumero.Unidades);
        }
        public static InstitucionCollection GetList(int codSectorInstitucional)
        {
            return InstitucionDB.GetList(codSectorInstitucional);
        }
        public static InstitucionCollection GetListPaged(int codSectorInstitucional, int pageIndex, int pageSize, string orderField, bool orderDirection, string searchField, string searchValue,
            string filterCriteria, string filterValue, ref int totalRecords)
        {
            return InstitucionDB.GetListPaged(codSectorInstitucional, pageIndex, pageSize, orderField, orderDirection, searchValue, filterCriteria, filterValue, ref totalRecords);
        }
        public static InstitucionCollection GetListAll()
        {
            int codSectorInstitucional = -1; // Todos los sectores
            int pageIndex = 1;
            int pageSize = 0; // Todas las paginas
            int totalRecords = 0;
            return InstitucionDB.GetListPaged(codSectorInstitucional, pageIndex, pageSize, "CodInstitucion", true, string.Empty, string.Empty, string.Empty, ref totalRecords);
        }

        #endregion
    }
}

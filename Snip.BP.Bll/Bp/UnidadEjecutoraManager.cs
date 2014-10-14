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
    public static class UnidadEjecutoraManager
    {
        public static UnidadEjecutoraCollection GetListPaged(int codInstitucion, int pageIndex, int pageSize, string orderField, bool orderDirection, 
                string searchValue, string filterCriteria, string filterValue, ref int totalRecords)
        {
            return UnidadEjecutoraDB.GetListPaged(codInstitucion, pageIndex, pageSize, orderField, orderDirection, searchValue, filterCriteria, filterValue, ref totalRecords);
        }
        public static UnidadEjecutoraCollection GetList(int codInstitucion)
        {
            return UnidadEjecutoraDB.GetList(codInstitucion);
        }
        public static UnidadEjecutoraCollection GetListAll()
        {
            return UnidadEjecutoraDB.GetList(-1);
        }
    }
}

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
    public static class ClasificadorInstitucionalManager
    {
        public static ClasificadorInstitucionalCollection GetList()
        {
            return ClasificadorInstitucionalDB.GetList();
        }
        public static ClasificadorInstitucional GetItem(int codClasificadorInstitucional)
        {
            return ClasificadorInstitucionalDB.GetItem(codClasificadorInstitucional);
        }
    }
}

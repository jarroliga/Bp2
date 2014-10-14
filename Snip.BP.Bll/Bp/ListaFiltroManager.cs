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
    public static class ListaFiltroManager
    {
        #region Métodos Públicos

        public static ListaFiltroCollection GetList()
        {
            return ListaFiltroDB.GetList();
        }

        #endregion
    }
}


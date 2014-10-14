using System;
using System.Collections.Generic;
using System.ComponentModel;

using Snip.BP.BO.App;
using Snip.BP.Dal.App;
using Snip.BP.Validation;

namespace Snip.BP.Bll.App
{
    public static class EstadoManager
    {
        public static TransicionEstadoCollection GetList(int codEstadoOrigen)
        {
            return TransicionEstadoDB.GetList(codEstadoOrigen);
        }
        public static Estado GetItem(int codEstado)
        {
            return EstadoDB.GetItem(codEstado);
        }
        public static EstadoCollection GetEstadoList(int codTarea)
        {
            return EstadoDB.GetList(codTarea);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO.App;
using Snip.BP.Dal.App;
using Snip.BP.Validation;

namespace Snip.BP.Bll.App
{
    public class TareaManager
    {
        public static Tarea GetItem(int codigo)
        {
            Tarea tarea = new Tarea();

            tarea = TareaDB.GetItem(codigo);

            return tarea;
        }
    }
}

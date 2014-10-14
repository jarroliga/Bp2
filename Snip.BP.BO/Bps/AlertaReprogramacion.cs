using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bps
{
    public class AlertaReprogramacion : LicitacionReprogramacion
    {
        public int CodLicitacionReprogramacion
        {
            get { return Codigo; }
        }

    }
}

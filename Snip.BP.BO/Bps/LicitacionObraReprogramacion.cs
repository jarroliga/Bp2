using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bps
{
    public class LicitacionObraReprogramacion : LicitacionObra
    {
        public int CodLicitacionReprogramacion { get; set; }
        public decimal Reprogramado { get; set; }
    }
}

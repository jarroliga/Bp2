using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.App;


namespace Snip.BP.BO.Bps
{
    public class TipoProcedimiento : BusinessBase
    {
        public override int Codigo { get; set; }
        public string Nombre { get; set; }
            
    }
}

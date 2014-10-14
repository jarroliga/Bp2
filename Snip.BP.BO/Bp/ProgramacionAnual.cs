using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Bp
{
    public class ProgramacionAnual
    {
        public ProgramacionAnual()
        {
            Mes01 = 0.0M;
            Mes02 = 0.0M;
            Mes03 = 0.0M;
            Mes04 = 0.0M;
            Mes05 = 0.0M;
            Mes06 = 0.0M;
            Mes07 = 0.0M;
            Mes08 = 0.0M;
            Mes09 = 0.0M;
            Mes10 = 0.0M;
            Mes11 = 0.0M;
            Mes12 = 0.0M;
        }
        public int Anio { get; set; }
        public decimal Mes01 { get; set; }
        public decimal Mes02 { get; set; }
        public decimal Mes03 { get; set; }
        public decimal Mes04 { get; set; }
        public decimal Mes05 { get; set; }
        public decimal Mes06 { get; set; }
        public decimal Mes07 { get; set; }
        public decimal Mes08 { get; set; }
        public decimal Mes09 { get; set; }
        public decimal Mes10 { get; set; }
        public decimal Mes11 { get; set; }
        public decimal Mes12 { get; set; }
        
        public decimal TotalAnual 
        { 
            get 
            {
                return Mes01 + Mes02 + Mes03 + Mes04 + Mes05 + Mes06 + Mes07 + Mes08 + Mes09 + Mes10 + Mes11 + Mes12;
            } 
        }

    }
}

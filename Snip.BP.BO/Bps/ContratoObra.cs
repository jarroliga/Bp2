using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;


namespace Snip.BP.BO.Bps
{
    public class ContratoObra : ValidationBase
    {
        public ContratoObra()
        {
            Contrato = new Contrato();
        }

        public Contrato Contrato { get; set; }

        public int CodContrato
        {
            get { return Contrato.Codigo; }
            set { Contrato.Codigo = value; }
        }

        public Obra Obra { get; set; }

        public int CodObra
        {
            get { return Obra.Codigo; }
            set { Obra.Codigo = value; }
        }
        [ValidRange(Message = "El costo inicial no puede ser cero o negativo.", Max = 9999999999.99, Min = 1)]
        public Decimal CostoInicial { get; set; }
        
        public Decimal CostoVariaciones { get; set; }

        [ValidRange(Message = "El costo actualizado no puede ser cero o negativo.", Max = 9999999999.99, Min = 1)]
        public Decimal CostoActualizado { get; set; }

        public Decimal CantidadIndicador { get; set; }

    }
}

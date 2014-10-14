using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Bp;


namespace Snip.BP.BO.Bpi
{
    public class ProyectoGastoRecurrente : ValidationBase 
    {
        public ProyectoGastoRecurrente()
        {
            Proy = new Snip.BP.BO.Bpi.Proyecto();
            TipoGastoRecurrente = new TipoGastoRecurrente();
        }

        public Snip.BP.BO.Bpi.Proyecto Proy { get; set; }

        public int CodProyecto
        {
            get { return Proy.Codigo; }
            set { Proy.Codigo = value; }
        }

       public TipoGastoRecurrente TipoGastoRecurrente { get; set; }

        public int CodGastoRecurrente
        {
            get { return TipoGastoRecurrente.Codigo; }
            set { TipoGastoRecurrente.Codigo = value; }
        }

        [ValidRange(Message = "El año no coincide con el rango permitido.", Max = 2024, Min = 2011)]
        public int Anio { get; set; }

        [ValidRange(Message = "El monto del costo no puede ser cero o negativo.", Max = 9999999999.99, Min = 1)]
        public Decimal Gasto { get; set; }

    }
}

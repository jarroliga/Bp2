using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
//using Snip.BP.BO.App;
using Snip.BP.BO.Bp;


namespace Snip.BP.BO.Bpi
{
    public class ActividadCosto : ValidationBase 
    {
        public ActividadCosto()
        {
            Actividad = new Actividad();
            CatCosto = new CategoriaCosto();
        }

        public Actividad Actividad { get; set; }

        public int CodActividad
        {
            get { return Actividad.Codigo; }
            set { Actividad.Codigo = value; }
        }

        public CategoriaCosto CatCosto { get; set; }

        public int CodCategoriaCosto
        {
            get { return CatCosto.Codigo; }
            set { CatCosto.Codigo = value; }
        }

        [ValidRange(Message = "El año no coincide con el rango permitido.", Max = 2024, Min = 2011)]
        public int Anio { get; set; }

        [ValidRange(Message = "El monto del costo no puede ser cero o negativo.", Max = 9999999999.99, Min = 1)]
        public Decimal Costo { get; set; }

    }
}

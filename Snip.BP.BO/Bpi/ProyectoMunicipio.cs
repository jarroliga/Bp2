using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
//using Snip.BP.BO.App;
using Snip.BP.BO.Bp;


namespace Snip.BP.BO.Bpi
{
    public class ProyectoMunicipio : ValidationBase 
    {
        public ProyectoMunicipio()
        {
            Proy = new Snip.BP.BO.Bpi.Proyecto();
            Municipio = new Municipio();
        }

        public Snip.BP.BO.Bpi.Proyecto Proy { get; set; }

        public int CodProyecto 
        {
            get { return Proy.Codigo; }
            set { Proy.Codigo = value; }
        }

        public Municipio Municipio { get; set; }

        public int CodMunicipio
        {
            get { return Municipio.Codigo; }
            set { Municipio.Codigo = value; }
        }

        [ValidRange(Message = "El porcentaje no puede ser cero o mayor de cien.", Max = 100.00, Min = 0.1)]
        public decimal Porcentaje { get; set; }

    }
}

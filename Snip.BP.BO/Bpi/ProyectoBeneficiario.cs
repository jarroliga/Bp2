using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
//using Snip.BP.BO.App;
using Snip.BP.BO.Bp;


namespace Snip.BP.BO.Bpi 
{
    public class ProyectoBeneficiario : ValidationBase 
    {
        public ProyectoBeneficiario()
        {
            Proy = new Snip.BP.BO.Bpi.Proyecto();
            Beneficiario = new Beneficiario();
        }

        public Snip.BP.BO.Bpi.Proyecto Proy { get; set; }

        public int CodProyecto 
        {
            get { return Proy.Codigo; }
            set { Proy.Codigo = value; }
        }

        public Beneficiario Beneficiario { get; set; }

        public int CodBeneficiario
        {
            get { return Beneficiario.Codigo; }
            set { Beneficiario.Codigo = value; }
        }

        [ValidRange(Message = "La cantidad de beneficiarios no puede ser cero o negativa.", Max = 9999999999, Min = 1)]
        public int Cantidad { get; set; }

    }
}

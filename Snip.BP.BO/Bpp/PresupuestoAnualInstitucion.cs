using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpp
{
    public class PresupuestoAnualInstitucion
    {
        #region Constructores

        public PresupuestoAnualInstitucion()
        {
            Aprobado = new OrigenFondo();
            Modificaciones = new OrigenFondo();
            Presupuesto = new OrigenFondo();
            Traslado = new OrigenFondo();
        }
        #endregion

        #region Propiedades

        public int Anio { get; set; }
        public Institucion Institucion { get; set; }

        public int CodInstitucion
        {
            get { return Institucion.Codigo; }
            set { Institucion.Codigo = value; }
        }

        public OrigenFondo Aprobado {get; set;}
        public OrigenFondo Modificaciones { get; set; }
        public OrigenFondo Presupuesto { get; set; }
        public OrigenFondo Traslado { get; set; }

        public int Consecutivo { get; set; }

        #endregion

    }
}

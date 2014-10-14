using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Bp
{
    public class FuenteSIGFA : BusinessBase
    {
        #region Constructores

        public FuenteSIGFA()
        {
        }
        #endregion

        #region Propiedades

        public override int Codigo {get; set;}

        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public string Etiqueta
        {
            get { return Codigo.ToString() + " - " + Nombre; }
        }

        #endregion

    }
}

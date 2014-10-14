using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class Sector : BusinessBase
    {
        #region Constructores

        public Sector()
        {
            SectorPadre = null;
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Nivel { get; set; }

        public bool Activo { get; set; }

        public Sector SectorPadre { get; set; }

        #endregion
               

    }
}

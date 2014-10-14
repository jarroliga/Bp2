using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class AlineamientoPNDH : BusinessBase
    {
        #region Constructores

        public AlineamientoPNDH()
        {
            AlineamientoPNDHPadre = null;
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }

        public int CodAlineamientoPNDH
        {
            get { return Codigo; }
        }

        public AlineamientoPNDH AlineamientoPNDHPadre { get; set; }

        public int Nivel { get; set; }

        public string Nombre { get; set; }

        public int Version { get; set; }

        #endregion

    }
}

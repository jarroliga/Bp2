using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.Bp;
using Snip.BP.BO.App;

namespace Snip.BP.BO.Bpp
{
    public class TrasladoPartida : BusinessBase
    {
        #region Constructores

        public TrasladoPartida()
        {
            Partida = new PresupuestoAnual();
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }

        public int CodTraslado { get; set; }
        public PresupuestoAnual Partida { get; set; }

        public int IdTipoOperacion { get; set; }
        public string Justificacion { get; set; }
        public decimal Solicitado { get; set; }
        public decimal Aprobado { get; set; }
       
        public int CodPartida 
        {
            get { return Partida.Codigo; }
            set { Partida.Codigo = value; }
        }
        
        #endregion
    }
}

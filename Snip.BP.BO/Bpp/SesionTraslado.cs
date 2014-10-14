using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Bpp
{
    /// <summary>
    /// La clase SesionTraslado es una clase de asociación entre la clase Sesion y la clase Traslado para indicar cuantos traslados
    /// estan asociados a una Sesion del CTI.
    /// </summary>
    public class SesionTraslado
    {
        #region Constructores

        public SesionTraslado()
        {
            Traslado = new Traslado();
        }

        #endregion

        #region Propiedades

        public int CodSesion { get; set; }
        public Traslado Traslado { get; set; }

        #endregion
    }
}

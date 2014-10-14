using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.App
{
    public class Tarea : BusinessBase
    {
        #region Constructores

        public Tarea()
        {
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }

        public string Nombre { get; set; }

        public string Identificador { get; set; }

        #endregion
    }
}

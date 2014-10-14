using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.App
{
    public class Estado : BusinessBase
    {
        #region Constructores

        public Estado()
        {
            Tarea = new Tarea();
            EstadosDestino = new EstadoCollection();
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }

        public Tarea Tarea { get; set; }

        public string Nombre { get; set; }

        public string IdEstado { get; set; }

        public int Secuencia { get; set; }

        public bool Activo { get; set; }

        public int CodTarea
        {
            get { return Tarea.Codigo; }
            set { Tarea.Codigo = value; }
        }
        public EstadoCollection EstadosDestino { get; set; }

        #endregion

    }
}

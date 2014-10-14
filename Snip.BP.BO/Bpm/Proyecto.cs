using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpm
{
    public class Proyecto : BusinessBase 
    {
        public Proyecto()
        {
            Estado = new Estado();
            Etapa = new Estado();
            UnidadEjecutora = new UnidadEjecutora();
            Sector = new Sector();
        }

        #region Propiedades Públicas

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        public string IdProyecto { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Costo { get; set; }

        public bool CoEjecucion { get; set; }

        public string CoEjecutor { get; set; }

        public Estado Estado { get; set; }

        public Estado Etapa { get; set; }

        public UnidadEjecutora UnidadEjecutora { get; set; }

        public Sector Sector { get; set; }

        #endregion
    }
}

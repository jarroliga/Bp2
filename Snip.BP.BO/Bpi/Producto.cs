using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpi 
{
    public class Producto : BusinessBase 
    {
        public Producto()
        {
            Proyecto = new Snip.BP.BO.Bpi.Proyecto();
            Intervencion = new Intervencion();
        }

        public override int Codigo { get; set; }

        public int CodProducto
        {
            get { return Codigo; }
        }

        public Snip.BP.BO.Bpi.Proyecto Proyecto { get; set; }

        public int CodProyecto
        {
            get { return Proyecto.Codigo; }
            set { Proyecto.Codigo = value; }
        }

        public Intervencion Intervencion { get; set; }

        public int CodIntervencion
        {
            get { return Intervencion.Codigo; }
            set { Intervencion.Codigo = value; }
        }

        public string Nombre { get; set; }

        public decimal Cantidad { get; set; }

        public decimal CoordenadaX { get; set; }

        public decimal CoordenadaY { get; set; }

        public string RutaGeoData { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.App
{
    public class TransicionEstado : BusinessBase
    {
        public TransicionEstado()
        {
            EstadoOrigen = new Estado();
            EstadoDestino = new Estado();
        }

        public override int Codigo { get; set; }

        public Estado EstadoOrigen { get; set; }

        public Estado EstadoDestino { get; set; }

        public int CodEstadoOrigen
        {
            get { return EstadoOrigen.Codigo; }
            set { EstadoOrigen.Codigo = value; }
        }
        public int CodEstadoDestino
        {
            get { return EstadoDestino.Codigo; }
            set { EstadoDestino.Codigo = value; }
        }

        public string IdTransicion { get; set; }

        public string Descripcion { get; set; }

        public bool TransicionPrimaria { get; set; }

        public bool Activo { get; set; }

    }
}

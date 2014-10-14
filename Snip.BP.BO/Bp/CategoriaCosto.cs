using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    public class CategoriaCosto : BusinessBase
    {
        public CategoriaCosto()
        {
        }

        public override int Codigo { get; set; }

        public string Nombre { get; set; }

        public string Etiqueta { get; set; }

        public string IdActividadObra { get; set; }

        public bool Activo { get; set; }

        public bool EsCategoriaProyecto { get; set; }

    }
}

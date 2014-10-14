using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpi
{
    public class Componente : BusinessBase
    {
        public Componente()
        {
            Programa = new Programa();
            Proyectos = new ProyectoCollection();
        }

        public override int Codigo { get; set; }

        public int CodComponente
        {
            get { return Codigo; }
        }

        public Programa Programa { get; set; }

        public int CodPrograma 
        {
            get { return Programa.Codigo; }
        }

        public string IdComponente { get; set; }

        public int IdOrden { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public ProyectoCollection Proyectos { get; set; }

    }
}

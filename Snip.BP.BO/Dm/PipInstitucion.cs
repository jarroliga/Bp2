using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Enums;

namespace Snip.BP.BO.Dm
{
    public class PipInstitucion
    {
        public PipInstitucion()
        {
            Asignado = new OrigenFondo();
            Modificado = new OrigenFondo();
            Actualizado = new OrigenFondo();
            Ejecutado = new OrigenFondo();
        }

        public int Anio { get; set; }
        public int IdTipoEntidad { get; set; }
        public string TipoEntidad { get; set; }

        public int CodInstitucion { get { return Institucion.Codigo; } }

        public Institucion Institucion { get; set; }

        public int Proyectos { get; set; }
        public int Obras { get; set; }

        public OrigenFondo Asignado { get; set; }
        public OrigenFondo Modificado { get; set; }
        public OrigenFondo Actualizado { get; set; }
        public OrigenFondo Ejecutado { get; set; }

        public int Licitaciones { get; set; }
        public OrigenFondo Licitado { get; set; }

        public int Contratos { get; set; }
        public OrigenFondo Contratado { get; set; }
        public OrigenFondo EjecutadoContrato { get; set; }

    }
}

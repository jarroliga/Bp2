using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Snip.BP.BO.Bp;
using Snip.BP.BO.Enums;

namespace Snip.BP.BO.Dm
{
    public class PipInstitucionEntidad
    {
        public PipInstitucionEntidad()
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

        public OrigenFondo Asignado { get; set; }
        public OrigenFondo Modificado { get; set; }
        public OrigenFondo Actualizado { get; set; }
        public OrigenFondo Ejecutado { get; set; }


    }
}

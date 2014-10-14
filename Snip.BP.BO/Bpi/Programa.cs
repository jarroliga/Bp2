using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpi
{
    public class Programa : BusinessBase
    {
        public Programa()
        {
            Solicitud = new Solicitud();
            TipoPrograma = new TipoPrograma();
            Componentes = new ComponenteCollection();
            Proyectos = new ProyectoCollection();
        }

        public override int Codigo { get; set; }

        public int CodPrograma
        {
            get { return Codigo; }
        }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string IdPrograma { get; set; }

        public int CodTipoPrograma { get; set; }

        public TipoPrograma TipoPrograma { get; set; }

        public int CodSolicitud { get; set; }

        public Solicitud Solicitud { get; set; }

        [ValidRange(Message = "Debe digitar el año.", Max = 2024, Min = 2011)]
        public int Anio { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "FechaInicioNotEmpty")]
        public DateTime FechaInicio { get; set; }        
        
        public DateTime FechaFinalizacion { get; set; }

        public string Objetivo { get; set; }

        public string Descripcion { get; set; }

        public ComponenteCollection Componentes { get; set; }

        public ProyectoCollection Proyectos { get; set; }

    }
}

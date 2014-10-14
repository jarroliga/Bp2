using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.App
{
    [Serializable]
    public class Session
    {
        public Session()
        {
            Codigo = -1;
            SessionId = null;
            Aplicacion = new Aplicacion();
            Usuario = new Usuario();
            FechaEmision = DateTime.Now;
            Validez = 120;
            FechaExpiracion = FechaEmision.AddMinutes(Validez);
            Filtros = new FiltroCollection();
        }
        public int Codigo { get; set; }
        public string SessionId { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaExpiracion {get; set;}
        public double Validez {get; set;}
        public Aplicacion Aplicacion { get; set; }
        public Usuario Usuario { get; set; }
        public FiltroCollection Filtros { get; set; }

    }
}

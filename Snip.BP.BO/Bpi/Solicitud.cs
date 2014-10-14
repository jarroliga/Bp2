using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpi
{
    public class Solicitud : BusinessBase
    {
        #region Constructores

        public Solicitud()
        {
            UnidadEjecutora = new UnidadEjecutora();
            TipoSolicitud = new TipoSolicitud();
            TipoDictamen = new TipoDictamen();
            Estado = new Estado();
            TecnicoUSIP =  new Usuario();
            AnalistaDGIP = new Usuario();
        }
        #endregion

        #region Propiedades
        public override int Codigo { get; set; }

        public UnidadEjecutora UnidadEjecutora { get; set; }

        [ValidRange(Message = "Debe digitar el año.", Max = 2024, Min = 2011)]
        public int Anio { get; set; }

        public int Consecutivo { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string IdSolicitud { get; set; }

        public string Nombre { get; set; }

        public TipoSolicitud TipoSolicitud { get; set; }

        public int CodPrograma { get; set; }

        public bool CartaRecibida { get; set; }

        public string IdCarta { get; set; }

        public bool Financiamiento { get; set; }

        public bool Revisada { get; set; }

        public bool Asignada { get; set; }

        public bool Devuelta { get; set; }

        public TipoDictamen TipoDictamen { get; set; }

        public Usuario TecnicoUSIP { get; set; }

        public Usuario AnalistaDGIP { get; set; }

        public Estado Estado { get; set; }

        #endregion

    }
}

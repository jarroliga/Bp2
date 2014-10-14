using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpp
{
    public class PresupuestoAnual : BusinessBase
    {
        #region Constructores

        public PresupuestoAnual()
        {
            Fuente = new Fuente();
            Organismo = new Organismo();
            Institucion = new Institucion();
            Obra = new Obra();
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }

        public int Ejercicio { get; set; }
        public int Entidad { get; set; }
        public int Programa { get; set; }
        public int SubPrograma { get; set; }
        public int Proyecto { get; set; }
        public int Actividad { get; set; }
        public int ObraSIGFA { get; set; }

        public Fuente Fuente { get; set; }
        public Organismo Organismo { get; set; }

        public int FuenteEspecifica { get; set; }
        public int Renglon { get; set; }
        public int Geografico { get; set; }
        public int Funcion { get; set; }
        
        public decimal Asignado { get; set; }
        public decimal Modificaciones { get; set; }
        public decimal PrgAnualAnterior { get; set; }
        public decimal PrgAnualModificadoPendiente { get; set; }
        public decimal Ejecutado01 { get; set; }
        public decimal Ejecutado02 { get; set; }
        public decimal Ejecutado03 { get; set; }
        public decimal Ejecutado04 { get; set; }
        public decimal Ejecutado05 { get; set; }
        public decimal Ejecutado06 { get; set; }
        public decimal Ejecutado07 { get; set; }
        public decimal Ejecutado08 { get; set; }
        public decimal Ejecutado09 { get; set; }
        public decimal Ejecutado10 { get; set; }
        public decimal Ejecutado11 { get; set; }
        public decimal Ejecutado12 { get; set; }

        public Institucion Institucion { get; set; }
        public Obra Obra { get; set; }

        public int Anio { get; set; }
        public int CodFuente { get; set; }
        public int CodModalidad { get; set; }
        public string Fase { get; set; }
        public int CodConvenio { get; set; }
        public int CodRenglon { get; set; }
        public int CodUbicacion { get; set; }
        public int Origen { get; set; }
        public int Estado { get; set; }

        #endregion
    }
}

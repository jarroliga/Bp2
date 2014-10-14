using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bps
{
    public class LicitacionObra : ValidationBase 
    {
        public LicitacionObra()
        {
            Licitacion = new Licitacion();
            Obra = new Obra();
            Programacion = new ProgramacionAnual();
            ProgramadoPorFuente = new OrigenFondo();
        }

        public Licitacion Licitacion { get; set; }

        public int CodLicitacion
        {
            get { return Licitacion.Codigo; }
            set { Licitacion.Codigo = value; }
        }

        public Obra Obra { get; set; }

        public int CodObra
        {
            get { return Obra.Codigo; }
            set { Obra.Codigo = value; }
        }
        [ValidRange(Message = "El monto total programado no puede ser cero o negativo.", Max = 9999999999.99, Min = 1)]
        public decimal Programado { get; set; }

        public decimal PorcentajeAsignacion { get; set; }

        [ValidRange(Message = "Debe registrar el plazo de ejecución en días.", Max = 9999999999.99, Min = 1)]
        public int PlazoEjecucionDias { get; set; }

        public OrigenFondo ProgramadoPorFuente { get; set; }

        public ProgramacionAnual Programacion { get; set; }

        //public LicitacionObraProgramacion Programacion { get; set; }

        //public LicitacionObraReprogramacion Reprogramacion { get; set; }

        public bool Desierta { get; set; }

        public int CodUsuarioRegistro { get; set; }

        public bool Editable { get; set; }

        public override bool Validate()
        {
            bool isOk = true;

            if (Programado != Programacion.TotalAnual)
            {
                this.BrokenRules.Add("Los costos programados por mes no coinciden con el monto total programado.");
                isOk = false;
            }
            
            if (Programado != ProgramadoPorFuente.Total)
            {
                this.BrokenRules.Add("Los costos programados por fuente no coinciden con el monto total programado.");
                isOk = false;
            }
            return isOk;
        }
    }
}

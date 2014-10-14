using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;
using Snip.BP.BO.App;
using Snip.BP.BO.Bp;

namespace Snip.BP.BO.Bpi
{
    public class Proyecto : BusinessBase
    {
        public Proyecto()
        {
            Componente = new Componente();
            Sector = new Sector();
            Etapa = new Estado();
            ClasificacionGasto = new ClasificacionGasto();
            AlineamientoPNDHPropuesto = new AlineamientoPNDH();

            Componentes = new ComponenteCollection();
            ProyectoCostos = new ProyectoCostoCollection();
            ProyectoGastos = new ProyectoGastoRecurrenteCollection();
            ProyectoBeneficiarios = new ProyectoBeneficiarioCollection();
        }

        public override int Codigo { get; set; }

        public int CodProyecto
        {
            get { return Codigo; }
        }

        public Componente Componente { get; set; }

        public int CodComponente
        {
            get { return Componente.Codigo; }
            set { Componente.Codigo = value; }
        }

        public Sector Sector { get; set; }

        public int CodSector
        {
            get { return Sector.Codigo; }
        }

        public Estado Etapa { get; set; }

        public int CodEtapa
        {
            get { return Etapa.Codigo; }
            set { Etapa.Codigo = value; }
        }

        public int CodTipoProyecto { get; set; }

        public ClasificacionGasto ClasificacionGasto { get; set; }

        public int CodClasificacionGasto
        {
            get { return ClasificacionGasto.Codigo; }
            set { ClasificacionGasto.Codigo = value; }
        }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string CodSnip { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "FechaInicioNotEmpty")]
        public DateTime FechaInicio { get; set; }        
        
        public DateTime FechaFinalizacion { get; set; }

        public string Objetivo { get; set; }

        public string Descripcion { get; set; }

        [ValidRange(Key = "MontoNotZeroOrNegative", Max = 9999999999.99, Min = 1)]
        public decimal CostoEstimado { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string Estrategia { get; set; }

        [ValidRange(Key = "MontoNotZeroOrNegative", Max = 9999999999.99, Min = 0.0001)]
        public Decimal Van { get; set; }

        [ValidRange(Key = "MontoNotZeroOrNegative", Max = 100.00, Min = 0.0001)]
        public Decimal Tir { get; set; }

        public AlineamientoPNDH AlineamientoPNDHPropuesto { get; set; }

        public int CodAlineamientoPropuestoPNDH
        {
            get { return AlineamientoPNDHPropuesto.Codigo; }
            set { AlineamientoPNDHPropuesto.Codigo = value; }
        }

        public int CodAlineamientoPNDH { get; set; }

        public ComponenteCollection Componentes { get; set; }

        public ProyectoCostoCollection ProyectoCostos { get; set; }

        public ProyectoGastoRecurrenteCollection ProyectoGastos { get; set; }

        public ProyectoBeneficiarioCollection ProyectoBeneficiarios { get; set; }

    }
}

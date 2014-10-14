using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase Financiamiento representa un financiamiento o acuerdo de financiamiento existente proveniente de una determinada
    /// agencia en base a un convenio firmado(Agencia+Fuente+Convenio)
    /// </summary>
    public class Financiamiento
    {
        #region Constructores

        public Financiamiento()
            : this(-1, -1, -1, -1, -1, 0M)
        {
        }
        public Financiamiento(int codObra, int anio, int codAgencia, int codFuente, int codConvenio, decimal montoAsignado)
        {
            IdPip = 7;
            IdMomento = 2;
            Agencia = new Agencia();
            Agencia.Codigo = codAgencia;
            Fuente = new Fuente();
            Fuente.Codigo = codFuente;
            Convenio = new Convenio();
            Convenio.Codigo = codConvenio;
        }

        #endregion

        #region Propiedades

        public int CodObra {get; set;}
        
        public int Anio {get; set;}
        
        public decimal MontoAsignado {get; set;}

        public int IdPip {get; set;}

        public int IdMomento {get; set;}

        public string IdFase {get; set;}

        public Convenio Convenio { get; set; }

        public Fuente Fuente { get; set; }

        public Agencia Agencia { get; set; }

        public int CodConvenio
        {
            get { return Convenio.Codigo;}
            set { Convenio.Codigo = value; }
        }
        public int CodAgencia 
        {
            get { return Agencia.Codigo; }
            set { Agencia.Codigo = value; }
        }
        public int CodFuente 
        {
            get { return Fuente.Codigo; }
            set { Fuente.Codigo = value; } 
        }

        #endregion

    }
}

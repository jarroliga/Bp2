using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase Obra representa una obra o actividad de un proyecto, donde la propiedad TipoComponente determina si se trata de
    /// una obra o de una actividad.
    /// </summary>
    public class Obra : BusinessBase 
    {
        #region Constructores

        public Obra()
        {
            Consecutivo = 0;
            Proyecto = new Proyecto();
        }

        #endregion

        #region Propiedades

        public Proyecto Proyecto {get; set;}

        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre {get; set;}

        public int Consecutivo {get; set;}

        public int Orden {get; set;}

        public int TipoComponente {get; set;}

        public string CodSnip 
        {
            get
            {
                if (Proyecto.CodSnip != null && Proyecto.CodSnip.Trim().Length > 0)
                {
                    if (TipoComponente == 0)
                    {
                        return Proyecto.CodSnip + "." + Consecutivo.ToString() + ".0";
                    }
                    else
                    {
                        return Proyecto.CodSnip + ".0." + Consecutivo.ToString();
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public DateTime? FechaInicioPrevista {get; set;}

        public DateTime? FechaInicioReal {get; set;}

        public DateTime? FechaFinPrevista {get; set;}

        public DateTime? FechaFinReal {get; set;}

        public FinanciamientoCollection Financiamientos {get; set;}

        public bool EsEditable { get; set; }

        public string Etiqueta
        {
            get { return CodSnip + " - " + Nombre; }
        }
        #endregion

    }
}

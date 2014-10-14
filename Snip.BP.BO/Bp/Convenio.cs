using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase Convenio representa un acuerdo o convenio para el financiamiento de los proyectos del PIP
    /// (Mapea a CatConvenio)
    /// </summary>
    public class Convenio : BusinessBase
    {
        #region Constructores

        public Convenio()
        {
            Activo = true;
        }

        #endregion
        
        #region Propiedades

        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "DescripcionNotNullOrEmpty")]
        public string Descripcion { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string IdExterno { get; set; }

        public DateTime? FechaFirma { get; set; }

        public DateTime? FechaLimiteDesembolso { get; set; }

        [ValidRange(Key = "MontoNotZeroOrNegative", Max = 9999999999.99, Min = 1)]
        public Decimal MontoTotal { get; set; }

        [ValidRange(Key = "MontoNotZeroOrNegative", Max = 9999999999.99, Min = 1)]
        public Decimal MontoContrapartida { get; set; }

        public bool Activo { get; set; }

        public string Etiqueta
        {
            get
            {
                if (IdExterno == null)
                {
                    return Nombre;
                }
                else
                {
                    return IdExterno;
                }
            }
        }

        public int CodConvenioAnterior { get; set; }

        #endregion

    }
}

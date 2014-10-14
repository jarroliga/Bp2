using System;
using System.ComponentModel;
using System.Diagnostics;

using Snip.BP.Validation;

namespace Snip.BP.BO.Bp
{
    /// <summary>
    /// La clase ListaPip representa un ejercicio determinado del PIP asociado a la lista de las obras y/o actividades de los proyectos que incluye.
    /// </summary>
    public class ListaPip : BusinessBase
    {
        #region Constructores

        public ListaPip()
        {
            CodPip = 7;
            CodMomento = 2;
            Activa = true;
        }

        #endregion

        #region Propiedades

        [DataObjectFieldAttribute(true, true, false)]
        public override int Codigo { get; set; }

        [NotNullOrEmpty(Key = "NombreNotNullOrEmpty")]
        public string Nombre { get; set; }

        [NotNullOrEmpty(Key = "IdentificadorNotNullOrEmpty")]
        public string Identificador { get; set; }

        [ValidRange(Message = "Debe digitar el año.", Max = 2024, Min = 1989)]
        public int Anio { get; set; }

        public string Rol { get; set; }

        public int Orden { get; set; }

        public bool Activa { get; set; }

        public int CodPip { get; set; }

        public int CodMomento { get; set; }

        public int CodListaProyecto { get; set; }

        #endregion
    }
}

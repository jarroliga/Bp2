using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;

namespace Snip.BP.BO.App
{
    public class Tabla : BusinessBase
    {
        #region Constructores

        public Tabla()
        {
        }

        public Tabla(int codigo, string nombre, string id, int codAplicacion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Identificador = id;
            Aplicacion aplicacion = new Aplicacion();
            aplicacion.Codigo = codAplicacion;
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }

        public string Nombre { get; set; }

        public string Identificador { get; set; }

        public string Descripcion {get; set; }

        public Aplicacion Aplicacion {get; set;}

        #endregion
    }
}

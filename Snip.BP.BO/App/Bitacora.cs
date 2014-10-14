using System;
using System.ComponentModel;
using System.Diagnostics;
using Snip.BP.Validation;


namespace Snip.BP.BO.App
{
    public class Bitacora : BusinessBase
    {
        #region Constructores

        public Bitacora()
        {
            Tabla = new Tabla();
            Evento = new Evento();
            Usuario = new Usuario();
        }

        #endregion

        #region Propiedades

        public override int Codigo { get; set; }
        public Tabla Tabla { get; set; }
        public Evento Evento { get; set; }
        public int CodRegistro { get; set; }
        public string Referencia { get; set; }
        public Usuario Usuario { get; set; }
        
        #endregion
    }
}

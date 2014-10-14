using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snip.BP.BO.Bp
{
    public class OrigenFondo
    {
        #region Constructores

        public OrigenFondo()
        {
            //Total = 0M;
            Prestamo = 0M;
            Donacion = 0M;
            Tesoro = 0M;
            RecursosPropios = 0M;
            Otros = 0M;
        }
        
        #endregion

        #region Propiedades

        public decimal Tesoro { get; set; }
        public decimal RecursosPropios { get; set; }
        public decimal Prestamo { get; set; }
        public decimal Donacion { get; set; }
        public decimal Otros { get; set; }
        
        public decimal Total 
        { 
            get 
            {
                return Prestamo + Donacion + Tesoro + RecursosPropios + Otros;
            } 
        }

        public decimal RecursosInternos
        {
            get
            {
                return Tesoro + RecursosPropios + Otros;
            }
        }
        public decimal RecursosExternos
        {
            get
            {
                return Prestamo + Donacion;
            }
        }

        #endregion
    }
}

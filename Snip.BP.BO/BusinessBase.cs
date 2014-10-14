using System;
using System.Resources;
using Snip.BP.Validation;
using Snip.BP.BO.Recursos;

namespace Snip.BP.BO
{
    public abstract class BusinessBase : ValidationBase
    {
        public BusinessBase()
        {
            Codigo = -1;
            FechaCreacion = DateTime.Now;
            FechaActualizacion = DateTime.Now;
            CodUsuarioCreacion = -1;
            CodUsuarioActualizacion = -1;
        }

        /// <summary>
        /// El codigo único de la instancia de BussinesBase en la base de datos.
        /// </summary>
        public abstract int Codigo { get; set; }

        /// <summary>
        /// Fecha de Creacion de la instancia de BussinesBase en la base de datos.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Fecha de Actualización de la instancia de BussinesBase en la base de datos.
        /// </summary>
        public DateTime FechaActualizacion { get; set; }

        public int CodUsuarioCreacion { get; set; }
        public int CodUsuarioActualizacion { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de concurrencia utilizado para mantener la pista de los cambios 
        /// en el registro de los datos subyacentes en la base de datos.
        /// </summary>
        /// <value>El id de concurrencia.</value>
        public byte[] IdConcurrencia { get; set; }

        /// <summary>
        /// El ResourceManager (manejador de recursos) demandado por el framework de validación.
        /// </summary>
        public static ResourceManager ResourceManager { get; set; }

        /// <summary>
        /// Obtiene el mensaje de validación (regionalizado) basado en la llave del mensaje.
        /// </summary>
        /// <param name="key">La llave de traducción del mensaje de validación.</param>
        protected override string GetValidationMessage(string key)
        {
            string tempValue;

            if (ResourceManager != null)
            {
                tempValue = ResourceManager.GetString(key);
            }
            else
            {
                tempValue = string.Empty;
            }
            if (string.IsNullOrEmpty(tempValue))
            {
                tempValue = General.ResourceManager.GetString(key);
            }
            return tempValue;
        }
    }
}

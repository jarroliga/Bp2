using System;
using System.Runtime.Serialization;

namespace Snip.BP.Validation
{
    /// <summary>
    /// La clase InvalidSaveOperationException es producida en la capa de negocios de la aplicación cuando
    /// un intento de salvar una instancia invalida de <see cref="ValidationBase" /> en la base de datos.
    /// </summary>
    [Serializable]
    public class InvalidSaveOperationException : Exception 
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public InvalidSaveOperationException()
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <param name="message">El mensaje de la excepción.</param>
        public InvalidSaveOperationException(string message)
            :base(message)
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <param name="message">El mensaje de la excepción.</param>
        /// <param name="innerException">La excepción interna.</param>
        public InvalidSaveOperationException(string message, Exception innerException)
            :base(message,innerException)
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Constructor de serialización.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected InvalidSaveOperationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }
}

using System;

namespace Snip.BP.Validation
{
    /// <summary>
    /// La clase ValidationAttribute es la clase base para todos los atributos de validacion que pueden aplicarse a las
    /// propiedades de los BO en orden de definir reglas de validación.
    /// </summary>
    /// <example>
    /// <code lang="cs">
    /// [NotNullOrEmpty()]
    /// public string Street
    /// { ... }
    /// </code>
    /// </example>
    public abstract class ValidationAttribute : Attribute
    {
        #region Variables Privadas

        private string key;
        private string message;

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Determina si el valor de las propiedades subyacentes (pasadas como parametros <paramref name="item"/>)
        /// es valido de acuerdo a la regla de validación.
        /// </summary>
        /// <param name="item">La propiedad subyacente a ser validada.</param>
        /// <returns><c>true</c> si el elemento especificado es valido; en caso contrario, <c>false</c>.</returns>
        public abstract bool IsValid(object item);

        /// <summary>
        /// Obtiene el mensaje de validación asociado con su validación.
        /// </summary>
        /// <value>El mensaje de validación.</value>
        /// <exception cref="ArgumentException">Se produce cuando la propiedad Key ya tiene un valor cuando se trata de establecer la propiedad Message.</exception>
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                if (!string.IsNullOrEmpty(this.key))
                {
                    throw new ArgumentException("No puede establecerse un mensaje cuando la llave ya ha sido establecida.");
                }
                this.message = value;
            }
        }

        /// <summary>
        /// Obtiene la llave de globalización asociada a esa validación.
        /// </summary>
        /// <value>La llave de globalización.</value>
        /// <exception cref="ArgumentException">Se produce cuando la propiedad Messahe ya tiene un valor cuando se trata de establecer la propiedad Key.</exception>
        public string Key
        {
            get
            {
                return this.key;
            }
            set
            {
                if (!string.IsNullOrEmpty(this.message))
                {
                    throw new ArgumentException("No se puede establecer la llave cuando el mensaje ha sido establecido.");
                }
                this.key = value;
            }
        }

        #endregion


    }
}

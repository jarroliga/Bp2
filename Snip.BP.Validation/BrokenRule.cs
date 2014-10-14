// -----------------------------------------------------------------------
// <copyright file="BrokenRule.cs" company="www.snip.gob.ni">
//   Proyecto de rediseño del Banco de Proyectos del SNIP.
// </copyright>
// -----------------------------------------------------------------------
using System;

namespace Snip.BP.Validation
{
    /// <summary>
    /// La clase BrokenRule provee información (localizada) sobre las reglas rotas de los validadores.
    /// </summary>
    [Serializable]
    public class BrokenRule
    {
        #region Variables privadas

        private string propertyName = string.Empty;

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de la clase BrokenRule.
        /// </summary>
        /// <param name="propertyName">El nombre de la propiedad que causo que se rompiera la regla.</param>
        /// <param name="message">El mensaje de error asociado a la regla rota.</param>
        public BrokenRule(string propertyName, string message)
        {
            this.propertyName = propertyName;
            this.Message = message;
        }

        #endregion

        #region Propiedades públicas

        /// <summary>
        /// Obtiene o establece el mensaje de error asociado con la regla rota.
        /// </summary>
        /// <value>El mensaje de error localizado (regionalizado).</value>
        public string Message { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la propiedad que causo que la regla se rompiera.
        /// </summary>
        /// <value>El nombre de la propiedad.</value>
        public string PropertyName
        {
            get { return this.propertyName; }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                this.propertyName = value;
            }
        }
        #endregion

        #region Metodos publicos

        /// <summary>
        /// Retorna un <see cref="T:System.String"/> que representa al <see cref="T:System.Object"/> actual.
        /// </summary>
        /// <returns>
        /// Un <see cref="T:System.String"/> que representa al <see cref="T:System.Object"/> actual.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", this.propertyName, Message);
        }

        #endregion
    }
}

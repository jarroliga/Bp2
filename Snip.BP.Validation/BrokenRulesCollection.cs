using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Snip.BP.Validation
{
    /// <summary>
    /// La clase BrokenRulesCollection esta diseñada para mantener elementos <see cref="BrokenRule"/> y proveer
    /// capacidades de consulta adicionales para recuperar instancias BrokenRule específicas.
    /// </summary>
    [Serializable]
    public class BrokenRulesCollection : Collection<BrokenRule>
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BrokenRulesCollection"/>.
        /// </summary>
        /// <param name="myList">Lista de reglas rotas</param>
        internal BrokenRulesCollection(IList<BrokenRule> myList)
            :base(myList)
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BrokenRulesCollection"/>.
        /// </summary>
        /// <param name="myList">Lista de reglas rotas</param>
        public BrokenRulesCollection()
        {
        }

        #endregion

        #region Metodos publicos

        /// <summary>
        /// Retorna una instancia de <c>BrokenRulesCollection</c> con las reglas para el nombre de propiedad especificada.
        /// </summary>
        /// <param name="propertyName">El nombre de la propiedad (case insensitive) a encontrar.</param>
        /// <returns>Una instancia de BrokenRulesCollection para la propiedad especificada. Retorna una coleccion vacia cuando la propiedad especificada no es encontrada.</returns>
        public BrokenRulesCollection FindByPropertyName(string propertyName)
        {
            return new BrokenRulesCollection((from rule in this
                                              where rule.PropertyName.ToUpperInvariant() == propertyName.ToUpperInvariant()
                                              select rule).ToList<BrokenRule>());
        }
        /// <summary>
        /// Returna una coleccion <c>BrokenRulesCollection</c> con las reglas que contienen (una parte) del mensaje especificado.
        /// </summary>
        /// <param name="message">La parte del mensaje a buscar (case insensitive)</param>
        /// <returns>Una coleccion <c>BrokenRulesCollection</c> conteniendo las reglas que coinciden con el mensaje especificado. Retorna una coleccion vacia cuando el mensaje no es encontrado.</returns>
        public BrokenRulesCollection FindByMessage(string message)
        {
            return new BrokenRulesCollection((from rule in this
                                              where rule.Message.ToUpperInvariant().Contains(message.ToUpperInvariant())
                                              select rule).ToList<BrokenRule>());
        }
        /// <summary>
        /// Crea una nueva instancia de BrokenRule y la agrega a la lista interna.
        /// </summary>
        /// <param name="message">El mensaje de validación asociado a la regla rota.</param>
        public void Add(string message)
        {
            Add(new BrokenRule(string.Empty, message));
        }

        /// <summary>
        ///  Crea una nueva instancia de BrokenRule y la agrega a la lista interna.
        /// </summary>
        /// <param name="propertyName">El nombre de la propiedad que causa que la regla sea rota. Puede ser dejada en blanco.</param>
        /// <param name="message">El mensaje de validación asociado con la regla rota.</param>
        public void Add(string propertyName, string message)
        {
            Add(new BrokenRule(propertyName, message));
        }

        /// <summary>
        /// Retorna un <see cref="T:System.String"/> que representa el <see cref="T:System.Object"/> actual.
        /// </summary>
        /// <returns>
        /// Un <see cref="T:System.String"/> que representa el <see cref="T:System.Object"/> actual.
        /// </returns>
        public override string ToString()
        {
            StringBuilder myStringBuilder = new StringBuilder();
            foreach (BrokenRule item in this)
            {
                myStringBuilder.Append(string.Format("{0}\r\n", item.ToString()));
            }
            return myStringBuilder.ToString();
        }
        #endregion

    }
}

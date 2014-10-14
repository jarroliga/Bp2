using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace Snip.BP.Validation
{
    /// <summary>
    /// La clase <c>ValidationBase</c> sirve como clase base para todas las entidades de negocios en las que se desee implementar 
    /// el comportamiento de validación. Proporciona métodos <c>Validate</c> que son capaces de comprobar la validez de las propiedades
    /// de esta instancia al observar los atributos aplicados.
    /// </summary>
    public abstract class ValidationBase
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BrokenRulesCollection brokenRules = new BrokenRulesCollection();


        /// <summary>
        /// Determina si la instancia actual cumple con todas las reglas de validación. Siempre limpia primero la colección BrokenRules 
        /// antes de añadir nuevas instancias de la clase BrokenRule.
        /// </summary>
        /// <overloads>
        /// Determina si la instancia actual cumple con todas las reglas de validación.
        /// </overloads>
        /// <returns>Retorna <c>true</c> si la instancia es valida, <c>false</c> en caso contrario.</returns>
        /// <remarks>Este método automaticamente limpia la colección interna de BrokenRules.</remarks>
        public virtual bool Validate()
        {
            return Validate(true);
        }

        /// <summary>
        /// Determina si la instancia actual cumple con todas las reglas de validación. Puede opcionalmente determinar
        /// si la coleccion de clases BrokenRule debe ser limpiada (borrada) antes.
        /// </summary>
        /// <param name="clearBrokenRules">Si es establecida en <c>true</c> la coleccion BrokenRules es limpiada primero.</param>
        /// <returns>
        /// Retorna <c>true</c> si la instancia es valida, <c>false</c> en caso contrario.
        /// </returns>
        public virtual bool Validate(bool clearBrokenRules)
        {
            if (clearBrokenRules)
            {
                this.BrokenRules.Clear();
            }

            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var valProps = from PropertyInfo property in properties
                           where property.GetCustomAttributes(typeof(ValidationAttribute), true).Length > 0
                           select new
                           {
                               Property = property,
                               ValidationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true)
                           };

            foreach (var item in valProps)
            {
                foreach (ValidationAttribute attribute in item.ValidationAttributes)
                {
                    if (attribute.IsValid(item.Property.GetValue(this, null)))
                    {
                        continue;
                    }

                    string message = string.Empty;
                    if (!string.IsNullOrEmpty(attribute.Key))
                    {
                        message = GetValidationMessage(attribute.Key);
                    }
                    else
                    {
                        message = attribute.Message;
                    }
                    BrokenRules.Add(new BrokenRule(item.Property.Name, message));
                }
            }
            return (BrokenRules.Count == 0);
        }

        /// <summary>
        /// Cuando se reemplaza en una clase hija, este metodo obtiene el mensaje de validación en un idioma determinado basado en la llave del mensaje.
        /// </summary>
        /// <param name="key">La llave de traducción de un mensaje de validación.</param>
        /// <returns>Por defecto, retorna la llave "tal cual" y no trata de localizarla. Las clases que reemplazan este método pueden regionalizar el método utilizando ResourceManager.</returns>
        protected virtual string GetValidationMessage(string key)
        {
            return key;
        }

        /// <summary>
        /// Obtiene una colección de instancias <see cref="BrokenRules"/> asociadas con esta instancia de ValidationBase.
        /// </summary>
        /// <value>Las reglas rotas asociadas con esta ValidationBase.</value>
        public BrokenRulesCollection BrokenRules
        {
            get { return this.brokenRules; }
        }
    }
}

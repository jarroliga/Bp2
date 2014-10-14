using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Snip.BP.Validation
{
    /// <summary>
    /// La clase ValidationCollectionBase sirve como la base clase para colecciones tales como BusinessCollectionBase.
    /// La clase de colección entera provee validación chequeando la validez de las instacias de ValidationBase en su colección.
    /// </summary>
    /// <typeparam name="T">Una clase que hereda de la clase ValidationBase</typeparam>
    public abstract class ValidationCollectionBase<T> : Collection<T> where T : ValidationBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public ValidationCollectionBase()
            :base(new List<T>())
        {
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase y la puebla con una lista inicial.
        /// </summary>
        /// <param name="initialList"></param>
        public ValidationCollectionBase(IList<T> initialList)
            : base(initialList)
        {
        }

        public virtual bool Validate()
        {
            foreach (T item in this)
            {
                if (!item.Validate())
                {
                    return false;
                }
            }
            return true;
        }
    }
}

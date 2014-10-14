using System;
using System.Collections.Generic;
using Snip.BP.Validation;

namespace Snip.BP.BO
{
    /// <summary>
    /// La clase BusinessCollectionBase sirve como clase base para todas las collecciones de entidades principales.
    /// Supera las limitaciones de las colecciones genéricas al implementar un método de ordenamiento.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusinessCollectionBase<T> : ValidationCollectionBase<T> where T : ValidationBase
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase BusinessCollectionBase
        /// </summary>
        public BusinessCollectionBase()
        {
        }

        public BusinessCollectionBase(IList<T> initialList)
            : base(initialList)
        {
        }
        /// <summary>
        /// Ordena la coleccion basado en un comparador especificado.
        /// </summary>
        /// <param name="comparer">El comparador utilizado para ordenar la coleccion.</param>
        public void Sort(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer", "Comparador es nulo.");
            }
            List<T> list = this.Items as List<T>;
            if (list == null)
            {
                return;
            }
            list.Sort(comparer);
        }

    }
}

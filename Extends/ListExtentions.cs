using System;
using System.Collections.Generic;
using System.Linq;

namespace Extends
{
    public static class ListExtentions
    {
        /// <summary>
        /// Methode d'extention permetant de cloner une liste d'objet
        /// </summary>
        /// <typeparam name="T">le type d'objet contenue dans la liste</typeparam>
        /// <param name="listToClone">La liste clonée</param>
        /// <remarks>T doit implémanter l'inteface ICloneable</remarks>
        /// <returns>Le clone</returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}

using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Collections
{
    public abstract class DotEntityWithIdCollection<T> : List<T>
        where T : IDotEntity
    {
        protected readonly Func<string, Predicate<T>> _matchIdPredicate;

        protected DotEntityWithIdCollection(Func<string, Predicate<T>> matchIdPredicate)
        {
            _matchIdPredicate = matchIdPredicate;
        }

        /// <summary>
        /// Determines whether the specified items is in the collection.
        /// </summary>
        /// <param name="id">The identifier of the items to locate in the collection.</param>
        public virtual bool Contains(string id)
        {
            return Exists(_matchIdPredicate(id));
        }

        /// <summary>
        /// Removes the first occurrence of an item with the specified identifier from the collection.
        /// </summary>
        /// <param name="id">The identifier of the item to remove.</param>
        public virtual bool Remove(string id)
        {
            var index = FindIndex(_matchIdPredicate(id));

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes all occurrences of an item with the specified identifier from the collection.
        /// </summary>
        /// <param name="id">The identifier of the items to remove.</param>
        public virtual int RemoveAll(string id)
        {
            return RemoveAll(_matchIdPredicate(id));
        }
    }
}

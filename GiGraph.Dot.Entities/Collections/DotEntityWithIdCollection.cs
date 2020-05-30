using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Collections
{
    public abstract class DotEntityWithIdCollection<T> : List<T>
        where T : IDotEntity
    {
        /// <summary>
        /// Searches for an item with the specified identifier, and returns the zero-based index of the first occurrence
        /// within the collection.
        /// </summary>
        /// <param name="id">The identifier of the items to search.</param>
        public abstract int IndexOf(string id);

        /// <summary>
        /// Determines whether the specified items is in the collection.
        /// </summary>
        /// <param name="id">The identifier of the items to locate in the collection.</param>
        public virtual bool Contains(string id)
        {
            return IndexOf(id) >= 0;
        }

        /// <summary>
        /// Removes the first occurrence of an item with the specified identifier from the collection.
        /// </summary>
        /// <param name="id">The identifier of the item to remove.</param>
        public virtual bool Remove(string id)
        {
            var index = IndexOf(id);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }
    }
}

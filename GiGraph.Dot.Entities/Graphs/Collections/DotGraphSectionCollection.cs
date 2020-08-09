using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Graphs.Collections
{
    public class DotGraphSectionCollection<TAttributes> : List<DotGraphSection<TAttributes>>
        where TAttributes : IDotAttributeCollection
    {
        protected readonly Func<DotGraphSection<TAttributes>> _createSection;

        public DotGraphSectionCollection(Func<DotGraphSection<TAttributes>> createSection)
        {
            _createSection = createSection;
        }

        /// <summary>
        ///     Adds the specified graph section to the collection and optionally initializes its content.
        /// </summary>
        /// <param name="section">
        ///     The section to add.
        /// </param>
        /// <param name="init">
        ///     An optional section initializer delegate.
        /// </param>
        protected virtual DotGraphSection<TAttributes> Add(DotGraphSection<TAttributes> section, Action<DotGraphSection<TAttributes>> init)
        {
            Add(section);
            init?.Invoke(section);
            return section;
        }

        /// <summary>
        ///     Adds a graph section to the collection and optionally initializes its content.
        /// </summary>
        /// <param name="init">
        ///     An optional section initializer delegate.
        /// </param>
        public virtual DotGraphSection<TAttributes> Add(Action<DotGraphSection<TAttributes>> init = null)
        {
            return Add(_createSection(), init);
        }
    }
}
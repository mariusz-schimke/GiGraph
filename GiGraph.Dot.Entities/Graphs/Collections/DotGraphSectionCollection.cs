using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Graphs.Collections
{
    public class DotGraphSectionCollection<TAttributes> : List<DotCommonGraphSection<TAttributes>>
        where TAttributes : IDotAttributeCollection
    {
        protected readonly Func<DotCommonGraphSection<TAttributes>> _createSection;

        public DotGraphSectionCollection(Func<DotCommonGraphSection<TAttributes>> createSection)
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
        protected virtual DotCommonGraphSection<TAttributes> Add(DotCommonGraphSection<TAttributes> section, Action<DotCommonGraphSection<TAttributes>> init)
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
        public virtual DotCommonGraphSection<TAttributes> Add(Action<DotCommonGraphSection<TAttributes>> init = null)
        {
            return Add(_createSection(), init);
        }
    }
}
using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Graphs.Collections
{
    public class DotGraphSectionCollection<TGraphAttributes> : List<DotGraphSection<TGraphAttributes>>
        where TGraphAttributes : IDotAttributeCollection
    {
        protected readonly Func<DotGraphSection<TGraphAttributes>> _createSection;

        public DotGraphSectionCollection(Func<DotGraphSection<TGraphAttributes>> createSection)
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
        public virtual DotGraphSection<TGraphAttributes> Add(DotGraphSection<TGraphAttributes> section, Action<DotGraphSection<TGraphAttributes>> init)
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
        public virtual DotGraphSection<TGraphAttributes> Add(Action<DotGraphSection<TGraphAttributes>> init = null)
        {
            return Add(_createSection(), init);
        }
    }
}
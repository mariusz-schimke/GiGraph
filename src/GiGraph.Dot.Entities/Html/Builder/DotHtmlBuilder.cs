using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Html.Builder
{
    /// <summary>
    ///     HTML builder.
    /// </summary>
    public partial class DotHtmlBuilder
    {
        protected readonly DotHtmlEntityCollection _entities;

        /// <summary>
        ///     Initializes a new instance.
        /// </summary>
        public DotHtmlBuilder()
        {
            _entities = new DotHtmlEntityCollection();
        }

        /// <summary>
        ///     Gets the number of entities in this builder.
        /// </summary>
        public virtual int Count => _entities.Count;

        /// <summary>
        ///     Appends an entity to the builder.
        /// </summary>
        /// <param name="entity">
        ///     The entity to append.
        /// </param>
        /// <param name="init">
        ///     An optional entity initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder Append<TEntity>(TEntity entity, Action<TEntity> init = null)
            where TEntity : IDotHtmlEntity
        {
            init?.Invoke(entity);
            _entities.Add(entity);
            return this;
        }

        /// <summary>
        ///     Appends HTML to the builder.
        /// </summary>
        /// <param name="html">
        ///     The HTML to append.
        /// </param>
        public virtual DotHtmlBuilder AppendHtml(string html)
        {
            _entities.Add(new DotHtml(html));
            return this;
        }

        /// <summary>
        ///     Builds output HTML from the content of the builder.
        /// </summary>
        public virtual DotHtmlEntity Build()
        {
            return new DotHtmlEntity<DotHtmlEntityCollection>(
                new DotHtmlEntityCollection((IEnumerable<IDotHtmlEntity>) _entities)
            );
        }
    }
}
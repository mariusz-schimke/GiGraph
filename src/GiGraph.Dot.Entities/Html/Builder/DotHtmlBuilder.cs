using System;
using GiGraph.Dot.Entities.Html.Image;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Builder
{
    /// <summary>
    ///     HTML builder.
    /// </summary>
    public class DotHtmlBuilder
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
        ///     Initializes a new instance with an HTML entity.
        /// </summary>
        public DotHtmlBuilder(IDotHtmlEntity entity)
        {
            _entities = new DotHtmlEntityCollection
            {
                entity
            };
        }

        /// <summary>
        ///     Initializes a new instance with HTML.
        /// </summary>
        public DotHtmlBuilder(string html)
            : this(new DotHtml(html))
        {
        }

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
        ///     Initializes and appends a table.
        /// </summary>
        /// <param name="init">
        ///     A table initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendTable(Action<DotHtmlTable> init)
        {
            return Append(new DotHtmlTable(), init);
        }

        /// <summary>
        ///     Initializes and appends an image.
        /// </summary>
        /// <param name="source">
        ///     Specifies the image file to be displayed.
        /// </param>
        /// <param name="scaling">
        ///     Specifies how the image will use any extra space available in its cell.
        /// </param>
        /// <param name="init">
        ///     An optional image initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendImage(string source, DotImageScaling? scaling = null, Action<DotHtmlImage> init = null)
        {
            return Append(new DotHtmlImage(source, scaling), init);
        }
    }
}
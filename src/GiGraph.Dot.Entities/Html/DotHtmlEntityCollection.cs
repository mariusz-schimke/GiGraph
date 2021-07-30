using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     Represents an HTML entity collection.
    /// </summary>
    public class DotHtmlEntityCollection : List<IDotHtmlEntity>, IDotHtmlEntity
    {
        /// <summary>
        ///     Creates a new entity collection.
        /// </summary>
        /// <param name="entities">
        ///     The entities to initialize the collection with.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when a null collection is passed.
        /// </exception>
        public DotHtmlEntityCollection(params IDotHtmlEntity[] entities)
            : base(entities)
        {
        }

        /// <summary>
        ///     Creates a new entity collection.
        /// </summary>
        /// <param name="entities">
        ///     The entities to initialize the collection with.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when a null collection is passed.
        /// </exception>
        public DotHtmlEntityCollection(IEnumerable<IDotHtmlEntity> entities)
            : base(entities)
        {
        }

        /// <inheritdoc cref="IDotHtmlEntity.ToHtml(GiGraph.Dot.Output.Options.DotSyntaxOptions,GiGraph.Dot.Output.Options.DotSyntaxRules)" />
        public virtual DotHtmlString ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return string.Join(string.Empty, this.Select(entity => entity.ToHtml(options, syntaxRules)));
        }

        /// <inheritdoc cref="IDotHtmlEntity.ToHtml()" />
        public virtual DotHtmlString ToHtml()
        {
            return ToHtml(DotSyntaxOptions.Default, DotSyntaxRules.Default);
        }
    }
}
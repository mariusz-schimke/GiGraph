using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Html
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

        /// <inheritdoc cref="IDotHtmlEntity" />
        public DotHtml ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return string.Join(string.Empty, this.Select(entity => entity.ToHtml(options, syntaxRules)));
        }

        /// <summary>
        ///     Creates a collection of entities to represent the specified text as HTML. All line breaks will be replaced with &lt;br /&gt;
        ///     tags.
        /// </summary>
        /// <param name="text">
        ///     The input text.
        /// </param>
        /// <param name="lineBreak">
        ///     The line break sequences to replace with HTML line break tags (see <see cref="DotNewLine" />).
        /// </param>
        public static DotHtmlEntityCollection FromMultilineText(string text, params string[] lineBreak)
        {
            if (text is null)
            {
                return new DotHtmlEntityCollection();
            }

            var result = new List<IDotHtmlEntity>();
            var lines = text.Split(lineBreak, StringSplitOptions.None);

            for (var i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                {
                    result.Add(new DotHtmlLineBreak());
                }

                result.Add(new DotHtmlTextContent(lines[i]));
            }

            return new DotHtmlEntityCollection(result);
        }

        /// <summary>
        ///     Creates a collection of entities to represent the specified text as HTML. All line breaks will be replaced with &lt;br /&gt;
        ///     tags.
        /// </summary>
        /// <param name="text">
        ///     The input text.
        /// </param>
        public static DotHtmlEntityCollection FromMultilineText(string text)
        {
            return FromMultilineText(text, DotNewLine.Windows, DotNewLine.Unix);
        }
    }
}
using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.TextEscaping;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Html.Text
{
    /// <summary>
    ///     Text content of an HTML element.
    /// </summary>
    public class DotHtmlTextContent : DotHtmlEntity
    {
        /// <summary>
        ///     Initializes a new HTML text instance.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the instance with.
        /// </param>
        public DotHtmlTextContent(string text)
        {
            Text = text;
        }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public virtual string Text { get; set; }

        /// <inheritdoc cref="IDotHtmlEntity.ToHtml(GiGraph.Dot.Output.Options.DotSyntaxOptions,GiGraph.Dot.Output.Options.DotSyntaxRules)" />
        public override DotHtmlString ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return syntaxRules.Attributes.Html.ElementTextContentEscaper.Escape(Text);
        }

        /// <summary>
        ///     Creates a collection of entities to represent the specified text as HTML. All line breaks will be replaced with &lt;br /&gt;
        ///     tags.
        /// </summary>
        /// <param name="text">
        ///     The input text.
        /// </param>
        /// <param name="lineBreaks">
        ///     The line break sequences to replace with HTML line break tags (see <see cref="DotNewLine" />).
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines of multiline text.
        /// </param>
        public static DotHtmlEntityCollection FromMultilineText(string text, string[] lineBreaks, DotHorizontalAlignment? horizontalAlignment = null)
        {
            if (text is null)
            {
                return new DotHtmlEntityCollection();
            }

            var result = new List<IDotHtmlEntity>();
            var lines = text.Split(lineBreaks, StringSplitOptions.None);

            for (var i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                {
                    result.Add(new DotHtmlLineBreak(horizontalAlignment));
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
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines of multiline text.
        /// </param>
        public static DotHtmlEntityCollection FromMultilineText(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            return FromMultilineText(text, new[] { DotNewLine.Windows, DotNewLine.Unix }, horizontalAlignment);
        }
    }
}
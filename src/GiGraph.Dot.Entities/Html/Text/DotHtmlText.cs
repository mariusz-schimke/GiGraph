using System;
using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Text;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Text
{
    /// <summary>
    ///     Textual content of an HTML element.
    /// </summary>
    public class DotHtmlText : DotHtmlEntity
    {
        protected static readonly string[] LineBreaks = { DotNewLine.Windows, DotNewLine.Unix };
        protected readonly string _text;

        /// <summary>
        ///     Initializes a new HTML text instance.
        /// </summary>
        /// <param name="text">
        ///     The text to initialize the instance with.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public DotHtmlText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            _text = text;
            LineAlignment = lineAlignment;
        }

        /// <summary>
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </summary>
        public virtual DotHorizontalAlignment? LineAlignment { get; }

        public override string ToString()
        {
            return _text;
        }

        protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var br = DotHtmlLineBreak.Html(LineAlignment, options, syntaxRules);
            var escaped = syntaxRules.Attributes.Html.ElementTextContentEscaper.Escape(_text);
            var lines = SplitMultiline(escaped, LineBreaks);

            return string.Join(br, lines);
        }

        protected static string[] SplitMultiline(string text, string[] lineBreaks)
        {
            return text?.Split(lineBreaks, StringSplitOptions.None) ?? Array.Empty<string>();
        }
    }
}
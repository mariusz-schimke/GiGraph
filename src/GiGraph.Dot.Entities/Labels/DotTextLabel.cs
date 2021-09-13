using System;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Labels
{
    /// <summary>
    ///     <para>
    ///         Represents a string label. The label can either be a plain text that will be escaped on output DOT script generation, or
    ///         an escaped string (<see cref="DotEscapedString" />) that follows the rules described in the
    ///         <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">
    ///             documentation
    ///         </see>
    ///         .
    ///     </para>
    ///     <para>
    ///         When you want to generate an HTML-like label, use <see cref="DotHtmlLabel" /> instead.
    ///     </para>
    /// </summary>
    public class DotTextLabel : DotLabel
    {
        protected readonly DotEscapeString _text;

        /// <summary>
        ///     Creates a new textual label.
        /// </summary>
        /// <param name="text">
        ///     The text to use.
        /// </param>
        public DotTextLabel(DotEscapeString text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text), "Text must not be null.");
        }

        /// <summary>
        ///     Returns the label as string.
        /// </summary>
        public override string ToString()
        {
            return _text;
        }

        protected override string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ((IDotEscapable) _text)?.GetEscaped(syntaxRules.Attributes.EscapeStringValueEscaper);
        }
    }
}
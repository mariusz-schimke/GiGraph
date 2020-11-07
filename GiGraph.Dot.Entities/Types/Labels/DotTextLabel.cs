using System;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Labels
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

        public DotTextLabel(DotEscapeString text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text), "Text cannot be null.");
        }

        public override string ToString()
        {
            return _text;
        }

        protected internal override string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return _text?.GetEscapedString(syntaxRules.TextValueEscaper);
        }

        public static implicit operator DotTextLabel(string text)
        {
            return text is {} ? new DotTextLabel(text) : null;
        }

        public static implicit operator DotTextLabel(DotEscapeString text)
        {
            return text is {} ? new DotTextLabel(text) : null;
        }

        public static implicit operator string(DotTextLabel label)
        {
            return label?._text;
        }

        public static implicit operator DotEscapeString(DotTextLabel label)
        {
            return label?._text;
        }
    }
}
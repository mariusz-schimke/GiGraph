using System;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Labels
{
    /// <summary>
    /// <para>
    ///     Represents a string label. The label can either be a plain text that will be escaped on output DOT script generation,
    ///     or an escaped string (<see cref="DotEscapedString"/>) that follows the rules described in the documentation available at
    ///     <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString"/>.
    /// </para>
    /// <para>
    ///     When you want to generate an HTML-like label, use <see cref="DotLabelHtml"/> instead.
    /// </para>
    /// </summary>
    public class DotLabelString : DotLabel
    {
        protected readonly DotEscapableString _text;

        protected DotLabelString(DotEscapableString text)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text), "Text cannot be null.");
        }

        protected DotLabelString(DotEscapedString text)
            : this((DotEscapableString) text)
        {
        }

        protected DotLabelString(string text)
            : this((DotEscapableString) text)
        {
        }

        public override string ToString()
        {
            return _text;
        }

        protected internal override string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return _text?.GetDotEncodedString(options, syntaxRules);
        }

        public static implicit operator DotLabelString(string value)
        {
            return value is {} ? new DotLabelString(value) : null;
        }

        public static implicit operator DotLabelString(DotEscapableString value)
        {
            return value is {} ? new DotLabelString(value) : null;
        }

        public static implicit operator DotLabelString(DotEscapedString value)
        {
            return value is {} ? new DotLabelString(value) : null;
        }

        public static implicit operator string(DotLabelString labelString)
        {
            return labelString?._text;
        }

        public static implicit operator DotEscapableString(DotLabelString labelString)
        {
            return labelString?._text;
        }
    }
}
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
    ///     When you want to generate an HTML-like label, use <see cref="DotLabelHtml"/>.
    /// </para>
    /// </summary>
    public class DotLabelString : IDotEncodableValue
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

        protected internal string GetDotEncodedString(DotGenerationOptions options)
        {
            return _text?.GetDotEncodedString(options);
        }

        string IDotEncodableValue.GetDotEncodedValue(DotGenerationOptions options) => GetDotEncodedString(options);

        /// <summary>
        /// Creates a label initialized with the specified text.
        /// </summary>
        /// <param name="text">The text to use as the label.</param>
        public static DotLabelString FromText(string text)
        {
            return text;
        }

        /// <summary>
        /// Creates a label initialized with escaped text. The text should be formatted according to the rules
        /// described in the documentation available at <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString"/>.
        /// If the text represents a record, its format should follow the rules available at
        /// <see href="http://www.graphviz.org/doc/info/shapes.html#record"/>.
        /// </summary>
        /// <param name="text">The escaped text to use as the label.</param>
        public static DotLabelString FromFormattedText(string text)
        {
            return (DotEscapedString) text;
        }

        /// <summary>
        /// Creates an HTML label. The HTML should be generated according to the rules
        /// described in the documentation available at <see href="http://www.graphviz.org/doc/info/shapes.html#html"/>
        /// </summary>
        /// <param name="html">The HTML to use as the label.</param>
        public static DotLabelHtml FromHtml(string html)
        {
            return html;
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
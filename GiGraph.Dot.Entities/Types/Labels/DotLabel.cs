using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Labels
{
    public abstract class DotLabel : IDotEncodableValue
    {
        protected internal abstract string GetDotEncodedString(DotGenerationOptions options);
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
        /// Creates a label initialized with formatted text. The text should be formatted and escaped according to the rules
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

        public static implicit operator DotLabel(string value)
        {
            return (DotLabelString) value;
        }

        public static implicit operator DotLabel(DotEscapableString value)
        {
            return (DotLabelString) value;
        }

        public static implicit operator DotLabel(DotEscapedString value)
        {
            return (DotLabelString) value;
        }
    }
}
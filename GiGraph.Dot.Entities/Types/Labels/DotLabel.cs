using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Labels
{
    /// <summary>
    /// Represents label. It can either be a text label (<see cref="DotLabelString"/>), or an HTML label (<see cref="DotLabelHtml"/>).
    /// <see cref="DotLabelRecord"/>, on the other hand, can be used for record-like nodes.
    /// </summary>
    public abstract class DotLabel : IDotEncodable
    {
        protected internal abstract string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules);
        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedString(options, syntaxRules);

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
        /// described in the <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">escape string documentation</see>.
        /// If the text represents a record, its format should follow the rules described in the
        /// <see href="http://www.graphviz.org/doc/info/shapes.html#record">record node documentation</see>.
        /// </summary>
        /// <param name="text">The escaped text to use as the label.</param>
        public static DotLabelString FromFormattedText(string text)
        {
            return (DotEscapedString) text;
        }

        /// <summary>
        /// Creates an HTML label. The HTML should be generated according to the rules
        /// described in the <see href="http://www.graphviz.org/doc/info/shapes.html#html">documentation</see>.
        /// </summary>
        /// <param name="html">The HTML to use as the label.</param>
        public static DotLabelHtml FromHtml(string html)
        {
            return html;
        }

        /// <summary>
        /// Creates a label initialized with the specified record.
        /// </summary>
        /// <param name="record">The record to use as the label.</param>
        public static DotLabelRecord FromRecord(DotRecord record)
        {
            return record;
        }

        public static implicit operator DotLabel(string text)
        {
            return (DotLabelString) text;
        }

        public static implicit operator DotLabel(DotEscapableString text)
        {
            return (DotLabelString) text;
        }

        public static implicit operator DotLabel(DotEscapedString text)
        {
            return (DotLabelString) text;
        }

        public static implicit operator DotLabel(DotRecord record)
        {
            return (DotLabelRecord) record;
        }

        public static implicit operator DotLabel(DotRecordField[] recordFields)
        {
            return (DotRecord) recordFields;
        }

        public static implicit operator DotLabel(string[] recordFields)
        {
            return (DotRecord) recordFields;
        }
    }
}
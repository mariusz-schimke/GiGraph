using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Records;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Types.Labels
{
    /// <summary>
    ///     Represents label. It can either be a text label (<see cref="DotTextLabel" />), or an HTML label (<see cref="DotHtmlLabel" />
    ///     ). <see cref="DotRecordLabel" />, on the other hand, can be used for record-like nodes.
    /// </summary>
    public abstract class DotLabel : IDotComplexType
    {
        string IDotComplexType.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedString(options, syntaxRules);
        }

        protected internal abstract string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

        /// <summary>
        ///     Creates a label initialized with the specified text.
        /// </summary>
        /// <param name="text">
        ///     The text to use as the label.
        /// </param>
        public static DotTextLabel FromText(string text)
        {
            return text;
        }

        /// <summary>
        ///     Creates a label initialized with formatted text. The text should be formatted and escaped according to the rules described in
        ///     the
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#k:escString">
        ///         escape string documentation
        ///     </see>
        ///     . If the text represents a record, its format should follow the rules described in the
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#record">
        ///         record node documentation
        ///     </see>
        ///     .
        /// </summary>
        /// <param name="text">
        ///     The escaped text to use as the label.
        /// </param>
        public static DotTextLabel FromFormattedText(string text)
        {
            return (DotEscapedString) text;
        }

        /// <summary>
        ///     Creates an HTML label. The HTML should be generated according to the rules described in the
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
        ///         documentation
        ///     </see>
        ///     .
        /// </summary>
        /// <param name="html">
        ///     The HTML to use as the label.
        /// </param>
        public static DotHtmlLabel FromHtml(string html)
        {
            return html;
        }

        /// <summary>
        ///     Creates a label initialized with the specified record.
        /// </summary>
        /// <param name="record">
        ///     The record to use as the label.
        /// </param>
        public static DotRecordLabel FromRecord(DotRecord record)
        {
            return record;
        }

        public static implicit operator DotLabel(string text)
        {
            return (DotTextLabel) text;
        }

        public static implicit operator DotLabel(DotEscapeString text)
        {
            return (DotTextLabel) text;
        }

        public static implicit operator DotLabel(DotRecord record)
        {
            return (DotRecordLabel) record;
        }

        public static implicit operator DotLabel(DotHtmlString html)
        {
            return (DotHtmlLabel) html;
        }
    }
}
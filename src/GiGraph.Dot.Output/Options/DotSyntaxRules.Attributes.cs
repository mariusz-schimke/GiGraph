using GiGraph.Dot.Output.Text.Escaping;
using GiGraph.Dot.Output.Text.Escaping.Pipelines;

namespace GiGraph.Dot.Output.Options;

public partial class DotSyntaxRules
{
    public class AttributeRules
    {
        /// <summary>
        ///     A text escaper to use for attribute keys (no escaping is used by default).
        /// </summary>
        public IDotTextEscaper KeyEscaper { get; set; } = DotTextEscapingPipeline.None();

        /// <summary>
        ///     A text escaper to use for string values (only quotation marks and trailing backslashes are escaped by default).
        /// </summary>
        public IDotTextEscaper StringValueEscaper { get; set; } = DotTextEscapingPipeline.ForString();

        /// <summary>
        ///     A text escaper to use for escape string values.
        /// </summary>
        public IDotTextEscaper EscapeStringValueEscaper { get; set; } = DotTextEscapingPipeline.ForEscapeString();

        /// <summary>
        ///     A text escaper to use for fields of record-shaped node labels.
        /// </summary>
        public IDotTextEscaper RecordLabelValueFieldEscaper { get; set; } = DotTextEscapingPipeline.ForRecordLabelField();

        /// <summary>
        ///     A text escaper to use for ports of record-shaped node labels.
        /// </summary>
        public IDotTextEscaper RecordLabelValuePortEscaper { get; set; } = DotTextEscapingPipeline.ForRecordLabelPort();

        /// <summary>
        ///     Syntax rules for HTML attributes.
        /// </summary>
        public HtmlRules Html { get; protected set; } = new();
    }
}
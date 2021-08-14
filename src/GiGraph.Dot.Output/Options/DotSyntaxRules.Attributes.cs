using GiGraph.Dot.Output.Text.Escaping;
using GiGraph.Dot.Output.Text.Escaping.Pipelines;

namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxRules
    {
        public class AttributeRules
        {
            /// <summary>
            ///     A text escaper to use for attribute keys (no escaping is used by default).
            /// </summary>
            public virtual IDotTextEscaper KeyEscaper { get; set; } = DotTextEscapingPipeline.None();

            /// <summary>
            ///     A text escaper to use for string values (only quotation marks and trailing backslashes are escaped by default).
            /// </summary>
            public virtual IDotTextEscaper StringValueEscaper { get; set; } = DotTextEscapingPipeline.ForString();

            /// <summary>
            ///     A text escaper to use for escape string values.
            /// </summary>
            public virtual IDotTextEscaper EscapeStringValueEscaper { get; set; } = DotTextEscapingPipeline.ForEscapeString();

            /// <summary>
            ///     A text escaper to use for fields of record-shaped node labels.
            /// </summary>
            public virtual IDotTextEscaper RecordLabelValueFieldEscaper { get; set; } = DotTextEscapingPipeline.ForRecordLabelField();

            /// <summary>
            ///     A text escaper to use for ports of record-shaped node labels.
            /// </summary>
            public virtual IDotTextEscaper RecordLabelValuePortEscaper { get; set; } = DotTextEscapingPipeline.ForRecordLabelPort();

            /// <summary>
            ///     Syntax rules for HTML attributes.
            /// </summary>
            public virtual HtmlRules Html { get; protected set; } = new();
        }
    }
}
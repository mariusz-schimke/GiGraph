using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxRules
    {
        public class AttributeRules
        {
            public static readonly IDotTextEscaper DefaultEscapeStringEscaper = new DotTextEscapingPipeline
            (
                DefaultStringEscaper,
                new DotLineBreakEscaper()
            );

            public static readonly IDotTextEscaper DefaultRecordLabelBaseEscaper = new DotTextEscapingPipeline
            (
                new DotAngleBracketsEscaper(),
                new DotCurlyBracketsEscaper(),
                new DotVerticalBarEscaper(),
                new DotSpaceEscaper()
            );

            /// <summary>
            ///     A text escaper to use for attribute keys (no escaping is used by default).
            /// </summary>
            public virtual IDotTextEscaper KeyEscaper { get; set; } = DotTextEscapingPipeline.None();

            /// <summary>
            ///     A text escaper to use for string values (only quotation marks and backslashes are escaped by default).
            /// </summary>
            public virtual IDotTextEscaper StringValueEscaper { get; set; } = DefaultStringEscaper;

            /// <summary>
            ///     A text escaper to use for escape string values.
            /// </summary>
            public virtual IDotTextEscaper EscapeStringValueEscaper { get; set; } = DefaultEscapeStringEscaper;

            /// <summary>
            ///     A text escaper to use for fields of record node labels.
            /// </summary>
            public virtual IDotTextEscaper RecordLabelValueFieldEscaper { get; set; } = new DotTextEscapingPipeline(DefaultEscapeStringEscaper, DefaultRecordLabelBaseEscaper);

            /// <summary>
            ///     A text escaper to use for ports of record node labels.
            /// </summary>
            public virtual IDotTextEscaper RecordLabelValuePortEscaper { get; set; } = new DotTextEscapingPipeline(DefaultStringEscaper, DefaultRecordLabelBaseEscaper);
        }
    }
}
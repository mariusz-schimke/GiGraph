using System;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Labels
{
    /// <summary>
    ///     Represents a record label. The value is a compatible record string following the rules described in the
    ///     <see href="http://www.graphviz.org/doc/info/shapes.html#record">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    public class DotRecordLabel : DotLabel
    {
        protected readonly DotRecord _record;

        protected DotRecordLabel(DotRecord record)
        {
            _record = record ?? throw new ArgumentNullException(nameof(record), "Record cannot be null.");
        }

        public override string ToString()
        {
            return _record.GetDotEncoded(new DotGenerationOptions(), new DotSyntaxRules(), hasParent: false);
        }

        protected internal override string GetDotEncodedString(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return _record?.GetDotEncoded(options, syntaxRules, hasParent: false);
        }

        public static implicit operator DotRecordLabel(DotRecord record)
        {
            return record is {} ? new DotRecordLabel(record) : null;
        }

        public static implicit operator DotRecord(DotRecordLabel label)
        {
            return label?._record;
        }
    }
}
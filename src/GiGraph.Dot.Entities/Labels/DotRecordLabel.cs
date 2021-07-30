using System;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Records;

namespace GiGraph.Dot.Entities.Labels
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

        /// <summary>
        ///     Creates a new record label.
        /// </summary>
        /// <param name="record">
        ///     The record to use.
        /// </param>
        public DotRecordLabel(DotRecord record)
        {
            _record = record ?? throw new ArgumentNullException(nameof(record), "Record must not be null.");
        }

        protected internal override string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return ((IDotComplexType) _record)?.GetDotEncodedValue(options, syntaxRules);
        }

        public static implicit operator DotRecordLabel(DotRecord record)
        {
            return record is not null ? new DotRecordLabel(record) : null;
        }

        public static implicit operator DotRecord(DotRecordLabel label)
        {
            return label?._record;
        }
    }
}
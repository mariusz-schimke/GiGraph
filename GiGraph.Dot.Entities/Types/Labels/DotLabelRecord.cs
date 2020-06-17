using System;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Labels
{
    /// <summary>
    /// Represents a record label. The value is a compatible record string following the rules described in the documentation
    /// available at <see href="http://www.graphviz.org/doc/info/shapes.html#record"/>. 
    /// </summary>
    public class DotLabelRecord : DotLabel
    {
        protected readonly DotRecord _record;

        protected DotLabelRecord(DotRecord record)
        {
            _record = record ?? throw new ArgumentNullException(nameof(record), "Record cannot be null.");
        }

        protected internal override string GetDotEncodedString(DotGenerationOptions options)
        {
            return _record?.GetDotEncoded(options, hasParent: false);
        }

        public static implicit operator DotLabelRecord(DotRecord value)
        {
            return value is {} ? new DotLabelRecord(value) : null;
        }

        public static implicit operator DotRecord(DotLabelRecord value)
        {
            return value?._record;
        }

        public static implicit operator DotLabelRecord(DotRecordField[] value)
        {
            return value is {} ? new DotRecord(value) : null;
        }

        public static implicit operator DotLabelRecord(string[] value)
        {
            return value is {} ? new DotRecord(value) : null;
        }
    }
}
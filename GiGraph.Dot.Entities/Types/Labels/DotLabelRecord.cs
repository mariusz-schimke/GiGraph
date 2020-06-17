using System;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Labels
{
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
    }
}
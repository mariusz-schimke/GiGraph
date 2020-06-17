using System;
using System.Linq;
using System.Text;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Records
{
    public class DotRecord : DotRecordField
    {
        public DotRecordField[] Fields { get; }
        public bool Flip { get; set; }

        public DotRecord(DotRecordField[] fields, bool flip = false)
        {
            Fields = fields ?? throw new ArgumentNullException(nameof(fields), "Field collection cannot be null.");
            Flip = flip;
        }

        protected internal override string GetDotEncoded(DotGenerationOptions options, bool hasParent)
        {
            var result = new StringBuilder();

            var braces = new[] { hasParent, Flip }.Where(x => x).ToList();
            var fields = Fields.Select(field => field.GetDotEncoded(options, hasParent: true));

            braces.ForEach(brace => result.Append("{ "));
            result.Append(string.Join(" | ", fields));
            braces.ForEach(brace => result.Append(" }"));

            return result.ToString();
        }
    }
}
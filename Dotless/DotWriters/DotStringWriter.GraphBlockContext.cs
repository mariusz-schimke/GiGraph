using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public abstract class GraphBlockContext : DotWriterContext
        {
            protected GraphBlockContext(StreamWriter writer, DotFormattingOptions options, int level)
                : base(writer, options, level)
            {
            }

            public override void EndContext()
            {
                WriteBlockEnd();
            }

            public virtual GraphAttributeListContext BeginAttributeListContext(bool preferExplicitAttributeDelimiter)
            {
                return new GraphAttributeListContext(_writer, _options, _level + 1, preferExplicitAttributeDelimiter);
            }

            public virtual GraphNodeListContext BeginNodeListContext(string id, bool quoteId, bool preferExplicitNodeDelimiter)
            {
                return new GraphNodeListContext(_writer, _options, _level + 1, preferExplicitNodeDelimiter);
            }

            public virtual SubgraphContext BeginSubgraphContext(string? name, bool quoteName)
            {
                return new SubgraphContext(_writer, _options, _level + 1, name, quoteName);
            }
        }
    }
}

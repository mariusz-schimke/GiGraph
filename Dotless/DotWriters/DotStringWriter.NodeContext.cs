using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class NodeContext : DotWriterContext, IDotNodeWriter
        {
            public NodeContext(StreamWriter writer, DotFormattingOptions options, int level, string id, bool quoteId)
                : base(writer, options, level)
            {
                WriteIdentifier(id, quoteId);
            }

            public virtual IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator)
            {
                return new NodeAttributesContext(_writer, _options, _level + 1, useAttributeSeparator);
            }
        }
    }
}

using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters.StringWriter
{
    public partial class DotStringWriter
    {
        public class NodeContext : DotWriterContext, IDotNodeWriter
        {
            public NodeContext(StreamWriter writer, DotFormattingOptions options, int level)
                : base(writer, options, level)
            {
            }

            public void WriteNodeIdentifier(string id, bool quote)
            {
                WriteIdentifier(id, quote);
            }

            public virtual IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator)
            {
                WriteListStart();
                PushLineBreak();

                return new NodeAttributesContext(_writer, _options, _level + 1, useAttributeSeparator);
            }

            public void EndAttributeList()
            {
                WriteListEnd();
            }
        }
    }
}

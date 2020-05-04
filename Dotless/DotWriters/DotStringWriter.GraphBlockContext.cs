using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public abstract class GraphBlockContext : DotWriterContext, IDotGraphBodyWriter
        {
            protected GraphBlockContext(StreamWriter writer, DotFormattingOptions options, int level)
                : base(writer, options, level)
            {
            }

            public override void EndContext()
            {
                WriteBlockEnd();
            }

            public virtual IDotAttributeCollectionWriter BeginAttributesSection(bool preferExplicitAttributeDelimiter)
            {
                return new GraphAttributesContext(_writer, _options, _level + 1, preferExplicitAttributeDelimiter);
            }

            public virtual IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter)
            {
                return new GraphNodesContext(_writer, _options, _level + 1, useStatementDelimiter);
            }

            public virtual IDotSubgraphWriter BeginSubgraphContext(string? name, bool quoteName)
            {
                return new SubgraphContext(_writer, _options, _level + 1, name, quoteName);
            }
        }
    }
}

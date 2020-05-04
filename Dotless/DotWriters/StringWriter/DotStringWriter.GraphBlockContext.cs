using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters.StringWriter
{
    public partial class DotStringWriter
    {
        public abstract class GraphBlockContext : DotWriterContext, IDotGraphBodyWriter
        {
            protected GraphBlockContext(StreamWriter writer, DotFormattingOptions options, int level)
                : base(writer, options, level)
            {
            }

            public virtual IDotAttributeCollectionWriter BeginAttributesSection(bool preferExplicitAttributeDelimiter)
            {
                return new GraphAttributesContext(_writer, _options, _level + 1, preferExplicitAttributeDelimiter);
            }

            public void EndAttributesSection()
            {
                PushLineBreak();
            }

            public virtual IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter)
            {
                return new GraphNodesContext(_writer, _options, _level + 1, useStatementDelimiter);
            }

            public void EndNodesSection()
            {
                PushLineBreak();
            }

            public virtual IDotSubgraphWriter BeginSubgraphContext(string? name, bool quoteName)
            {
                return new SubgraphContext(_writer, _options, _level + 1, name, quoteName);
            }
        }
    }
}

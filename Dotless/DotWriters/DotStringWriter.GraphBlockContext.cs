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

            public virtual GraphAttributesContext BeginAttributesContext(bool preferExplicitAttributeDelimiter)
            {
                return new GraphAttributesContext(_writer, _options, _level + 1, preferExplicitAttributeDelimiter);
            }

            public virtual GraphNodesContext BeginNodesContext(bool useStatementDelimiter)
            {
                return new GraphNodesContext(_writer, _options, _level + 1, useStatementDelimiter);
            }

            public virtual SubgraphContext BeginSubgraphContext(string? name, bool quoteName)
            {
                return new SubgraphContext(_writer, _options, _level + 1, name, quoteName);
            }
        }
    }
}

using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters.StringWriter
{
    public partial class DotStringWriter
    {
        public class GraphNodesContext : DotWriterContext, IDotNodeCollectionWriter
        {
            protected readonly bool _useStatementDelimiter;

            public GraphNodesContext(StreamWriter writer, DotFormattingOptions options, int level, bool useStatementDelimiter)
                : base(writer, options, level)
            {
                _useStatementDelimiter = useStatementDelimiter;
            }

            public IDotNodeWriter BeginNode()
            {
                return new NodeContext(_writer, _options, _level);
            }

            public void EndNode()
            {
                WriteStatementEnd();
            }
        }
    }
}

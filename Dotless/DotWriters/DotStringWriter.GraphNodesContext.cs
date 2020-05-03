using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class GraphNodesContext : DotWriterContext
        {
            protected readonly bool _useStatementDelimiter;

            public GraphNodesContext(StreamWriter writer, DotFormattingOptions options, int level, bool useStatementDelimiter)
                : base(writer, options, level)
            {
                _useStatementDelimiter = useStatementDelimiter;
                WriteListStart();
            }

            public override void EndContext()
            {
                PushLineBreak();
                WriteListEnd();
            }

            public NodeContext BeginNodeContext(string id, bool quoteId)
            {
                return new NodeContext(_writer, _options, _level, id, quoteId);
            }
        }
    }
}

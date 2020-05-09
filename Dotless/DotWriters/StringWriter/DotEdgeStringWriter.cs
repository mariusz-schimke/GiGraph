using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotEdgeStringWriter : DotEntityWithAttributeListStringWriter, IDotEdgeWriter
    {
        public DotEdgeStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context)
            : base(writer, format, context)
        {
        }

        public virtual void WriteEdge(string leftNodeId, bool quoteLeftNodeId, string rightNodeId, bool quoteRightNodeId)
        {
            _writer.Identifier(leftNodeId, quoteLeftNodeId)
                   .Space()
                   .Edge(_context.IsDirectedGraph)
                   .Space()
                   .Identifier(rightNodeId, quoteRightNodeId)
                   .Space(linger: true);
        }
    }
}

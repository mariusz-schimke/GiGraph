using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.StringWriter
{
    public class DotEdgeStringWriter : DotEntityWithAttributeListStringWriter, IDotEdgeWriter
    {
        public DotEdgeStringWriter(DotStringWriter writer, DotEntityWriterContext context)
            : base(writer, context)
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

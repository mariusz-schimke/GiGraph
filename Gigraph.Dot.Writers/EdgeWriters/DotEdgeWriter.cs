using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public class DotEdgeWriter : DotEntityWithAttributeListWriter, IDotEdgeWriter
    {
        public DotEdgeWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteEdge(string leftNodeId, bool quoteLeftNodeId, string rightNodeId, bool quoteRightNodeId)
        {
            _tokenWriter.Identifier(leftNodeId, quoteLeftNodeId)
                        .Space()
                        .Edge(_context.IsDirectedGraph)
                        .Space()
                        .Identifier(rightNodeId, quoteRightNodeId)
                        .Space(linger: true);
        }
    }
}

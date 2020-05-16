using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.EdgeWriters
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

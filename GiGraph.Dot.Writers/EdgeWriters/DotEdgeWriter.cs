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

        public virtual void WriteEdge(string tailNodeId, bool quoteTailNodeId, string headNodeId, bool quoteHeadNodeId)
        {
            _tokenWriter.Identifier(tailNodeId, quoteTailNodeId)
                        .Space()
                        .Edge(_context.IsDirectedGraph)
                        .Space()
                        .Identifier(headNodeId, quoteHeadNodeId)
                        .Space(linger: true);
        }
    }
}

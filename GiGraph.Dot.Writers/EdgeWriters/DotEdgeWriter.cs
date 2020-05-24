using GiGraph.Dot.Writers.AttributeWriters;
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

        public virtual void WriteNodeId(string nodeId, bool quote)
        {
            _tokenWriter.Identifier(nodeId, quote);
        }

        public virtual void WriteEdge()
        {
            // these will be removed by the parent chain writer if no further edges are written
            _tokenWriter.Space(linger: true)
                        .Edge(_context.IsDirectedGraph, linger: true)
                        .Space(linger: true);
        }

        public virtual IDotAttributeStatementWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _tokenWriter.ClearLingerBuffer()
                        .Space(linger: true);

            return base.BeginAttributeList(useAttributeSeparator);
        }
    }
}

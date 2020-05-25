using GiGraph.Dot.Writers.AttributeWriters;
using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;
using GiGraph.Dot.Writers.SubgraphWriters;

namespace GiGraph.Dot.Writers.EdgeWriters
{
    public class DotEdgeWriter : DotEntityWithAttributeListWriter, IDotEdgeWriter
    {
        public DotEdgeWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public override IDotAttributeStatementWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _tokenWriter.ClearLingerBuffer()
                        .Space(linger: true);

            return base.BeginAttributeList(useAttributeSeparator);
        }

        public virtual void WriteNode(string nodeId, bool quoteNodeId, string portName, bool quotePortName, string compassPoint, bool quoteCompassPoint)
        {
            _tokenWriter.Identifier(nodeId, quoteNodeId);

            if (portName is { })
            {
                _tokenWriter.NodePortDelimiter()
                            .Identifier(portName, quotePortName);
            }

            if (compassPoint is { })
            {
                _tokenWriter.NodePortDelimiter()
                            .Identifier(compassPoint, quoteCompassPoint);
            }

            WriteEdge();
        }

        public IDotSubgraphWriter BeginSubgraph(bool preferExplicitKeyword)
        {
            return new DotSubgraphWriter(_tokenWriter.SingleLine(), _context, preferExplicitKeyword);
        }

        public void EndSubgraph()
        {
            _tokenWriter.ClearLingerBuffer();
            WriteEdge();
        }

        protected virtual void WriteEdge()
        {
            // these will be removed by the parent writer if no further edges are written
            _tokenWriter.Space(linger: true)
                        .Edge(_context.IsDirectedGraph, linger: true)
                        .Space(linger: true);
        }
    }
}

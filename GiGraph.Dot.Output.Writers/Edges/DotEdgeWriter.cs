using GiGraph.Dot.Output.Writers.Attributes;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Writers.Edges
{
    public class DotEdgeWriter : DotEntityWithAttributeListWriter, IDotEdgeWriter
    {
        public DotEdgeWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public override IDotAttributeListItemWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _tokenWriter.ClearLingerBuffer()
               .Space(linger: true);

            return base.BeginAttributeList(useAttributeSeparator);
        }

        public virtual IDotEndpointWriter BeginEndpoint()
        {
            return new DotEndpointWriter(_tokenWriter, _context);
        }

        public virtual void EndEndpoint()
        {
        }

        public virtual IDotSubgraphWriter BeginSubgraph(bool preferExplicitDeclaration)
        {
            return new DotSubgraphWriter(_tokenWriter, _context, preferExplicitDeclaration);
        }

        public virtual void EndSubgraph()
        {
            _tokenWriter.ClearLingerBuffer();
        }

        public virtual void WriteEdge()
        {
            // these will be removed by the parent writer if no further endpoints are written
            _tokenWriter.Space(linger: true)
               .Edge(_context.IsDirectedGraph, linger: true)
               .Space(linger: true);
        }
    }
}
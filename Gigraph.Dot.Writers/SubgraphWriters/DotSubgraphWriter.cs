using Gigraph.Dot.Writers.Contexts;
using Gigraph.Dot.Writers.GraphWriters;

namespace Gigraph.Dot.Writers.SubgraphWriters
{
    public class DotSubgraphWriter : DotGraphBlockWriter, IDotSubgraphWriter
    {
        public DotSubgraphWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteSubgraphDeclaration(string id, bool quote)
        {
            _tokenWriter.Keyword("subgraph");

            if (id is { })
            {
                _tokenWriter.Space()
                            .Identifier(id, quote);
            }

            _tokenWriter.LineBreak()
                        .Indentation(_context.Level);
        }
    }
}

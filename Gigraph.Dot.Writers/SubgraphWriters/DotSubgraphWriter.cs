using Gigraph.Dot.Writers.Contexts;
using Gigraph.Dot.Writers.GraphWriters;

namespace Gigraph.Dot.Writers.SubgraphWriters
{
    public class DotSubgraphWriter : DotGraphBlockWriter, IDotSubgraphWriter
    {
        protected readonly bool _preferExplicitSubgraphKeyword;

        public DotSubgraphWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool preferExplicitSubgraphKeyword)
            : base(tokenWriter, context)
        {
            _preferExplicitSubgraphKeyword = preferExplicitSubgraphKeyword;
        }

        public virtual void WriteSubgraphDeclaration(string id, bool quote)
        {
            var separate = false;

            if (_preferExplicitSubgraphKeyword || id is { })
            {
                _tokenWriter.Keyword("subgraph");
                separate = true;
            }

            if (id is { })
            {
                if (separate)
                {
                    _tokenWriter.Space();
                }

                _tokenWriter.Identifier(id, quote);
            }

            if (separate)
            {
                _tokenWriter.LineBreak()
                            .Indentation(_context.Level);
            }

        }
    }
}

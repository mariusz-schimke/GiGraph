using GiGraph.Dot.Output.Writers.Graphs;

namespace GiGraph.Dot.Output.Writers.Subgraphs
{
    public class DotSubgraphWriter : DotGraphBlockWriter, IDotSubgraphWriter
    {
        protected readonly bool _preferExplicitSubgraphKeyword;

        public DotSubgraphWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool preferExplicitSubgraphKeyword)
            : base(tokenWriter, configuration)
        {
            _preferExplicitSubgraphKeyword = preferExplicitSubgraphKeyword;
        }

        public virtual void WriteSubgraphDeclaration(string id, bool quoteId)
        {
            var separate = false;

            if (_preferExplicitSubgraphKeyword || id is not null)
            {
                _tokenWriter.Keyword("subgraph");
                separate = true;
            }

            if (id is not null)
            {
                _tokenWriter.Space();
                _tokenWriter.Identifier(id, quoteId);
            }

            if (separate)
            {
                _tokenWriter.LineBreak()
                   .Indentation();
            }
        }
    }
}
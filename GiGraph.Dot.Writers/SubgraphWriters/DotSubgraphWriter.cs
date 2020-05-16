using GiGraph.Dot.Writers.Contexts;
using GiGraph.Dot.Writers.GraphWriters;

namespace GiGraph.Dot.Writers.SubgraphWriters
{
    public class DotSubgraphWriter : DotGraphBlockWriter, IDotSubgraphWriter
    {
        protected readonly bool _preferExplicitSubgraphKeyword;

        public DotSubgraphWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool preferExplicitSubgraphKeyword)
            : base(tokenWriter, context)
        {
            _preferExplicitSubgraphKeyword = preferExplicitSubgraphKeyword;
        }

        public virtual void WriteSubgraphDeclaration(string id, bool isCluster, bool quoteId)
        {
            id = FormatIdentifier(id, isCluster, ref quoteId);
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

                _tokenWriter.Identifier(id, quoteId);
            }

            if (separate)
            {
                _tokenWriter.LineBreak()
                            .Indentation(_context.Level);
            }
        }

        protected virtual string FormatIdentifier(string id, bool isCluster, ref bool quoteId)
        {
            var cluster = "cluster";

            if (isCluster && id is { })
            {
                quoteId = true;
                return $"{cluster} {id}";
            }

            if (isCluster)
            {
                return cluster;
            }

            return id;
        }
    }
}

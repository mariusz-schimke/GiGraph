namespace GiGraph.Dot.Output.Writers.Subgraphs
{
    public class DotSubgraphWriterRoot : DotEntityWriter, IDotSubgraphWriterRoot
    {
        public DotSubgraphWriterRoot(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration, enforceBlockComment: true)
        {
        }

        public virtual IDotSubgraphWriter BeginSubgraph(bool preferExplicitDeclaration)
        {
            return BeginSubgraph(preferExplicitDeclaration, _configuration.Formatting.Subgraphs.SingleLine);
        }

        public virtual void EndSubgraph()
        {
            EndSubgraph(_configuration.Formatting.Subgraphs.SingleLine);
        }

        public override void EndComment()
        {
            EmptyLine();
        }

        protected virtual IDotSubgraphWriter BeginSubgraph(bool preferExplicitDeclaration, bool singleLine)
        {
            return new DotSubgraphWriter(
                singleLine ? _tokenWriter.SingleLine() : _tokenWriter,
                _configuration,
                preferExplicitDeclaration
            );
        }

        protected virtual void EndSubgraph(bool singleLine)
        {
            _tokenWriter.ClearLingerBuffer();

            if (singleLine)
            {
                LineBreak();
            }
            else
            {
                EmptyLine();
            }
        }
    }
}
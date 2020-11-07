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
            return new DotSubgraphWriter(_tokenWriter, _configuration, preferExplicitDeclaration);
        }

        public virtual void EndSubgraph()
        {
            _tokenWriter.ClearLingerBuffer();
            EmptyLine();
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}
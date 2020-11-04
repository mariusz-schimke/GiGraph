namespace GiGraph.Dot.Output.Writers.Subgraphs
{
    public class DotSubgraphWriterRoot : DotEntityWriter, IDotSubgraphWriterRoot
    {
        public DotSubgraphWriterRoot(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context, enforceBlockComment: true)
        {
        }

        public virtual IDotSubgraphWriter BeginSubgraph(bool preferExplicitDeclaration)
        {
            return new DotSubgraphWriter(_tokenWriter, _context, preferExplicitDeclaration);
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
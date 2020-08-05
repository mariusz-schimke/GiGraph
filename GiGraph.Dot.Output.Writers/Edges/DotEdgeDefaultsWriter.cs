namespace GiGraph.Dot.Output.Writers.Edges
{
    public class DotEdgeDefaultsWriter : DotEntityWithAttributeListWriter, IDotEdgeDefaultsWriter
    {
        public DotEdgeDefaultsWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteEdgeKeyword()
        {
            _tokenWriter.Keyword("edge")
               .Space();
        }
    }
}
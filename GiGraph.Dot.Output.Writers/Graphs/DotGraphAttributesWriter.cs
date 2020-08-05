namespace GiGraph.Dot.Output.Writers.Graphs
{
    public class DotGraphAttributesWriter : DotEntityWithAttributeListWriter, IDotGraphAttributesWriter
    {
        public DotGraphAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteGraphKeyword()
        {
            _tokenWriter.Keyword("graph")
               .Space();
        }
    }
}
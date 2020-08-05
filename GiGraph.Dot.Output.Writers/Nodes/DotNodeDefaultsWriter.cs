namespace GiGraph.Dot.Output.Writers.Nodes
{
    public class DotNodeDefaultsWriter : DotEntityWithAttributeListWriter, IDotNodeDefaultsWriter
    {
        public DotNodeDefaultsWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteNodeKeyword()
        {
            _tokenWriter.Keyword("node")
               .Space();
        }
    }
}
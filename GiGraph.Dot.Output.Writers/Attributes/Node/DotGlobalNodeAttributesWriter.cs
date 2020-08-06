namespace GiGraph.Dot.Output.Writers.Attributes.Node
{
    public class DotGlobalNodeAttributesWriter : DotEntityWithAttributeListWriter, IDotGlobalNodeAttributesWriter
    {
        public DotGlobalNodeAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
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
namespace GiGraph.Dot.Output.Writers.Attributes.Graph
{
    public class DotGlobalGraphAttributesWriter : DotEntityWithAttributeListWriter, IDotGlobalGraphAttributesWriter
    {
        public DotGlobalGraphAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
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
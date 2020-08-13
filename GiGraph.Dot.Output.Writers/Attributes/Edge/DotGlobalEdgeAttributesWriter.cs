namespace GiGraph.Dot.Output.Writers.Attributes.Edge
{
    public class DotGlobalEdgeAttributesWriter : DotEntityWithAttributeListWriter, IDotGlobalEdgeAttributesWriter
    {
        public DotGlobalEdgeAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
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
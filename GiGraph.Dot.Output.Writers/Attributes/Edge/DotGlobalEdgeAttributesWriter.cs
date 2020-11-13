namespace GiGraph.Dot.Output.Writers.Attributes.Edge
{
    public class DotGlobalEdgeAttributesWriter : DotEntityWithAttributeListWriter, IDotGlobalEdgeAttributesWriter
    {
        public DotGlobalEdgeAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration)
        {
        }

        public virtual void WriteEdgeKeyword()
        {
            _tokenWriter.Keyword("edge")
               .Space();
        }
    }
}
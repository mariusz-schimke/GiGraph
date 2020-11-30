namespace GiGraph.Dot.Output.Writers.Attributes.Graph
{
    public class DotGlobalGraphAttributesWriter : DotEntityWithAttributeListWriter, IDotGlobalGraphAttributesWriter
    {
        public DotGlobalGraphAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration, configuration.Formatting.GlobalAttributes.SingleLineGraphAttributes)
        {
        }

        public virtual void WriteGraphKeyword()
        {
            _tokenWriter.Keyword("graph")
               .Space(linger: true);
        }
    }
}
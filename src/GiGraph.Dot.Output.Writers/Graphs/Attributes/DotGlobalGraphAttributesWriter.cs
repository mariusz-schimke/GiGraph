namespace GiGraph.Dot.Output.Writers.Graphs.Attributes
{
    public class DotGlobalGraphAttributesWriter : DotEntityWithAttributeListWriter, IDotGlobalGraphAttributesWriter
    {
        public DotGlobalGraphAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
            : base(tokenWriter, configuration, configuration.Formatting.GlobalAttributes.SingleLineGraphAttributeList)
        {
        }

        public virtual void WriteGraphKeyword()
        {
            _tokenWriter.Keyword("graph")
               .Space(linger: true);
        }
    }
}
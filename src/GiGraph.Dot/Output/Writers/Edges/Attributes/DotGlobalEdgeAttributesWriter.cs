using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Edges.Attributes;

public class DotGlobalEdgeAttributesWriter : DotEntityWithAttributeListWriter, IDotGlobalEdgeAttributesWriter
{
    public DotGlobalEdgeAttributesWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
        : base(tokenWriter, configuration, configuration.Formatting.GlobalAttributes.SingleLineEdgeAttributeList)
    {
    }

    public virtual void WriteEdgeKeyword()
    {
        _tokenWriter.Keyword("edge")
            .Space(linger: true);
    }
}
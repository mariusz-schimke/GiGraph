namespace GiGraph.Dot.Output.Writers.Edges.Attributes;

public interface IDotGlobalEdgeAttributesWriter : IDotEntityWithAttributeListWriter
{
    void WriteEdgeKeyword();
}
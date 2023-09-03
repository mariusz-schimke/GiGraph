namespace GiGraph.Dot.Output.Writers.Nodes.Attributes;

public interface IDotGlobalNodeAttributesWriter : IDotEntityWithAttributeListWriter
{
    void WriteNodeKeyword();
}
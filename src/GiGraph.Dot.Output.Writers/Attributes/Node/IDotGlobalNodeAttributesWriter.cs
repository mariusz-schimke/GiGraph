namespace GiGraph.Dot.Output.Writers.Attributes.Node
{
    public interface IDotGlobalNodeAttributesWriter : IDotEntityWithAttributeListWriter
    {
        void WriteNodeKeyword();
    }
}
namespace GiGraph.Dot.Output.Writers.Graphs
{
    public interface IDotGraphAttributesWriter : IDotEntityWithAttributeListWriter
    {
        void WriteGraphKeyword();
    }
}
namespace GiGraph.Dot.Output.Writers.Nodes
{
    public interface IDotNodeWriter : IDotEntityWithAttributeListWriter
    {
        void WriteNodeIdentifier(string id, bool quote);
    }
}
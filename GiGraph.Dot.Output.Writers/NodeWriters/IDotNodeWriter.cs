using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.NodeWriters
{
    public interface IDotNodeWriter : IDotEntityWithAttributeListWriter
    {
        void WriteNodeIdentifier(string id, bool quote);
    }
}
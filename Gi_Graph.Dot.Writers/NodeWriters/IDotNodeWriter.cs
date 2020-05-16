using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeWriter : IDotEntityWithAttributeListWriter
    {
        void WriteNodeIdentifier(string id, bool quote);
    }
}
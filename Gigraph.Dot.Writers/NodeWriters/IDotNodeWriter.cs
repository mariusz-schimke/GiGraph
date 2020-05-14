using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public interface IDotNodeWriter : IDotEntityWithAttributeListWriter
    {
        void WriteNodeIdentifier(string id, bool quote);
    }
}
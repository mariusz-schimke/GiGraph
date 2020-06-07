using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.GraphWriters
{
    public interface IDotGraphAttributesWriter : IDotEntityWithAttributeListWriter
    {
        void WriteGraphKeyword();
    }
}
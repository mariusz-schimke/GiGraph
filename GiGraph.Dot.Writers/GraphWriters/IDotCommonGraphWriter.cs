using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.GraphWriters
{
    public interface IDotCommonGraphWriter : IDotEntityWriter
    {
        IDotGraphBodyWriter BeginBody();
        void EndBody();
    }
}

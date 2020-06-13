using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.GraphWriters
{
    public interface IDotCommonGraphWriter : IDotEntityWriter
    {
        IDotGraphBodyWriter BeginBody();
        void EndBody();
    }
}

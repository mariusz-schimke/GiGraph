using GiGraph.Dot.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Writers.GraphWriters
{
    public interface IDotGraphWriterRoot : IDotEntityWriter
    {
        IDotGraphWriter BeginGraph(bool directed);
        void EndGraph();
    }
}

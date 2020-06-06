using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.GraphWriters
{
    public interface IDotGraphWriterRoot : IDotEntityWriter
    {
        IDotGraphWriter BeginGraph(bool directed);
        void EndGraph();
    }
}

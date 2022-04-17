namespace GiGraph.Dot.Output.Writers.Graphs;

public interface IDotGraphWriterRoot : IDotEntityWriter
{
    IDotGraphWriter BeginGraph(bool directed);
    void EndGraph();
}
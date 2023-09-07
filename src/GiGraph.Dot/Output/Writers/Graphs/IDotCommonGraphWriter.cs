namespace GiGraph.Dot.Output.Writers.Graphs;

public interface IDotCommonGraphWriter : IDotEntityWriter
{
    IDotGraphBodyWriter BeginBody();
    void EndBody();
}
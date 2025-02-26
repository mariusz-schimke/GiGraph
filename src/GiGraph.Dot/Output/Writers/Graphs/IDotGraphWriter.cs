namespace GiGraph.Dot.Output.Writers.Graphs;

public interface IDotGraphWriter : IDotCommonGraphWriter
{
    void WriteGraphDeclaration(string? id, bool strict, bool quoteId);
}
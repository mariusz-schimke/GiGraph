using GiGraph.Dot.Output.Writers.Attributes;

namespace GiGraph.Dot.Output.Writers.Graphs.Attributes;

public interface IDotGlobalGraphAttributeStatementWriter : IDotEntityWriter
{
    IDotAttributeWriter BeginAttributeStatement();
    void EndAttributeStatement();
}
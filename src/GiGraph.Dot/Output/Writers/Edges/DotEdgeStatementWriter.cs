using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Edges;

public class DotEdgeStatementWriter : DotEntityStatementWriter, IDotEdgeStatementWriter
{
    public DotEdgeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
        : base(tokenWriter, configuration, useStatementDelimiter)
    {
    }

    public virtual IDotEdgeWriter BeginEdgeStatement(bool containsSubgraphs, bool containsAttributes)
    {
        var isMultiline =
            (containsSubgraphs && !_configuration.Formatting.Edges.SingleLineSubgraphs) ||
            (containsAttributes && !_configuration.Formatting.Edges.SingleLineAttributeLists);

        isMultiline &= !_configuration.Formatting.SingleLine;

        return new DotEdgeWriter(
            _paddedEntityWriter.BeginEntity(enforcePadding: isMultiline),
            _configuration
        );
    }

    public virtual void EndEdgeStatement()
    {
        EndStatement();
    }
}
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Nodes;

public class DotNodeStatementWriter : DotEntityStatementWriter, IDotNodeStatementWriter
{
    public DotNodeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
        : base(tokenWriter, configuration, useStatementDelimiter)
    {
    }

    public virtual IDotNodeWriter BeginNodeStatement(bool containsAttributes)
    {
        var isMultiline = !_configuration.Formatting.SingleLine &&
            containsAttributes && !_configuration.Formatting.Nodes.SingleLineAttributeLists;

        return new DotNodeWriter(
            _paddedEntityWriter.BeginEntity(enforcePadding: isMultiline),
            _configuration
        );
    }

    public virtual void EndNodeStatement()
    {
        EndStatement();
    }
}
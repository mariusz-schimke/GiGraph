using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers;

public abstract class DotEntityStatementWriter : DotEntityWriter
{
    protected readonly DotPaddedEntityWriter _paddedEntityWriter;
    protected readonly bool _useStatementDelimiter;

    protected DotEntityStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
        : base(tokenWriter, configuration, enforceBlockComment: true)
    {
        _useStatementDelimiter = useStatementDelimiter;
        _paddedEntityWriter = new(tokenWriter);
    }

    public virtual void EndStatement()
    {
        _tokenWriter.ClearLingerBuffer();

        if (_useStatementDelimiter)
        {
            _tokenWriter.StatementDelimiter();
        }

        _paddedEntityWriter.EndEntity();
    }

    public override void EndComment()
    {
        EmptyLine();
    }
}
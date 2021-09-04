using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers
{
    public abstract class DotEntityStatementWriter : DotEntityWriter
    {
        protected readonly DotSeparableEntityWriter _separableEntityWriter;
        protected readonly bool _useStatementDelimiter;

        protected DotEntityStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
            : base(tokenWriter, configuration, enforceBlockComment: true)
        {
            _useStatementDelimiter = useStatementDelimiter;
            _separableEntityWriter = new DotSeparableEntityWriter(tokenWriter);
        }

        public virtual void EndStatement()
        {
            _tokenWriter.ClearLingerBuffer();

            if (_useStatementDelimiter)
            {
                _tokenWriter.StatementDelimiter();
            }

            _separableEntityWriter.EndEntity();
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}
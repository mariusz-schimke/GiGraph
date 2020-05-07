using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public abstract class DotStatementStringWriter : DotEntityStringWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotStatementStringWriter(DotStringWriter writer, DotFormattingOptions options, int level, bool useStatementDelimiter)
            : base(writer, options, level)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual void EndStatement()
        {
            _writer.ClearLingerBuffer();

            if (_useStatementDelimiter)
            {
                _writer.StatementEnd();
            }

            _writer.LineBreak()
                   .Indentation(_level, linger: true);
        }
    }
}

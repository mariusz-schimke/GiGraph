using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public abstract class DotStatementStringWriter : DotEntityStringWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotStatementStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(writer, format, context)
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
                   .Indentation(_context.Level, linger: true);
        }
    }
}

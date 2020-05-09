using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.StringWriter
{
    public abstract class DotStatementStringWriter : DotEntityStringWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotStatementStringWriter(DotStringWriter writer, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(writer, context)
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

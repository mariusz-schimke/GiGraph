using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.CommonEntityWriters
{
    public abstract class DotEntityStatementWriter : DotEntityWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotEntityStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual void EndStatement()
        {
            _tokenWriter.ClearLingerBuffer();

            if (_useStatementDelimiter)
            {
                _tokenWriter.StatementEnd();
            }

            _tokenWriter.LineBreak()
                        .Indentation(_context.Level, linger: true);
        }
    }
}

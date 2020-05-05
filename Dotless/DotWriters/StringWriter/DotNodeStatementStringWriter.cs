using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotNodeStatementStringWriter : DotEntityStringWriter, IDotNodeCollectionWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotNodeStatementStringWriter(DotStringWriter writer, DotFormattingOptions options, int level, bool useStatementDelimiter)
            : base(writer, options, level)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual IDotNodeWriter BeginNode()
        {
            return new DotNodeStringWriter(_writer, _options, _level);
        }

        public virtual void EndNode()
        {
            if (_useStatementDelimiter)
            {
                _writer.StatementEnd();
            }

            _writer.LineBreak()
                   .Indentation(_level, linger: true);
        }
    }
}

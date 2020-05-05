using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotAttributeStatementStringWriter : DotAttributeListStringWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotAttributeStatementStringWriter(DotStringWriter writer, DotFormattingOptions options, int level, bool useStatementDelimiter)
            : base(writer, options, level)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public override void EndAttribute()
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

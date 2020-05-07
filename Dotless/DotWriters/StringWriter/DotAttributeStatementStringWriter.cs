using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotAttributeStatementStringWriter : DotAttributeListStringWriter
    {
        public DotAttributeStatementStringWriter(DotStringWriter writer, DotFormattingOptions options, int level, bool useStatementDelimiter)
            : base(writer, options, level, useStatementDelimiter)
        {
        }

        public override void EndAttribute()
        {
            if (_useAttributeSeparator)
            {
                _writer.StatementEnd();
            }

            _writer.LineBreak()
                   .Indentation(_level, linger: true);
        }
    }
}

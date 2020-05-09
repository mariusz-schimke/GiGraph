using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotAttributeStatementStringWriter : DotAttributeListStringWriter
    {
        public DotAttributeStatementStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(writer, format, context, useStatementDelimiter)
        {
        }

        public override void EndAttribute()
        {
            if (_useAttributeSeparator)
            {
                _writer.StatementEnd();
            }

            _writer.LineBreak()
                   .Indentation(_context.Level, linger: true);
        }
    }
}

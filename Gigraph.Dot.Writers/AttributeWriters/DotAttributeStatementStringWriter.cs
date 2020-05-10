using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.AttributeWriters
{
    public class DotAttributeStatementStringWriter : DotAttributeListStringWriter
    {
        public DotAttributeStatementStringWriter(DotStringWriter writer, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(writer, context, useStatementDelimiter)
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

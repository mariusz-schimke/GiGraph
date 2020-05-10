using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.AttributeWriters
{
    public class DotAttributeStatementWriter : DotAttributeListWriter
    {
        public DotAttributeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, useStatementDelimiter)
        {
        }

        public override void EndAttribute()
        {
            if (_useAttributeSeparator)
            {
                _tokenWriter.StatementEnd();
            }

            _tokenWriter.LineBreak()
                        .Indentation(_context.Level, linger: true);
        }
    }
}

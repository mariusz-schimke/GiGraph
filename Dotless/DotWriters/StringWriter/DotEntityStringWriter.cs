using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public abstract class DotEntityStringWriter : IDotEntityWriter
    {
        protected readonly DotStringWriter _writer;
        protected readonly DotFormattingOptions _format;
        protected readonly DotEntityWriterContext _context;

        protected DotEntityStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context)
        {
            _writer = writer;
            _format = format;
            _context = context;
        }
    }
}

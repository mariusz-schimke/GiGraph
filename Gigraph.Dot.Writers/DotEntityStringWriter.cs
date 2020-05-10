using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers
{
    public abstract class DotEntityStringWriter : IDotEntityWriter
    {
        protected readonly DotStringWriter _writer;
        protected readonly DotEntityWriterContext _context;

        protected DotEntityStringWriter(DotStringWriter writer, DotEntityWriterContext context)
        {
            _writer = writer;
            _context = context;
        }
    }
}

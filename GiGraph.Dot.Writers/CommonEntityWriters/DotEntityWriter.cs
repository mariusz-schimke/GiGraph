using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.CommonEntityWriters
{
    public abstract class DotEntityWriter : IDotEntityWriter
    {
        protected readonly DotTokenWriter _tokenWriter;
        protected readonly DotEntityWriterContext _context;

        protected DotEntityWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
        {
            _tokenWriter = tokenWriter;
            _context = context;
        }
    }
}

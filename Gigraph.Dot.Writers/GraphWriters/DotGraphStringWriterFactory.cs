using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public class DotGraphStringWriterFactory : IDotGraphWriterFactory
    {
        protected readonly DotStringWriter _writer;
        protected readonly int _level;

        public DotGraphStringWriterFactory(DotStringWriter writer, int level = 0)
        {
            _writer = writer;
            _level = level;
        }

        public IDotGraphWriter Create(bool directed)
        {
            return new DotGraphStringWriter(_writer, new DotEntityWriterContext(_level, directed));
        }
    }
}

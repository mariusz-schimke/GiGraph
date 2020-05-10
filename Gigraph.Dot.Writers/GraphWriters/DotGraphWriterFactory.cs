using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public class DotGraphWriterFactory : IDotGraphWriterFactory
    {
        protected readonly DotTokenWriter _tokenWriter;
        protected readonly int _level;

        public DotGraphWriterFactory(DotTokenWriter tokenWriter, int level = 0)
        {
            _tokenWriter = tokenWriter;
            _level = level;
        }

        public virtual IDotGraphWriter Create(bool directed)
        {
            _tokenWriter.Indentation(_level, linger: true);
            return new DotGraphWriter(_tokenWriter, new DotEntityWriterContext(_level, directed));
        }
    }
}

using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotGraphStringWriterFactory : IDotGraphWriterFactory
    {
        protected readonly DotStringWriter _writer;
        protected readonly DotFormattingOptions _format;
        private readonly int _level;

        public DotGraphStringWriterFactory(DotStringWriter writer, DotFormattingOptions format, int level = 0)
        {
            _writer = writer;
            _format = format;
            _level = level;
        }

        public IDotGraphWriter Create(bool directed)
        {
            return new DotGraphStringWriter(_writer, _format, new DotEntityWriterContext(_level, directed));
        }
    }
}

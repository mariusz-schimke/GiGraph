using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public abstract class DotEntityStringWriter : IDotEntityWriter
    {
        protected readonly DotStringWriter _writer;
        protected readonly DotFormattingOptions _options;
        protected readonly int _level;

        public DotEntityStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
        {
            _writer = writer;
            _options = options;
            _level = level;
        }
    }
}

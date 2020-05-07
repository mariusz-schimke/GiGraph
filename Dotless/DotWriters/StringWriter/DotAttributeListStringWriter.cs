using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotAttributeListStringWriter : DotEntityStringWriter, IDotAttributeCollectionWriter
    {
        protected readonly bool _useAttributeSeparator;

        public DotAttributeListStringWriter(DotStringWriter writer, DotFormattingOptions options, int level, bool useAttributeSeparator)
            : base(writer, options, level)
        {
            _useAttributeSeparator = useAttributeSeparator;
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            return new DotAttributeStringWriter(_writer, _options, _level);
        }

        public virtual void EndAttribute()
        {
            if (_useAttributeSeparator)
            {
                _writer.AttributeSeparator(linger: true);
            }

            _writer.Space(linger: true);
        }
    }
}

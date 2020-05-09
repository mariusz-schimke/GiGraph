using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotAttributeListStringWriter : DotEntityStringWriter, IDotAttributeCollectionWriter
    {
        protected readonly bool _useAttributeSeparator;

        public DotAttributeListStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context, bool useAttributeSeparator)
            : base(writer, format, context)
        {
            _useAttributeSeparator = useAttributeSeparator;
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            return new DotAttributeStringWriter(_writer, _format, _context);
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

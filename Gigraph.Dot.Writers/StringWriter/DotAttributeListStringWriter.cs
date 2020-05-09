using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.StringWriter
{
    public class DotAttributeListStringWriter : DotEntityStringWriter, IDotAttributeCollectionWriter
    {
        protected readonly bool _useAttributeSeparator;

        public DotAttributeListStringWriter(DotStringWriter writer, DotEntityWriterContext context, bool useAttributeSeparator)
            : base(writer, context)
        {
            _useAttributeSeparator = useAttributeSeparator;
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            return new DotAttributeStringWriter(_writer, _context);
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

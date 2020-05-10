using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.AttributeWriters
{
    public class DotAttributeListWriter : DotEntityWriter, IDotAttributeCollectionWriter
    {
        protected readonly bool _useAttributeSeparator;

        public DotAttributeListWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useAttributeSeparator)
            : base(tokenWriter, context)
        {
            _useAttributeSeparator = useAttributeSeparator;
        }

        public virtual IDotAttributeWriter BeginAttribute()
        {
            return new DotAttributeWriter(_tokenWriter, _context);
        }

        public virtual void EndAttribute()
        {
            if (_useAttributeSeparator)
            {
                _tokenWriter.AttributeSeparator(linger: true);
            }

            _tokenWriter.Space(linger: true);
        }
    }
}

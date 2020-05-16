using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.AttributeWriters
{
    public class DotAttributeListItemWriter : DotEntityWriter, IDotAttributeStatementWriter
    {
        protected readonly bool _useAttributeSeparator;

        public DotAttributeListItemWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useAttributeSeparator)
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

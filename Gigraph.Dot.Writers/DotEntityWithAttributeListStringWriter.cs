using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers
{
    public abstract class DotEntityWithAttributeListStringWriter : DotEntityStringWriter
    {
        public DotEntityWithAttributeListStringWriter(DotStringWriter writer, DotEntityWriterContext context)
            : base(writer, context)
        {
        }

        public virtual IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _writer.AttributeListStart(linger: true)
                   .Space(linger: true);

            return new DotAttributeListStringWriter(_writer, _context.NextLevel(), useAttributeSeparator);
        }

        public virtual void EndAttributeList(int attributeCount)
        {
            _writer.ClearLingerBuffer();

            if (attributeCount > 0)
            {
                _writer.Space()
                       .AttributeListEnd();
            }
        }
    }
}

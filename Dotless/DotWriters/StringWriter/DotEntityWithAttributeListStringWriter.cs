using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public abstract class DotEntityWithAttributeListStringWriter : DotEntityStringWriter
    {
        public DotEntityWithAttributeListStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context)
            : base(writer, format, context)
        {
        }

        public virtual IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _writer.AttributeListStart(linger: true)
                   .Space(linger: true);

            return new DotAttributeListStringWriter(_writer, _format, _context.NextLevel(), useAttributeSeparator);
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

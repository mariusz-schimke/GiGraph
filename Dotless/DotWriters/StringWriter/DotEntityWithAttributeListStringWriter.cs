using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public abstract class DotEntityWithAttributeListStringWriter : DotEntityStringWriter
    {
        public DotEntityWithAttributeListStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
            : base(writer, options, level)
        {
        }

        public virtual IDotAttributeCollectionWriter BeginAttributeList(bool useAttributeSeparator)
        {
            _writer.AttributeListStart(linger: true)
                   .Space(linger: true);

            return new DotAttributeListStringWriter(_writer, _options, _level + 1, useAttributeSeparator);
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

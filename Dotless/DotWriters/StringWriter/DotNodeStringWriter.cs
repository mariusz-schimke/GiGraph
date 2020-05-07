using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotNodeStringWriter : DotEntityStringWriter, IDotNodeWriter
    {
        public DotNodeStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
            : base(writer, options, level)
        {
        }

        public virtual void WriteNodeIdentifier(string id, bool quote)
        {
            _writer.Identifier(id, quote)
                   .Space(linger: true);
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

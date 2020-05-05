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
            _writer.AttributeListStart()
                   .LineBreak(linger: true)
                   .Indentation(_level + 1, linger: true);

            return new DotAttributeListStringWriter(_writer, _options, _level + 1);
        }

        public virtual void EndAttributeList()
        {
            _writer.ClearLingerBuffer();

            _writer.LineBreak()
                   .Indentation(_level)
                   .AttributeListEnd();
        }
    }
}

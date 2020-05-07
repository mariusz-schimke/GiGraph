using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotNodeStringWriter : DotEntityWithAttributeListStringWriter, IDotNodeWriter
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
    }
}

using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotNodeStringWriter : DotEntityWithAttributeListStringWriter, IDotNodeWriter
    {
        public DotNodeStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context)
            : base(writer, format, context)
        {
        }

        public virtual void WriteNodeIdentifier(string id, bool quote)
        {
            _writer.Identifier(id, quote)
                   .Space(linger: true);
        }
    }
}

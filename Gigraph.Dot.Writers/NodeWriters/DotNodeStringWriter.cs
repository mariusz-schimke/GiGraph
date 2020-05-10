using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public class DotNodeStringWriter : DotEntityWithAttributeListStringWriter, IDotNodeWriter
    {
        public DotNodeStringWriter(DotStringWriter writer, DotEntityWriterContext context)
            : base(writer, context)
        {
        }

        public virtual void WriteNodeIdentifier(string id, bool quote)
        {
            _writer.Identifier(id, quote)
                   .Space(linger: true);
        }
    }
}

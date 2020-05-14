using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public class DotNodeDefaultsWriter : DotEntityWithAttributeListWriter, IDotEntityDefaultsWriter
    {
        public DotNodeDefaultsWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteEntityKeyword()
        {
            _tokenWriter.Keyword("node")
                        .Space();
        }
    }
}

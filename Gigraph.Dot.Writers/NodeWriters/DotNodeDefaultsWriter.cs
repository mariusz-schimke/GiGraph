using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public class DotNodeDefaultsWriter : DotEntityWithAttributeListWriter, IDotNodeDefaultsWriter
    {
        public DotNodeDefaultsWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteNodeKeyword()
        {
            _tokenWriter.Keyword("node")
                        .Space();
        }
    }
}

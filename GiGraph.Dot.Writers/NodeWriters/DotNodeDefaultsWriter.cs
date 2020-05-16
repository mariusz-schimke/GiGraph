using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.NodeWriters
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

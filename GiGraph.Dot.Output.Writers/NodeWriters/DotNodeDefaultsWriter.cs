using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.NodeWriters
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
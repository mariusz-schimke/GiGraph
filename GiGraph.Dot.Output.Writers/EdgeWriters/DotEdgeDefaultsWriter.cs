using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.EdgeWriters
{
    public class DotEdgeDefaultsWriter : DotEntityWithAttributeListWriter, IDotEdgeDefaultsWriter
    {
        public DotEdgeDefaultsWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteEdgeKeyword()
        {
            _tokenWriter.Keyword("edge")
                        .Space();
        }
    }
}

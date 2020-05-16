using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.EdgeWriters
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

using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public class DotEdgeDefaultsWriter : DotEntityWithAttributeListWriter, IDotEntityDefaultsWriter
    {
        public DotEdgeDefaultsWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteEntityKeyword()
        {
            _tokenWriter.Keyword("edge")
                        .Space();
        }
    }
}

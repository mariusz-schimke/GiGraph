using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotEdgeStringWriter : DotEntityWithAttributeListStringWriter, IDotEdgeWriter
    {
        public DotEdgeStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
            : base(writer, options, level)
        {
        }

        public virtual void WriteEdge(bool directed, string leftNodeId, bool quoteLeftNodeId, string rightNodeId, bool quoteRightNodeId)
        {
            _writer.Identifier(leftNodeId, quoteLeftNodeId)
                   .Space()
                   .Edge(directed)
                   .Space()
                   .Identifier(rightNodeId, quoteRightNodeId)
                   .Space(linger: true);
        }
    }
}

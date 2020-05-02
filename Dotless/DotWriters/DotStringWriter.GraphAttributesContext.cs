using Dotless.DotWriters.Options;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class GraphAttributesContext : AttributeListContext
        {
            public GraphAttributesContext(GraphContext parentContext, DotFormattingOptions options, int level, bool preferExplicitDelimiter)
                : base(parentContext, options, level, preferExplicitDelimiter)
            {
            }

            public override void EndContext()
            {
            }
        }
    }
}

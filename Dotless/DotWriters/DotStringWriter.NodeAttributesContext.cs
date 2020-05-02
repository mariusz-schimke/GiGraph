using Dotless.DotWriters.Options;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class NodeAttributesContext : DotWriterContext
        {
            protected readonly bool _preferExplicitDelimiter;

            public NodeAttributesContext(NodeContext parentContext, DotFormattingOptions options, int level, bool preferExplicitDelimiter)
                : base(parentContext, options, level)
            {
                _preferExplicitDelimiter = preferExplicitDelimiter;
            }

            public override void EndContext()
            {
            }
        }
    }
}

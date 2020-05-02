using Dotless.DotWriters.Options;
using System;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class NodeContext : DotWriterContext
        {
            public NodeContext(GraphContext parentContext, DotFormattingOptions options, int level)
                : base(parentContext, options, level)
            {
            }

            public virtual NodeAttributesContext BeginAttributesContext(bool preferExplicitDelimiter)
            {
                throw new NotImplementedException();
            }

            public override void EndContext()
            {
            }
        }
    }
}

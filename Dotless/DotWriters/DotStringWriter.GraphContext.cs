using Dotless.DotWriters.Options;
using System;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class GraphContext : DotWriterContext
        {
            public GraphContext(DotWriterContext parentContext, DotFormattingOptions options, int level)
                : base(parentContext, options, level)
            {
            }

            public override void EndContext()
            {
            }

            public virtual GraphAttributesContext BeginAttributesContext(bool preferExplicitDelimiter)
            {
                throw new NotImplementedException();
            }

            public virtual NodeContext BeginNodeContext(string id, bool quoteId)
            {
                throw new NotImplementedException();
            }

            public virtual GraphContext BeginSubgraphContext(string id, bool quoteId)
            {
                throw new NotImplementedException();
            }
        }
    }
}

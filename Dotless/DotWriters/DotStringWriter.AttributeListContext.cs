using Dotless.DotWriters.Options;
using System;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public abstract class AttributeListContext : DotWriterContext
        {
            protected readonly bool _preferExplicitDelimiter;

            public AttributeListContext(DotWriterContext parentContext, DotFormattingOptions options, int level, bool preferExplicitDelimiter)
                : base(parentContext, options, level)
            {
                _preferExplicitDelimiter = preferExplicitDelimiter;
            }

            public virtual void WriteAttribute(string key, string value, bool quoteValue)
            {
                throw new NotImplementedException();
            }

            public virtual void WriteHtmlAttribute(string key, string value)
            {
                throw new NotImplementedException();
            }
        }
    }
}

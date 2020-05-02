using Dotless.DotWriters.Options;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public abstract class DotWriterContext : DotStringWriter
        {
            protected readonly DotStringWriter? _parentContext;

            public DotWriterContext(DotStringWriter? parentContext, DotFormattingOptions options, int level)
                : base(options, level)
            {
                _parentContext = parentContext;
            }

            public virtual void EndContext()
            {
            }
        }
    }
}

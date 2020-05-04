using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public abstract class DotWriterContext : DotStringWriter
        {
            public DotWriterContext(StreamWriter writer, DotFormattingOptions options, int level)
                : base(writer, options, level)
            {
            }
        }
    }
}

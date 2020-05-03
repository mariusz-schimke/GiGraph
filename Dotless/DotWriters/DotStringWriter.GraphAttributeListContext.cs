using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class GraphAttributeListContext : AttributeListContext
        {
            public GraphAttributeListContext(StreamWriter writer, DotFormattingOptions options, int level, bool preferExplicitAttributeDelimiter)
                : base(writer, options, level, preferExplicitAttributeDelimiter)
            {
            }

            public override void EndContext()
            {
                PushLineBreak();
            }

            protected override AttributeListContext WriteAttributeDelimiter()
            {
                if (_preferExplicitAttributeDelimiter)
                {
                    WriteStatementEnd();
                }

                PushLineBreak();
                return this;
            }
        }
    }
}

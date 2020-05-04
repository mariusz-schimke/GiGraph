using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters.StringWriter
{
    public partial class DotStringWriter
    {
        public class GraphAttributesContext : AttributesContext
        {
            public GraphAttributesContext(StreamWriter writer, DotFormattingOptions options, int level, bool preferExplicitAttributeDelimiter)
                : base(writer, options, level, preferExplicitAttributeDelimiter)
            {
            }

            protected override void WriteAttributeDelimiter()
            {
                if (_preferExplicitAttributesDelimiter)
                {
                    WriteStatementEnd();
                }

                PushLineBreak();
            }
        }
    }
}

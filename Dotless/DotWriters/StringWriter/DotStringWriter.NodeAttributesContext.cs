using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters.StringWriter
{
    public partial class DotStringWriter
    {
        public class NodeAttributesContext : AttributesContext
        {
            public NodeAttributesContext(StreamWriter writer, DotFormattingOptions options, int level, bool useAttributeSeparator)
                : base(writer, options, level, useAttributeSeparator)
            {
            }

            protected override void WriteAttributeDelimiter()
            {
                if (_preferExplicitAttributesDelimiter)
                {
                    WriteListItemDelimiter();
                }

                PushLineBreak();
            }
        }
    }
}

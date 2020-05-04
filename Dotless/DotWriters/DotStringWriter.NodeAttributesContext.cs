using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class NodeAttributesContext : AttributesContext
        {
            public NodeAttributesContext(StreamWriter writer, DotFormattingOptions options, int level, bool useAttributeSeparator)
                : base(writer, options, level, useAttributeSeparator)
            {
                WriteListStart();
            }

            public override void EndContext()
            {
                WriteListEnd();
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

using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class NodeAttributesContext : AttributesContext
        {
            public NodeAttributesContext(StreamWriter writer, DotFormattingOptions options, int level, bool preferExplicitAttributeDelimiter)
                : base(writer, options, level, preferExplicitAttributeDelimiter)
            {
                WriteListStart();
            }

            public override void EndContext()
            {
                WriteListEnd();
            }

            protected override AttributesContext WriteAttributeDelimiter()
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

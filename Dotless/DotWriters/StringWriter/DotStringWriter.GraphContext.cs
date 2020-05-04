using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters.StringWriter
{
    public partial class DotStringWriter
    {
        public class GraphContext : GraphBlockContext, IDotGraphWriter
        {
            public GraphContext(StreamWriter writer, DotFormattingOptions options, int level)
                : base(writer, options, level)
            {
            }

            public void WriteGraphDeclaration(string? id, bool directed, bool strict, bool quoteId)
            {
                if (strict)
                {
                    WriteKeyword("strict");
                }

                if (directed)
                {
                    WriteKeyword("digraph");
                }
                else
                {
                    WriteKeyword("graph");
                }

                if (id != null)
                {
                    WriteIdentifier(id, quoteId);
                }
            }

            public IDotGraphBodyWriter BeginGraphBody()
            {
                WriteBlockStart();
                PushLineBreak();

                return this;
            }

            public void EndGraphBody()
            {
                WriteBlockEnd();
            }
        }
    }
}

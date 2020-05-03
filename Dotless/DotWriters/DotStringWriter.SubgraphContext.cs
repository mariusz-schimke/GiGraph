using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class SubgraphContext : GraphBlockContext
        {
            public SubgraphContext(StreamWriter writer, DotFormattingOptions options, int level, string? name, bool quoteName)
                : base(writer, options, level)
            {
                WriteGraphDeclaration(name, quoteName);
                WriteBlockStart();
            }

            protected virtual void WriteGraphDeclaration(string? name, bool quoteName)
            {
                WriteKeyword("subgraph");

                if (name != null)
                {
                    WriteIdentifier(name, quoteName);
                }
            }
        }
    }
}

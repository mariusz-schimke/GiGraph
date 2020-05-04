using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public class GraphContext : GraphBlockContext, IDotGraphWriter
        {
            public GraphContext(StreamWriter writer, DotFormattingOptions options, int level, bool strict, bool directed, string? name, bool quoteName)
                : base(writer, options, level)
            {
                OpenGraphContext(strict, directed, name, quoteName);
                WriteBlockStart();
            }

            public virtual void OpenGraphContext(bool strict, bool directed, string? name, bool quoteName)
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

                if (name != null)
                {
                    WriteIdentifier(name, quoteName);
                }
            }
        }
    }
}

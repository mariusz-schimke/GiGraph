using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotSubgraphStringWriter : DotGraphBlockStringWriter, IDotSubgraphWriter
    {
        public DotSubgraphStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context)
            : base(writer, format, context)
        {
        }

        public virtual void WriteSubgraphDeclaration(string id, bool quote)
        {
            _writer.Keyword("subgraph")
                   .Space();

            if (id is { })
            {
                _writer.Identifier(id, quote)
                       .Space();
            }
        }
    }
}

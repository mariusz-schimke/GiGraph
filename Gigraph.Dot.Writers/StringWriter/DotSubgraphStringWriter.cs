using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.StringWriter
{
    public class DotSubgraphStringWriter : DotGraphBlockStringWriter, IDotSubgraphWriter
    {
        public DotSubgraphStringWriter(DotStringWriter writer, DotEntityWriterContext context)
            : base(writer, context)
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

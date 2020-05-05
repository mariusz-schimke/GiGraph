using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotSubgraphStringWriter : DotGraphBodyStringWriter, IDotSubgraphWriter
    {
        public DotSubgraphStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
            : base(writer, options, level)
        {
        }

        public virtual void WriteSubgraphDeclaration(string? id, bool quote)
        {
            if (id is { })
            {
                _writer.Identifier(id, quote)
                       .Space();
            }
        }

        public virtual IDotGraphBodyWriter BeginSubgraphBody()
        {
            return BeginBody();
        }

        public virtual void EndSubraphBody()
        {
            EndBody();
        }
    }
}

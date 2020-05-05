using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotGraphStringWriter : DotGraphBodyStringWriter, IDotGraphWriter
    {
        public DotGraphStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
            : base(writer, options, level)
        {
        }

        public virtual void WriteGraphDeclaration(string? id, bool directed, bool strict, bool quoteId)
        {
            if (strict)
            {
                _writer.Keyword("strict")
                       .Space();
            }

            if (directed)
            {
                _writer.Keyword("digraph")
                       .Space();
            }
            else
            {
                _writer.Keyword("graph")
                       .Space();
            }

            if (id != null)
            {
                _writer.Identifier(id, quoteId)
                       .Space();
            }
        }

        public virtual IDotGraphBodyWriter BeginGraphBody()
        {
            return BeginBody();
        }

        public virtual void EndGraphBody()
        {
            EndBody();
        }
    }
}

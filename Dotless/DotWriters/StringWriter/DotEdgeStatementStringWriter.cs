using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotEdgeStatementStringWriter : DotStatementStringWriter, IDotEdgeCollectionWriter
    {
        public DotEdgeStatementStringWriter(DotStringWriter writer, DotFormattingOptions options, int level, bool useStatementDelimiter)
            : base(writer, options, level, useStatementDelimiter)
        {
        }

        public virtual IDotEdgeWriter BeginEdge()
        {
            return new DotEdgeStringWriter(_writer, _options, _level);
        }

        public virtual void EndEdge()
        {
            EndStatement();
        }
    }
}

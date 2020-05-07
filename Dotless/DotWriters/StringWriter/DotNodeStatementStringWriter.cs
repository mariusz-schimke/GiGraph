using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotNodeStatementStringWriter : DotStatementStringWriter, IDotNodeCollectionWriter
    {
        public DotNodeStatementStringWriter(DotStringWriter writer, DotFormattingOptions options, int level, bool useStatementDelimiter)
            : base(writer, options, level, useStatementDelimiter)
        {
        }

        public virtual IDotNodeWriter BeginNode()
        {
            return new DotNodeStringWriter(_writer, _options, _level);
        }

        public void EndNode()
        {
            EndStatement();
        }
    }
}

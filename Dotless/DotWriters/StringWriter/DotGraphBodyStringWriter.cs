using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotGraphBodyStringWriter : DotEntityStringWriter, IDotGraphBodyWriter
    {
        public DotGraphBodyStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
            : base(writer, options, level)
        {
        }

        public virtual IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter)
        {
            return new DotAttributeStatementStringWriter(_writer, _options, _level, useStatementDelimiter);
        }

        public virtual IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter)
        {
            return new DotNodeStatementStringWriter(_writer, _options, _level, useStatementDelimiter);
        }

        public virtual void EndAttributesSection(int attributeCount)
        {
            if (attributeCount > 0)
            {
                _writer.ClearLingerBuffer()
                       .LineBreak(linger: true)
                       .Indentation(_level, linger: true);
            }
        }

        public virtual void EndNodesSection(int nodeCount)
        {
            if (nodeCount > 0)
            {
                _writer.ClearLingerBuffer()
                       .LineBreak(linger: true)
                       .Indentation(_level, linger: true);
            }
        }
    }
}

using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotGraphBodyStringWriter : DotEntityStringWriter, IDotGraphBodyWriter
    {
        public DotGraphBodyStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
            : base(writer, options, level)
        {
        }

        public virtual IDotGraphBodyWriter BeginBody()
        {
            _writer.SectionStart()
                   .LineBreak()
                   .Indentation(_level + 1, linger: true);

            return new DotGraphBodyStringWriter(_writer, _options, _level + 1);
        }

        public virtual void EndBody()
        {
            _writer.ClearLingerBuffer();
            _writer.Indentation(_level);

            _writer.SectionEnd();
        }

        public virtual IDotAttributeCollectionWriter BeginAttributesSection(bool useStatementDelimiter)
        {
            return new DotAttributeStatementStringWriter(_writer, _options, _level, useStatementDelimiter);
        }

        public virtual IDotNodeCollectionWriter BeginNodesSection(bool useStatementDelimiter)
        {
            return new DotNodeStatementStringWriter(_writer, _options, _level, useStatementDelimiter);
        }

        public virtual void EndAttributesSection()
        {
            _writer.ClearLingerBuffer();
            _writer.Indentation(_level, linger: true);
        }

        public virtual void EndNodesSection()
        {
            _writer.ClearLingerBuffer();
            _writer.Indentation(_level, linger: true);
        }
    }
}

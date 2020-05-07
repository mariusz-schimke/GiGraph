using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public abstract class DotGraphBlockStringWriter : DotEntityStringWriter
    {
        public DotGraphBlockStringWriter(DotStringWriter writer, DotFormattingOptions options, int level)
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
    }
}

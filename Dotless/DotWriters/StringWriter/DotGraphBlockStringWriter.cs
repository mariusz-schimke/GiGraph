using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public abstract class DotGraphBlockStringWriter : DotEntityStringWriter
    {
        public DotGraphBlockStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context)
            : base(writer, format, context)
        {
        }

        public virtual IDotGraphBodyWriter BeginBody()
        {
            _writer.SectionStart()
                   .LineBreak()
                   .Indentation(_context.Level + 1, linger: true);

            return new DotGraphBodyStringWriter(_writer, _format, _context.NextLevel());
        }

        public virtual void EndBody()
        {
            _writer.ClearLingerBuffer();
            _writer.Indentation(_context.Level);

            _writer.SectionEnd();
        }
    }
}

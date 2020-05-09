using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.StringWriter
{
    public abstract class DotGraphBlockStringWriter : DotEntityStringWriter
    {
        public DotGraphBlockStringWriter(DotStringWriter writer, DotEntityWriterContext context)
            : base(writer, context)
        {
        }

        public virtual IDotGraphBodyWriter BeginBody()
        {
            _writer.SectionStart()
                   .LineBreak()
                   .Indentation(_context.Level + 1, linger: true);

            return new DotGraphBodyStringWriter(_writer, _context.NextLevel());
        }

        public virtual void EndBody()
        {
            _writer.ClearLingerBuffer();
            _writer.Indentation(_context.Level);

            _writer.SectionEnd();
        }
    }
}

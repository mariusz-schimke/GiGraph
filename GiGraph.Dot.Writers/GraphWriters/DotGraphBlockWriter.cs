using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.GraphWriters
{
    public abstract class DotGraphBlockWriter : DotEntityWriter
    {
        public DotGraphBlockWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual IDotGraphBodyWriter BeginBody()
        {
            _tokenWriter.SectionStart()
                        .LineBreak()
                        .Indentation(_context.Level + 1, linger: true);

            return new DotGraphBodyWriter(_tokenWriter, _context.NextLevel());
        }

        public virtual void EndBody()
        {
            _tokenWriter.ClearLingerBuffer();
            _tokenWriter.Indentation(_context.Level);

            _tokenWriter.SectionEnd();
        }
    }
}

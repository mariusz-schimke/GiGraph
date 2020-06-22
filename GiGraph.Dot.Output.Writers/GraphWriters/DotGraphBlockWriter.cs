using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.GraphWriters
{
    public abstract class DotGraphBlockWriter : DotEntityWriter
    {
        protected DotGraphBlockWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual IDotGraphBodyWriter BeginBody()
        {
            var tokenWriter = _tokenWriter.NextIndentationLevel();
            tokenWriter.SectionStart()
                       .LineBreak()
                       .Indentation(linger: true);

            return new DotGraphBodyWriter(tokenWriter, _context);
        }

        public virtual void EndBody()
        {
            _tokenWriter.ClearLingerBuffer();
            _tokenWriter.Indentation();

            _tokenWriter.SectionEnd();
        }
    }
}
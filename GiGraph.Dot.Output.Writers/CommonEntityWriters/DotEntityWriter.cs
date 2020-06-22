using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public abstract class DotEntityWriter : IDotEntityWriter
    {
        protected readonly DotTokenWriter _tokenWriter;
        protected readonly DotEntityWriterContext _context;
        protected readonly bool _enforceBlockComment;

        protected DotEntityWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool enforceBlockComment)
        {
            _tokenWriter = tokenWriter;
            _context = context;
            _enforceBlockComment = enforceBlockComment;
        }

        public virtual IDotCommentWriter BeginComment(bool preferBlockComment)
        {
            return new DotCommentWriter(_tokenWriter, preferBlockComment || _enforceBlockComment);
        }

        public virtual void EndComment()
        {
            _tokenWriter.LineBreak()
                        .Indentation(linger: true);
        }

        protected virtual void EmptyLine()
        {
            _tokenWriter.LineBreak()
                        .LineBreak(linger: true)
                        .Indentation(linger: true);
        }
    }
}
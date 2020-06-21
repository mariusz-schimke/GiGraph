using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public class DotCommentWriter : IDotCommentWriter
    {
        protected readonly DotTokenWriter _tokenWriter;
        protected readonly DotEntityWriterContext _context;
        protected readonly bool _preferBlockComment;

        public DotCommentWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool preferBlockComment)
        {
            _tokenWriter = tokenWriter;
            _context = context;
            _preferBlockComment = preferBlockComment;
        }

        public virtual void Write(string comment)
        {
            if (_preferBlockComment)
            {
                _tokenWriter.BlockComment(comment, _context.Level);
            }
            else
            {
                _tokenWriter.Comment(comment, _context.Level);
            }
        }
    }
}
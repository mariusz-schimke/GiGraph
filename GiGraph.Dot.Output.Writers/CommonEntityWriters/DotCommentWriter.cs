namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public class DotCommentWriter : IDotCommentWriter
    {
        protected readonly bool _preferBlockComment;
        protected readonly DotTokenWriter _tokenWriter;

        public DotCommentWriter(DotTokenWriter tokenWriter, bool preferBlockComment)
        {
            _tokenWriter = tokenWriter;
            _preferBlockComment = preferBlockComment;
        }

        public virtual void Write(string comment)
        {
            if (_preferBlockComment)
            {
                _tokenWriter.BlockComment(comment);
            }
            else
            {
                _tokenWriter.Comment(comment);
            }
        }
    }
}
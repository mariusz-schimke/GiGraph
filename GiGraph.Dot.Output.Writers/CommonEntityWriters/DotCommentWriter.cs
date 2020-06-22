namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public class DotCommentWriter : IDotCommentWriter
    {
        protected readonly DotTokenWriter _tokenWriter;
        protected readonly int _level;
        protected readonly bool _preferBlockComment;

        public DotCommentWriter(DotTokenWriter tokenWriter, int level, bool preferBlockComment)
        {
            _tokenWriter = tokenWriter;
            _level = level;
            _preferBlockComment = preferBlockComment;
        }

        public virtual void Write(string comment)
        {
            if (_preferBlockComment)
            {
                _tokenWriter.BlockComment(comment, _level);
            }
            else
            {
                _tokenWriter.Comment(comment, _level);
            }
        }
    }
}
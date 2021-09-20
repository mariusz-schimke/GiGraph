using GiGraph.Dot.Output.Writers.Comments;
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers
{
    public abstract class DotEntityWriter : IDotEntityWriter
    {
        protected readonly DotEntityWriterConfiguration _configuration;
        protected readonly bool _enforceBlockComment;
        protected readonly DotTokenWriter _tokenWriter;

        protected DotEntityWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool enforceBlockComment)
        {
            _tokenWriter = tokenWriter;
            _configuration = configuration;
            _enforceBlockComment = enforceBlockComment;
        }

        public virtual IDotCommentWriter BeginComment(bool preferBlockComment)
        {
            return new DotCommentWriter(_tokenWriter, preferBlockComment || _enforceBlockComment);
        }

        public virtual void EndComment()
        {
            NewLine();
        }

        protected virtual DotTokenWriter EmptyLine(bool linger = true, bool enforceLineBreak = true)
        {
            return _tokenWriter.EmptyLine(linger, enforceLineBreak);
        }

        protected virtual DotTokenWriter NewLine(bool linger = true, bool enforceLineBreak = true)
        {
            return _tokenWriter.NewLine(linger, enforceLineBreak);
        }
    }
}
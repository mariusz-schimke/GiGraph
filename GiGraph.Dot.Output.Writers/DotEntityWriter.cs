using GiGraph.Dot.Output.Writers.Comments;

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
            LineBreak();
        }

        protected virtual void EmptyLine()
        {
            _tokenWriter.LineBreak()
               .LineBreak(linger: true)
               .Indentation(linger: true);
        }
        
        protected virtual void LineBreak()
        {
            _tokenWriter.LineBreak()
               .Indentation(linger: true);
        }
    }
}
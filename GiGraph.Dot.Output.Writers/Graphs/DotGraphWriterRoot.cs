using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Comments;

namespace GiGraph.Dot.Output.Writers.Graphs
{
    public class DotGraphWriterRoot : IDotGraphWriterRoot
    {
        protected readonly DotFormattingOptions _formattingOptions;
        protected readonly DotTokenWriter _tokenWriter;

        public DotGraphWriterRoot(DotTokenWriter tokenWriter, DotFormattingOptions formattingOptions)
        {
            _tokenWriter = tokenWriter;
            _formattingOptions = formattingOptions;
        }

        public virtual IDotGraphWriter BeginGraph(bool directed)
        {
            _tokenWriter.Indentation(linger: true);
            return new DotGraphWriter(_tokenWriter, new DotEntityWriterConfiguration(directed, _formattingOptions));
        }

        public virtual void EndGraph()
        {
        }

        public virtual IDotCommentWriter BeginComment(bool preferBlockComment)
        {
            return new DotCommentWriter(_tokenWriter, preferBlockComment);
        }

        public virtual void EndComment()
        {
            _tokenWriter.LineBreak()
               .Indentation(linger: true);
        }
    }
}
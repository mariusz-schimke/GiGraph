using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.GraphWriters
{
    public class DotGraphWriterRoot : IDotGraphWriterRoot
    {
        protected readonly DotTokenWriter _tokenWriter;

        public DotGraphWriterRoot(DotTokenWriter tokenWriter)
        {
            _tokenWriter = tokenWriter;
        }

        public virtual IDotGraphWriter BeginGraph(bool directed)
        {
            _tokenWriter.Indentation(linger: true);
            return new DotGraphWriter(_tokenWriter, new DotEntityWriterContext(directed));
        }

        public void EndGraph()
        {
        }

        public IDotCommentWriter BeginComment(bool preferBlockComment)
        {
            return new DotCommentWriter(_tokenWriter, preferBlockComment);
        }

        public void EndComment()
        {
            _tokenWriter.LineBreak()
                        .Indentation(linger: true);
        }
    }
}
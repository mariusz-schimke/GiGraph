using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.GraphWriters
{
    public class DotGraphWriterRoot : IDotGraphWriterRoot
    {
        protected readonly DotTokenWriter _tokenWriter;
        protected readonly int _level;

        public DotGraphWriterRoot(DotTokenWriter tokenWriter, int level = 0)
        {
            _tokenWriter = tokenWriter;
            _level = level;
        }

        public virtual IDotGraphWriter BeginGraph(bool directed)
        {
            _tokenWriter.Indentation(_level, linger: true);
            return new DotGraphWriter(_tokenWriter, new DotEntityWriterContext(_level, directed));
        }

        public void EndGraph()
        {
        }

        IDotCommentWriter IDotEntityWriter.BeginComment(bool preferBlockComment)
        {
            return new DotNullCommentWriter();
        }

        void IDotEntityWriter.EndComment()
        {
        }
    }
}
namespace Gigraph.Dot.Writers.Contexts
{
    public class DotEntityWriterContext
    {
        public virtual int Level { get; }
        public virtual bool IsDirectedGraph { get; }

        public DotEntityWriterContext(int level, bool isDirectedGraph)
        {
            Level = level;
            IsDirectedGraph = isDirectedGraph;
        }

        public virtual DotEntityWriterContext NextLevel()
        {
            return new DotEntityWriterContext(Level + 1, IsDirectedGraph);
        }
    }
}

namespace Dotless.DotWriters.Contexts
{
    public class DotEntityWriterContext
    {
        public int Level { get; }
        public bool IsDirectedGraph { get; }

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

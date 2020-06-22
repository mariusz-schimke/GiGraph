namespace GiGraph.Dot.Output.Writers.Contexts
{
    public class DotEntityWriterContext
    {
        public virtual bool IsDirectedGraph { get; }

        public DotEntityWriterContext(bool isDirectedGraph)
        {
            IsDirectedGraph = isDirectedGraph;
        }
    }
}
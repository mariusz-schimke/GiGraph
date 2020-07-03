namespace GiGraph.Dot.Output.Writers.Contexts
{
    public class DotEntityWriterContext
    {
        public DotEntityWriterContext(bool isDirectedGraph)
        {
            IsDirectedGraph = isDirectedGraph;
        }

        public virtual bool IsDirectedGraph { get; }
    }
}
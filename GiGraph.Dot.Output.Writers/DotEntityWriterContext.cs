namespace GiGraph.Dot.Output.Writers
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
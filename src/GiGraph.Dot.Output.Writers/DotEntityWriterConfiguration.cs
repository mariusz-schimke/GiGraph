using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Writers
{
    public class DotEntityWriterConfiguration
    {
        public DotEntityWriterConfiguration(bool isDirectedGraph, DotFormattingOptions formatting)
        {
            IsDirectedGraph = isDirectedGraph;
            Formatting = formatting;
        }

        public virtual bool IsDirectedGraph { get; }
        public virtual DotFormattingOptions Formatting { get; }
    }
}
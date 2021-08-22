using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Writers
{
    public record DotEntityWriterConfiguration(bool IsDirectedGraph, DotFormattingOptions Formatting);
}
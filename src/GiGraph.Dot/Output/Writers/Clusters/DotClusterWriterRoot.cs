using GiGraph.Dot.Output.Writers.Subgraphs;
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Clusters;

public class DotClusterWriterRoot : DotSubgraphWriterRoot
{
    public DotClusterWriterRoot(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
        : base(tokenWriter, configuration)
    {
    }

    public override IDotSubgraphWriter BeginSubgraph(bool preferExplicitDeclaration)
    {
        return BeginSubgraph(preferExplicitDeclaration, _configuration.Formatting.Clusters.SingleLine);
    }

    public override void EndSubgraph()
    {
        EndSubgraph(_configuration.Formatting.Clusters.SingleLine);
    }
}
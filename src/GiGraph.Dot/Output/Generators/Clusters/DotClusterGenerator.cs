using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.Subgraphs;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Graphs;
using GiGraph.Dot.Output.Writers.Subgraphs;
using GiGraph.Dot.Types.Clusters;

namespace GiGraph.Dot.Output.Generators.Clusters;

public class DotClusterGenerator : DotCommonSubgraphGenerator<DotCluster>
{
    public DotClusterGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteDeclaration(string id, IDotSubgraphWriter writer)
    {
        // keep this value coherent with the format the logical endpoint attribute uses to generate cluster identifier,
        // and use the same identifier escaping pipeline
        id = EncodeIdentifier(new DotClusterId(id));
        writer.WriteSubgraphDeclaration(id, IdentifierRequiresQuoting(id));
    }

    protected override void WriteBody(DotCluster graphBody, IDotCommonGraphWriter writer)
    {
        bool? initialIsCluster = null;
        var overrideIsCluster = _options.Clusters.PreferClusterAttribute;

        // this approach will not be okay in multi-thread environments
        if (overrideIsCluster)
        {
            initialIsCluster = graphBody.Attributes.GetValue(a => a.IsCluster);
            graphBody.Attributes.SetValue(a => a.IsCluster, true);
        }

        base.WriteBody(graphBody, writer);

        if (overrideIsCluster)
        {
            graphBody.Attributes.SetValue(a => a.IsCluster, initialIsCluster);
        }
    }
}
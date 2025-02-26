﻿using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.Subgraphs;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Subgraphs;
using GiGraph.Dot.Types.Clusters;

namespace GiGraph.Dot.Output.Generators.Clusters;

public class DotClusterGenerator : DotCommonSubgraphGenerator<DotCluster>
{
    public DotClusterGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override void WriteDeclaration(string? id, IDotSubgraphWriter writer)
    {
        // keep this value coherent with the format the logical endpoint attribute uses to generate cluster identifier,
        // and use the same identifier escaping pipeline
        id = EncodeIdentifier((DotClusterId?) id);
        writer.WriteSubgraphDeclaration(id, IdentifierRequiresQuoting(id));
    }
}
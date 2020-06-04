﻿using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.SubgraphWriters;

namespace GiGraph.Dot.Generators.SubgraphGenerators
{
    public class DotClusterGenerator : DotCommonSubgraphGenerator<DotCluster>
    {
        protected DotClusterGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotClusterGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteDeclaration(string id, IDotSubgraphWriter writer)
        {
            id = EscapeIdentifier(FormatIdentifier(id));
            writer.WriteSubgraphDeclaration(id, IdentifierRequiresQuoting(id));
        }

        protected virtual string FormatIdentifier(string id)
        {
            const string cluster = "cluster";

            return id is { }
                ? $"{cluster}{_options.Clusters.ClusterIdSeparator}{id}"
                : cluster;
        }
    }
}
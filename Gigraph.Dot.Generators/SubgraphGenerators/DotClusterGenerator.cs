using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Generators.SubgraphGenerators
{
    public class DotClusterGenerator : DotCommonSubgraphGenerator<DotCluster>
    {
        public DotClusterGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteDeclaration(DotCluster cluster, IDotSubgraphWriter writer)
        {
            var id = FormatIdentifier(cluster.Id);
            writer.WriteSubgraphDeclaration(id, IdentifierRequiresQuoting(id));
        }

        protected virtual string FormatIdentifier(string id)
        {
            var cluster = "cluster";

            if (id is { })
            {
                id = EscapeSubgraphIdentifier(id);
            }

            if (!string.IsNullOrEmpty(id))
            {
                return $"{cluster} {id}";
            }

            return cluster;
        }
    }
}

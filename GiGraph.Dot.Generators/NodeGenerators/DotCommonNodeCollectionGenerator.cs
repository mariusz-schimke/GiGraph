using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.NodeWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.NodeGenerators
{
    public class DotCommonNodeCollectionGenerator : DotEntityGenerator<DotNodeCollection, IDotNodeStatementWriter>
    {
        protected DotCommonNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotNodeCollection nodes, IDotNodeStatementWriter writer)
        {
            var orderedNodes = nodes
                .Cast<IDotEntityWithIds>()
                .OrderBy(n => string.Join(" ", n.Ids))
                .ToArray();

            foreach (var node in orderedNodes)
            {
                var nodeWriter = writer.BeginNode();
                _entityGenerators.GetForEntity<IDotNodeWriter>(node).Generate(node, nodeWriter);
                writer.EndNode();
            }
        }
    }
}

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
    public class DotCommonNodeCollectionGenerator : DotEntityGenerator<DotCommonNodeCollection, IDotNodeStatementWriter>
    {
        protected DotCommonNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonNodeCollection nodes, IDotNodeStatementWriter writer)
        {
            var orderedNodes = _options.OrderElements
                ? nodes.Cast<IDotEntityWithNodeIds>()
                       .OrderBy(node => string.Join(" ", node.NodeIds))
                       .Cast<DotCommonNode>()
                : nodes;

            foreach (var node in orderedNodes)
            {
                WriteNode(node, writer);
            }
        }

        protected virtual void WriteNode(DotCommonNode node, IDotNodeStatementWriter writer)
        {
            var nodeWriter = writer.BeginNode();
            _entityGenerators.GetForEntity<IDotNodeWriter>(node).Generate(node, nodeWriter);
            writer.EndNode();
        }
    }
}

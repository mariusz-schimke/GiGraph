using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.NodeWriters;
using System.Linq;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Generators.NodeGenerators
{
    public class DotCommonNodeCollectionGenerator : DotEntityGenerator<DotCommonNodeCollection, IDotNodeStatementWriter>
    {
        protected DotCommonNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, IDotTextEscaper identifierEscaper)
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
                ? nodes.Cast<IDotOrderableEntity>()
                       .OrderBy(node => node.OrderingKey)
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

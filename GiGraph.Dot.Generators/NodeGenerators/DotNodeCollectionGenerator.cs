using GiGraph.Dot.Core;
using GiGraph.Dot.Core.TextEscaping;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.NodeWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.NodeGenerators
{
    public class DotNodeCollectionGenerator : DotEntityGenerator<DotNodeCollection, IDotNodeStatementWriter>
    {
        protected DotNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotNodeCollection nodes, IDotNodeStatementWriter writer)
        {
            var orderedNodes = nodes.OrderBy(n => n.Id).ToList();

            foreach (var node in orderedNodes)
            {
                var nodeWriter = writer.BeginNode();
                _entityGenerators.GetForEntity<IDotNodeWriter>(node).Generate(node, nodeWriter);
                writer.EndNode();
            }
        }
    }
}

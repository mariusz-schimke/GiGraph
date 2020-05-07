using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;
using Dotless.Nodes;
using System.Linq;

namespace Dotless.EntityGenerators.NodeGenerators
{
    public class DotNodeCollectionGenerator : DotEntityGenerator<DotNodeCollection, IDotNodeCollectionWriter>
    {
        public DotNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotNodeCollection nodes, IDotNodeCollectionWriter writer)
        {
            var orderedNodes = nodes.OrderBy(n => n.Id).ToList();

            foreach (var node in orderedNodes)
            {
                var nodeWriter = writer.BeginNode();
                _entityGenerators.GetForEntity<IDotNodeWriter>(node).Write(node, nodeWriter);
                writer.EndNode();
            }
        }
    }
}

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

            for (int i = 0; i < orderedNodes.Count; i++)
            {
                var nodeWriter = writer.BeginNode();
                _entityGenerators.GetForEntity<IDotNodeWriter>(orderedNodes[i]).Write(orderedNodes[i], nodeWriter);
                writer.EndNode();
            }
        }
    }
}

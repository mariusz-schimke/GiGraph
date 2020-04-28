using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using Dotless.GraphElements;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.NodeGenerators
{
    public class NodeGenerator : IEntityGenerator<GraphNode>
    {
        protected readonly EntityGeneratorCollection _entityGenerators;

        public NodeGenerator(EntityGeneratorCollection entityGenerators)
        {
            _entityGenerators = entityGenerators;
        }

        public ICollection<IToken> Generate(GraphNode node)
        {
            var result = new List<IToken>();

            result.QuotedIdentifier(new QuotationMarkEscaper().Escape(node.Id)!);

            var tokens = _entityGenerators.GetForTypeOrForAnyBaseType(node.Attributes)
                .Generate(node.Attributes);
            result.AddRange(tokens);

            return result;
        }

        ICollection<IToken> IEntityGenerator.Generate(IEntity entity)
        {
            return Generate((GraphNode)entity);
        }
    }
}

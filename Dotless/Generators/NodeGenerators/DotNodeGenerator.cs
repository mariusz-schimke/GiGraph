using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using Dotless.GraphElements;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.NodeGenerators
{
    public class DotNodeGenerator : IEntityGenerator<DotGraphNode>
    {
        protected readonly DotEntityGeneratorCollection _entityGenerators;

        public DotNodeGenerator(DotEntityGeneratorCollection entityGenerators)
        {
            _entityGenerators = entityGenerators;
        }

        public ICollection<IDotToken> Generate(DotGraphNode node)
        {
            var result = new List<IDotToken>();

            result.QuotedIdentifier(new DotQuotationMarkEscaper().Escape(node.Id)!);

            var tokens = _entityGenerators.GetForTypeOrForAnyBaseType(node.Attributes)
                .Generate(node.Attributes);
            result.AddRange(tokens);

            return result;
        }

        ICollection<IDotToken> IDotEntityGenerator.Generate(IDotEntity entity)
        {
            return Generate((DotGraphNode)entity);
        }
    }
}

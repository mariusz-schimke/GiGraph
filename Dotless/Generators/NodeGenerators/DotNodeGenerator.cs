using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using Dotless.GraphElements;
using Dotless.TextEscaping;
using System.Collections.Generic;

namespace Dotless.Generators.NodeGenerators
{
    public class DotNodeGenerator : DotEntityGenerator<DotGraphNode>
    {
        public DotNodeGenerator(DotSyntaxRules syntaxRules, DotEntityGeneratorCollection entityGenerators)
            : base(syntaxRules, entityGenerators)
        {
        }

        public override ICollection<IDotToken> Generate(DotGraphNode node, DotEntityGeneratorOptions options)
        {
            var result = new List<IDotToken>();

            result.QuotedIdentifier(new DotQuotationMarkEscaper().Escape(node.Id)!);

            var tokens = _entityGenerators.GetForTypeOrForAnyBaseType(node.Attributes)
                .Generate(node.Attributes, options);
            result.AddRange(tokens);

            return result;
        }
    }
}

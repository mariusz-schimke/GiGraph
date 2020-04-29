using Dotless.Core;
using Dotless.DotBuilders;
using Dotless.DotBuilders.Tokens;
using Dotless.Generators.AttributeGenerators;
using Dotless.Generators.NodeGenerators;
using Dotless.GraphElements;
using Dotless.Graphs;
using Dotless.TextEscaping;
using System.Collections.Generic;
using System.Linq;

namespace Dotless.Generators
{
    public class DotGraphGenerator : DotEntityGenerator<DotGraph>
    {
        public DotGraphGenerator(DotSyntaxRules syntaxRules, DotEntityGeneratorCollection entityGenerators)
            : base(syntaxRules, entityGenerators)
        {
        }

        public override ICollection<IDotToken> Generate(DotGraph graph, DotEntityGeneratorOptions options)
        {
            var result = new List<IDotToken>();

            GraphSpecification(result, graph, options);
            result.GraphBlockStart();

            GraphAttributes(result, graph.Attributes, options);
            GraphNodes(result, graph.Nodes, options);

            result.GraphBlockEnd();

            return result;
        }

        protected virtual void GraphSpecification(List<IDotToken> result, DotGraph graph, DotEntityGeneratorOptions options)
        {
            if (graph.IsStrict)
            {
                result.Keyword("strict");
            }

            result.Keyword(graph.IsDirected ? "digraph" : "graph");

            if (graph.Name is { })
            {
                result.QuotedIdentifier(new DotQuotationMarkEscaper().Escape(graph.Name)!);
            }
        }

        protected virtual void GraphAttributes(List<IDotToken> result, DotAttributeCollection attributes, DotEntityGeneratorOptions options)
        {
            var attributeListGenerator = _entityGenerators.GetForTypeOrForAnyBaseType(attributes);
            var tokens = attributeListGenerator.Generate(attributes, options);
            result.AddRange(tokens);
        }

        protected virtual void GraphNodes(List<IDotToken> result, List<DotGraphNode> nodes, DotEntityGeneratorOptions options)
        {
            if (!nodes.Any())
            {
                return;
            }

            foreach (var node in nodes)
            {
                var tokens = _entityGenerators.GetForTypeOrForAnyBaseType(node).Generate(node, options);

                result.AddRange(tokens);
                result.StatementSeparator();
            }
        }

        public static DotGraphGenerator CreateDefault()
        {
            var syntaxRules = new DotSyntaxRules();
            var generators = new DotEntityGeneratorCollection();

            generators.Add(new DotGraphGenerator(syntaxRules, generators));
            generators.Add(new DotAttributeCollectionGenerator(syntaxRules, generators));

            generators.Add(new DotTextLabelAttributeGenerator(syntaxRules, generators));
            generators.Add(new DotHtmlLabelAttributeGenerator(syntaxRules, generators));

            generators.Add(new DotNodeGenerator(syntaxRules, generators));

            return new DotGraphGenerator(syntaxRules, generators);
        }
    }
}

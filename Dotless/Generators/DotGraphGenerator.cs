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
    public class DotGraphGenerator : IEntityGenerator<DotGraph>
    {
        protected readonly DotEntityGeneratorCollection _entityGenerators;

        public DotGraphGenerator(DotEntityGeneratorCollection entityGenerators)
        {
            _entityGenerators = entityGenerators;
        }

        public virtual ICollection<IDotToken> Generate(DotGraph graph)
        {
            var result = new List<IDotToken>();

            GraphSpecification(result, graph);
            result.GraphBlockStart();

            GraphAttributes(result, graph.Attributes);
            GraphNodes(result, graph.Nodes);

            result.GraphBlockEnd();

            return result;
        }

        protected virtual void GraphSpecification(List<IDotToken> result, DotGraph graph)
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

        protected virtual void GraphAttributes(List<IDotToken> result, DotAttributeCollection attributes)
        {
            var attributeListGenerator = _entityGenerators.GetForTypeOrForAnyBaseType(attributes);
            var tokens = attributeListGenerator.Generate(attributes);
            result.AddRange(tokens);
        }

        protected virtual void GraphNodes(List<IDotToken> result, List<DotGraphNode> nodes)
        {
            if (!nodes.Any())
            {
                return;
            }

            foreach (var node in nodes)
            {
                var tokens = _entityGenerators.GetForTypeOrForAnyBaseType(node).Generate(node);

                result.AddRange(tokens);
                result.StatementSeparator();
            }
        }

        public static DotGraphGenerator CreateDefault()
        {
            var generators = new DotEntityGeneratorCollection();

            generators.Add(new DotGraphGenerator(generators));
            generators.Add(new DotAttributeCollectionGenerator(generators));

            generators.Add(new DotTextLabelAttributeGenerator());
            generators.Add(new DotHtmlLabelAttributeGenerator());

            generators.Add(new DotNodeGenerator(generators));

            return new DotGraphGenerator(generators);
        }

        ICollection<IDotToken> IDotEntityGenerator.Generate(IDotEntity graph)
        {
            return Generate((DotGraph)graph);
        }
    }
}

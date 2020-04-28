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
    public class GraphGenerator : IEntityGenerator<Graph>
    {
        protected readonly EntityGeneratorCollection _entityGenerators;

        public GraphGenerator(EntityGeneratorCollection entityGenerators)
        {
            _entityGenerators = entityGenerators;
        }

        public virtual ICollection<IToken> Generate(Graph graph)
        {
            var result = new List<IToken>();

            GraphSpecification(result, graph);
            result.GraphBlockStart();

            GraphAttributes(result, graph.Attributes);
            GraphNodes(result, graph.Nodes);

            result.GraphBlockEnd();

            return result;
        }

        protected virtual void GraphSpecification(List<IToken> result, Graph graph)
        {
            if (graph.IsStrict)
            {
                result.Keyword("strict");
            }

            result.Keyword(graph.IsDirected ? "digraph" : "graph");

            if (graph.Name is { })
            {
                result.QuotedIdentifier(new QuotationMarkEscaper().Escape(graph.Name)!);
            }
        }

        protected virtual void GraphAttributes(List<IToken> result, AttributeCollection attributes)
        {
            var attributeListGenerator = _entityGenerators.GetForTypeOrForAnyBaseType(attributes);
            var tokens = attributeListGenerator.Generate(attributes);
            result.AddRange(tokens);
        }

        protected virtual void GraphNodes(List<IToken> result, List<GraphNode> nodes)
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

        public static GraphGenerator CreateDefault()
        {
            var generators = new EntityGeneratorCollection();

            generators.Add(new GraphGenerator(generators));
            generators.Add(new AttributeCollectionGenerator(generators));

            generators.Add(new TextLabelAttributeGenerator());
            generators.Add(new HtmlLabelAttributeGenerator());

            generators.Add(new NodeGenerator(generators));

            return new GraphGenerator(generators);
        }

        ICollection<IToken> IEntityGenerator.Generate(IEntity graph)
        {
            return Generate((Graph)graph);
        }
    }
}

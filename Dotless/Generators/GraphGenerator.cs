using Dotless.Core;
using Dotless.Generators.AttributeGenerators;
using Dotless.Generators.Extensions;
using Dotless.Generators.NodeGenerators;
using Dotless.GraphElements;
using Dotless.Graphs;
using Dotless.TextEscaping;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless.Generators
{
    public class GraphGenerator : IEntityGenerator<Graph>
    {
        protected readonly EntityGeneratorCollection _entityGenerators;

        public GraphGenerator(EntityGeneratorCollection entityGenerators)
        {
            _entityGenerators = entityGenerators;
        }

        public virtual string Generate(Graph graph)
        {
            return Generate(graph, new GeneratorOptions());
        }

        public virtual string Generate(Graph graph, GeneratorOptions options)
        {
            var result = new StringBuilder();

            GraphSpecification(result, graph, options);
            GraphBlockStart(result, options);

            GraphAttributes(result, graph.Attributes, options);
            GraphNodes(result, graph.Nodes, options);

            GraphBlockEnd(result, options);

            return result.ToString();
        }

        protected virtual void GraphSpecification(StringBuilder result, Graph graph, GeneratorOptions options)
        {
            if (graph.IsStrict)
            {
                result.Append("strict");
                result.Append(options.TSoS());
            }

            result.Append(graph.IsDirected ? "digraph" : "graph");

            if (graph.Name is { })
            {
                result.Append(options.TS());
                result.Append($"\"{new QuotationMarkEscaper().Escape(graph.Name)}\"");
            }

            result.Append(options.TS());
        }

        protected virtual void GraphAttributes(StringBuilder result, AttributeCollection attributes, GeneratorOptions options)
        {
            var generator = _entityGenerators.GetForTypeOrForAnyBaseType(attributes);
            var generated = generator.Generate(attributes, options);

            result.Append(generated);
            result.Append(options.LBoS());
        }

        protected virtual void GraphBlockStart(StringBuilder result, GeneratorOptions options)
        {
            result.Append("{");
            result.Append(options.LBoS());
        }

        protected virtual void GraphBlockEnd(StringBuilder result, GeneratorOptions options)
        {
            result.Append(options.LBoS());
            result.Append("}");
        }

        protected virtual void GraphNodes(StringBuilder result, List<GraphNode> nodes, GeneratorOptions options)
        {
            if (!nodes.Any())
            {
                return;
            }

            foreach (var node in nodes)
            {
                var generator = _entityGenerators.GetForTypeOrForAnyBaseType(node);
                var generated = generator.Generate(node, options);

                result.Append(generated);
                result.Append(options.LBoS());
            }

            result.Append(options.LBoS());
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

        string? IEntityGenerator.Generate(IEntity graph, GeneratorOptions options)
        {
            return Generate((Graph)graph, options);
        }
    }
}

using Dotless.Generators.Extensions;
using Dotless.Graphs;
using Dotless.TextEscaping;
using System.Text;

namespace Dotless.Generators
{
    public class GraphGenerator
    {
        public GeneratorOptions Options { get; }

        public virtual EntityGeneratorCollection EntityGenerators { get; }

        public GraphGenerator(EntityGeneratorCollection generators)
            : this(generators, new GeneratorOptions())
        {
        }

        public GraphGenerator(EntityGeneratorCollection generators, GeneratorOptions generatorOptions)
        {
            EntityGenerators = generators;
            Options = generatorOptions;
        }

        public virtual string Generate(Graph graph)
        {
            var result = new StringBuilder();

            GraphSpecification(graph, result);
            BeginningOfGraph(result);

            GraphAttributes(graph, result);

            EndOfGraph(result);

            return result.ToString();
        }


        protected virtual void GraphSpecification(Graph graph, StringBuilder result)
        {
            if (graph.IsStrict)
            {
                result.Append("strict");
                result.Append(Options.TSoS());
            }

            result.Append(graph.IsDirected ? "digraph" : "graph");

            if (graph.Name is { })
            {
                result.Append(Options.TS());
                result.Append($"\"{new QuotationMarkEscaper().Escape(graph.Name)}\"");
                result.Append(Options.TS());
            }
        }

        protected virtual void BeginningOfGraph(StringBuilder result)
        {
            result.Append("{");
            result.Append(Options.LBoS());
        }

        protected virtual void EndOfGraph(StringBuilder result)
        {
            result.Append(Options.LBoS());
            result.Append("}");
        }

        protected virtual void GraphAttributes(Graph graph, StringBuilder result)
        {
            foreach (var attribute in graph.Attributes)
            {
                var generator = EntityGenerators.GetForType(attribute.GetType());
                result.Append(generator.Generate(attribute, Options));
            }
        }

        public static GraphGenerator CreateDefault(GeneratorOptions? options = null)
        {
            var generators = new EntityGeneratorCollection();

            generators.Add(new TextLabelAttributeGenerator());
            generators.Add(new HtmlLabelAttributeGenerator());

            return options is { }
                ? new GraphGenerator(generators, options)
                : new GraphGenerator(generators);
        }
    }
}

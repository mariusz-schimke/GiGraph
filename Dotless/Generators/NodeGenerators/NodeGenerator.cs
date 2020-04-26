using Dotless.Core;
using Dotless.Generators.Extensions;
using Dotless.GraphElements;
using Dotless.TextEscaping;
using System.Linq;
using System.Text;

namespace Dotless.Generators.NodeGenerators
{
    public class NodeGenerator : IEntityGenerator<GraphNode>
    {
        protected readonly EntityGeneratorCollection _entityGenerators;

        public NodeGenerator(EntityGeneratorCollection entityGenerators)
        {
            _entityGenerators = entityGenerators;
        }

        public string? Generate(GraphNode node, GeneratorOptions options)
        {
            var result = new StringBuilder();

            NodeId(result, node);
            NodeAttributes(result, node.Attributes, options);

            return result.ToString();
        }

        protected virtual void NodeId(StringBuilder result, GraphNode node)
        {
            result.Append($"\"{new QuotationMarkEscaper().Escape(node.Id)}\"");
        }

        protected virtual void NodeAttributes(StringBuilder result, AttributeCollection attributes, GeneratorOptions options)
        {
            if (!attributes.Any())
            {
                return;
            }

            var generator = _entityGenerators.GetForTypeOrForAnyBaseType(attributes);
            var generated = generator.Generate(attributes, options);

            result.Append(generated);
            result.Append(options.LBoS());
        }

        string? IEntityGenerator.Generate(IEntity entity, GeneratorOptions options)
        {
            return Generate((GraphNode)entity, options);
        }
    }
}

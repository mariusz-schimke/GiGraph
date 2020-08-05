using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Attributes;
using GiGraph.Dot.Output.Writers.Attributes.Graph;

namespace GiGraph.Dot.Output.Generators.Attributes.Graph
{
    public class DotGlobalGraphAttributeCollectionGenerator : DotAttributeCollectionGenerator<IDotGlobalGraphAttributeStatementWriter>
    {
        public DotGlobalGraphAttributeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteAttribute(DotAttribute attribute, IDotGlobalGraphAttributeStatementWriter writer)
        {
            var nodeWriter = writer.BeginAttributeStatement();
            _entityGenerators.GetForEntity<IDotAttributeWriter>(attribute).Generate(attribute, nodeWriter);
            writer.EndAttributeStatement();
        }
    }
}
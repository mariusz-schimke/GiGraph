using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Attributes.Edge;

namespace GiGraph.Dot.Output.Generators.Attributes.Edge
{
    public class DotGlobalEdgeAttributesGenerator : DotEntityWithAttributeListGenerator<DotAttributeCollection, IDotGlobalEdgeAttributesWriter>
    {
        public DotGlobalEdgeAttributesGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotAttributeCollection attributes, IDotGlobalEdgeAttributesWriter writer)
        {
            WriteEdgeKeyword(writer);
            WriteAttributes(attributes, writer, annotate: false);
        }

        protected virtual void WriteEdgeKeyword(IDotGlobalEdgeAttributesWriter writer)
        {
            writer.WriteEdgeKeyword();
        }
    }
}
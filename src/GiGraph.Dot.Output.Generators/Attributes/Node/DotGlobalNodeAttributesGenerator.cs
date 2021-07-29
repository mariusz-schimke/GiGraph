using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Attributes.Node;

namespace GiGraph.Dot.Output.Generators.Attributes.Node
{
    public class DotGlobalNodeAttributesGenerator : DotEntityWithAttributeListGenerator<DotAttributeCollection, IDotGlobalNodeAttributesWriter>
    {
        public DotGlobalNodeAttributesGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotAttributeCollection attributes, IDotGlobalNodeAttributesWriter writer)
        {
            WriteNodeKeyword(writer);
            WriteAttributes(attributes, writer, annotate: false);
        }

        protected virtual void WriteNodeKeyword(IDotGlobalNodeAttributesWriter writer)
        {
            writer.WriteNodeKeyword();
        }
    }
}
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Graphs.Attributes;

namespace GiGraph.Dot.Output.Generators.Graphs.Attributes
{
    public class DotGlobalGraphAttributesGenerator : DotEntityWithAttributeListGenerator<DotAttributeCollection, IDotGlobalGraphAttributesWriter>
    {
        public DotGlobalGraphAttributesGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotAttributeCollection attributes, IDotGlobalGraphAttributesWriter writer)
        {
            WriteGraphKeyword(writer);
            WriteAttributes(attributes, writer, annotate: false);
        }

        protected virtual void WriteGraphKeyword(IDotGlobalGraphAttributesWriter writer)
        {
            writer.WriteGraphKeyword();
        }
    }
}
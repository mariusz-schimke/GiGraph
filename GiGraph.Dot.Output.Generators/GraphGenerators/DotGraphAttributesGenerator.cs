using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.GraphWriters;

namespace GiGraph.Dot.Output.Generators.GraphGenerators
{
    public class DotGraphAttributesGenerator : DotEntityWithAttributeListGenerator<DotAttributeCollection, IDotGraphAttributesWriter>
    {
        public DotGraphAttributesGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotAttributeCollection defaults, IDotGraphAttributesWriter writer)
        {
            WriteGraphKeyword(writer);
            WriteAttributes(defaults, writer, annotate: false);
        }

        protected virtual void WriteGraphKeyword(IDotGraphAttributesWriter writer)
        {
            writer.WriteGraphKeyword();
        }
    }
}
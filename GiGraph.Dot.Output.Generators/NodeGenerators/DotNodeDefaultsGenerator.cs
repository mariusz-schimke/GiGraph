using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.TextEscaping;
using GiGraph.Dot.Writers.NodeWriters;

namespace GiGraph.Dot.Output.Generators.NodeGenerators
{
    public class DotNodeDefaultsGenerator : DotEntityWithAttributeListGenerator<DotCommonAttributeCollection, IDotNodeDefaultsWriter>
    {
        protected DotNodeDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotNodeDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonAttributeCollection defaults, IDotNodeDefaultsWriter writer)
        {
            WriteNodeKeyword(writer);
            WriteAttributes(defaults, writer);
        }

        protected virtual void WriteNodeKeyword(IDotNodeDefaultsWriter writer)
        {
            writer.WriteNodeKeyword();
        }
    }
}

using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.TextEscaping;
using GiGraph.Dot.Output.Writers.EdgeWriters;

namespace GiGraph.Dot.Output.Generators.EdgeGenerators
{
    public class DotEdgeDefaultsGenerator : DotEntityWithAttributeListGenerator<DotCommonAttributeCollection, IDotEdgeDefaultsWriter>
    {
        protected DotEdgeDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotEdgeDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonAttributeCollection defaults, IDotEdgeDefaultsWriter writer)
        {
            WriteEdgeKeyword(writer);
            WriteAttributes(defaults, writer);
        }

        protected virtual void WriteEdgeKeyword(IDotEdgeDefaultsWriter writer)
        {
            writer.WriteEdgeKeyword();
        }
    }
}

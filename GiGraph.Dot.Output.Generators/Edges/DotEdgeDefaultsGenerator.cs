using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.EdgeWriters;

namespace GiGraph.Dot.Output.Generators.Edges
{
    public class DotEdgeDefaultsGenerator : DotEntityWithAttributeListGenerator<DotAttributeCollection, IDotEdgeDefaultsWriter>
    {
        public DotEdgeDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotAttributeCollection defaults, IDotEdgeDefaultsWriter writer)
        {
            WriteEdgeKeyword(writer);
            WriteAttributes(defaults, writer, annotate: false);
        }

        protected virtual void WriteEdgeKeyword(IDotEdgeDefaultsWriter writer)
        {
            writer.WriteEdgeKeyword();
        }
    }
}
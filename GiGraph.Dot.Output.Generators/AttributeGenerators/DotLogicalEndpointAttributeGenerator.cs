using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.TextEscaping;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
{
    public class DotLogicalEndpointAttributeGenerator : DotAttributeGenerator<DotLogicalEndpointAttribute>
    {
        protected DotLogicalEndpointAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper = null, TextEscapingPipeline valueEscaper = null)
            // use the same value escaping pipeline as the cluster generator uses for escaping cluster identifier
            : base(syntaxRules, options, entityGenerators, identifierEscaper, valueEscaper ?? TextEscapingPipeline.ForGraphId())
        {
        }

        public DotLogicalEndpointAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : this(syntaxRules, options, entityGenerators, identifierEscaper: null, valueEscaper: null)
        {
        }
        
        protected override string FormatValue(string value)
        {
            // keep this value coherent with the format the cluster generator uses to generate cluster identifier
            return DotClusterIdFormatter.Format(value, _options);
        }
    }
}
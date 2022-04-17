using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.Graphs;

public class DotGraphSectionGenerator : DotGraphSectionGenerator<DotGraphSection>
{
    public DotGraphSectionGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
        : base(syntaxRules, options, entityGenerators)
    {
    }

    protected override bool PreferGraphAttributesAsStatements => _options.Graph.AttributesAsStatements;
}
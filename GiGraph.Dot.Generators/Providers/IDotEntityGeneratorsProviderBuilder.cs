using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Generators.Providers
{
    public interface IDotEntityGeneratorsProviderBuilder
    {
        IDotEntityGeneratorsProvider Build(DotSyntaxRules syntaxRules, DotGenerationOptions options);
    }
}
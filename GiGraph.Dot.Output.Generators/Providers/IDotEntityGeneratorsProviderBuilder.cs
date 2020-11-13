using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.Providers
{
    public interface IDotEntityGeneratorsProviderBuilder
    {
        IDotEntityGeneratorsProvider Build(DotSyntaxRules syntaxRules, DotSyntaxOptions options);
    }
}
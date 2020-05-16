using GiGraph.Dot.Core;
using GiGraph.Dot.Generators.Options;

namespace GiGraph.Dot.Generators.Providers
{
    public interface IDotEntityGeneratorsProviderBuilder
    {
        IDotEntityGeneratorsProvider Build(DotSyntaxRules syntaxRules, DotGenerationOptions options);
    }
}
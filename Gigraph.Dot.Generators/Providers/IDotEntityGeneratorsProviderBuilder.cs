using Gigraph.Dot.Core;
using Gigraph.Dot.Generators.Options;

namespace Gigraph.Dot.Generators.Providers
{
    public interface IDotEntityGeneratorsProviderBuilder
    {
        IDotEntityGeneratorsProvider Build(DotSyntaxRules syntaxRules, DotGenerationOptions options);
    }
}
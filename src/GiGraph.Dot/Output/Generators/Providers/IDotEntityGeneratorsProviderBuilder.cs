using System.Diagnostics.Contracts;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.Providers;

public interface IDotEntityGeneratorsProviderBuilder
{
    [Pure]
    IDotEntityGeneratorsProvider Build(DotSyntaxRules syntaxRules, DotSyntaxOptions options);
}
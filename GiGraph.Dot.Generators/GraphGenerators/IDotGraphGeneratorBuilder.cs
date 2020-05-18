using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;

namespace GiGraph.Dot.Generators.GraphGenerators
{
    public interface IDotGraphGeneratorBuilder
    {
        IDotEntityGenerator Build(DotSyntaxRules syntaxRules, DotGenerationOptions options);
    }
}
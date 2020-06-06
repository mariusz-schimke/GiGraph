using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.GraphGenerators
{
    public interface IDotGraphGeneratorBuilder
    {
        IDotEntityGenerator Build(DotSyntaxRules syntaxRules, DotGenerationOptions options);
    }
}
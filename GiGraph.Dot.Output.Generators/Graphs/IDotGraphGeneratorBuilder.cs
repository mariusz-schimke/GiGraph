using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.Graphs
{
    public interface IDotGraphGeneratorBuilder
    {
        IDotEntityGenerator Build(DotSyntaxRules syntaxRules, DotSyntaxOptions options);
    }
}
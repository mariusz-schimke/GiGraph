using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Graphs.Canvas.Scaling;

/// <summary>
///     Represents the scaling mode of the graph. Accepts either a numeric value (<see cref="DotGraphAspectRatio" />), or an
///     enumeration value (<see cref="DotGraphScaling" />).
/// </summary>
public abstract class DotGraphScalingDefinition : IDotEncodable
{
    string? IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedValue(options, syntaxRules);

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotGraphScalingDefinition?(double? value) => value.HasValue ? new DotGraphAspectRatio(value.Value) : null;

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotGraphScalingDefinition?(DotGraphScaling? value) => value.HasValue ? new DotGraphScalingMode(value.Value) : null;

    protected abstract string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
}
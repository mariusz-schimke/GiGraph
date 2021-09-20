using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Graphs
{
    /// <summary>
    ///     Represents the scaling mode of the graph. Accepts either a numeric value (<see cref="DotGraphScalingAspectRatio" />), or an
    ///     enumeration value (<see cref="DotGraphScaling" />).
    /// </summary>
    public abstract record DotGraphScalingDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        public static implicit operator DotGraphScalingDefinition(double? value)
        {
            return value.HasValue ? new DotGraphScalingAspectRatio(value.Value) : null;
        }

        public static implicit operator DotGraphScalingDefinition(DotGraphScaling? value)
        {
            return value.HasValue ? new DotGraphScalingOption(value.Value) : null;
        }

        protected abstract string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
    }
}
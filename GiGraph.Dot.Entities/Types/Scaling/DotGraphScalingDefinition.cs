using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Scaling
{
    /// <summary>
    ///     Represents the scaling mode of the graph. Accepts either a numeric value (<see cref="DotGraphScalingAspectRatio" />), or an
    ///     enumerable value (<see cref="DotGraphScaling" />).
    /// </summary>
    public abstract class DotGraphScalingDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
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

        protected internal abstract string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules);
    }
}
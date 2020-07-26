using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.AspectRatio
{
    /// <summary>
    ///     Represents the aspect ratio of the graph. Accepts either a numeric value (<see cref="DotAspectRatioQuotient" />), or an
    ///     enumerable value (<see cref="DotAspectRatio" />).
    /// </summary>
    public abstract class DotAspectRatioDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        public static implicit operator DotAspectRatioDefinition(double? value)
        {
            return value.HasValue ? new DotAspectRatioQuotient(value.Value) : null;
        }

        public static implicit operator DotAspectRatioDefinition(DotAspectRatio? value)
        {
            return value.HasValue ? new DotAspectRatioOption(value.Value) : null;
        }

        protected internal abstract string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules);
    }
}
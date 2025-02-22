using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Encoders;

/// <summary>
///     A double list DOT encoder.
/// </summary>
public class DotDoubleListEncoder
{
    public static string Encode(IEnumerable<double> values, DotSyntaxRules syntaxRules)
    {
        return string.Join(":", values.Select(v => v.ToString(syntaxRules.Culture)));
    }
}
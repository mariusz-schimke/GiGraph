using System.Linq;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Double
{
    /// <summary>
    ///     A double list DOT encoder.
    /// </summary>
    public class DotDoubleListEncoder
    {
        public static string Convert(double[] values, DotSyntaxRules syntaxRules)
        {
            return string.Join(":", values.Select(v => v.ToString(syntaxRules.Culture)));
        }
    }
}
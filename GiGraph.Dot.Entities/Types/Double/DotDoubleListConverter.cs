using System.Globalization;
using System.Linq;

namespace GiGraph.Dot.Entities.Types.Double
{
    /// <summary>
    ///     A double list converter.
    /// </summary>
    public class DotDoubleListConverter
    {
        public static string Convert(double[] values)
        {
            return string.Join(":", values.Select(v => v.ToString(CultureInfo.InvariantCulture)));
        }
    }
}
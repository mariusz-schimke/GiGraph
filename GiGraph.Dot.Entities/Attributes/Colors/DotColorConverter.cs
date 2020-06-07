using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.Colors
{
    public static class DotColorConverter
    {
        public static string Convert(Color color)
        {
            return $"#{color.R:x2}{color.G:x2}{color.B:x2}{color.A:x2}";
        }
    }
}
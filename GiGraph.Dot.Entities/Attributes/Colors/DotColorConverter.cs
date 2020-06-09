using System;
using System.Drawing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes.Colors
{
    public static class DotColorConverter
    {
        public static string Convert(Color color, DotGenerationOptions options)
        {
            if (options.Colors.PreferName && color.IsNamedColor)
            {
                return color.Name.ToLowerInvariant();
            }

            // add alpha only when necessary
            var alpha = color.A < 0xff
                ? $"{color.A:x2}"
                : null;

            return $"#{color.R:x2}{color.G:x2}{color.B:x2}{alpha}";
        }
    }
}
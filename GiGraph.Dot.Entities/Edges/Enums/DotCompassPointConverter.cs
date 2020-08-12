using System;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Edges.Enums
{
    public static class DotCompassPointConverter
    {
        public static string Convert(DotCompassPoint compassPoint)
        {
            return DotAttributeValueAttribute.TryGetValue(compassPoint, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(compassPoint), $"The specified compass point '{compassPoint}' is invalid.");
        }
    }
}
using System;
using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Edges.Enums
{
    public static class DotCompassPointConverter
    {
        public static string Convert(DotCompassPoint compassPoint)
        {
            return DotAttributeValue.TryGet(compassPoint, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(compassPoint), $"The specified compass point '{compassPoint}' is invalid.");
        }
    }
}
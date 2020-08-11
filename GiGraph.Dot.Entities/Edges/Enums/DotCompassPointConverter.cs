using System;

namespace GiGraph.Dot.Entities.Edges.Enums
{
    public static class DotCompassPointConverter
    {
        public static string Convert(DotCompassPoint compassPoint)
        {
            return compassPoint switch
            {
                DotCompassPoint.Default => "_",
                DotCompassPoint.Center => "c",

                DotCompassPoint.North => "n",
                DotCompassPoint.NorthEast => "ne",

                DotCompassPoint.East => "e",
                DotCompassPoint.SouthEast => "se",

                DotCompassPoint.South => "s",
                DotCompassPoint.SouthWest => "sw",

                DotCompassPoint.West => "w",
                DotCompassPoint.NorthWest => "nw",

                _ => throw new ArgumentOutOfRangeException(nameof(compassPoint), $"The specified compass point '{compassPoint}' is not supported.")
            };
        }
    }
}
using GiGraph.Dot.Entities.Nodes.Enums;
using System;

namespace GiGraph.Dot.Output.Generators.Converters
{
    public class DotCompassPointConverter
    {
        public virtual string Convert(DotCompassPoint compassPoint)
        {
            switch (compassPoint)
            {
                case DotCompassPoint.Default:
                    return "_";

                case DotCompassPoint.Center:
                    return "c";

                case DotCompassPoint.North:
                    return "n";

                case DotCompassPoint.NorthEast:
                    return "ne";

                case DotCompassPoint.East:
                    return "e";

                case DotCompassPoint.SouthEast:
                    return "se";

                case DotCompassPoint.South:
                    return "s";

                case DotCompassPoint.SouthWest:
                    return "sw";

                case DotCompassPoint.West:
                    return "w";

                case DotCompassPoint.NorthWest:
                    return "nw";

                default:
                    throw new ArgumentOutOfRangeException(nameof(compassPoint), $"The specified compass point '{compassPoint}' is not supported.");
            }
        }
    }
}

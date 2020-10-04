using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public interface IDotEdgeEndpointLabelFontAttributes
    {
        /// <summary>
        ///     Font used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail <see cref="IDotEdgeTailAttributes.Label" />
        ///     of the edge. If not set, defaults to the edge's font name (<see cref="IDotEntityFontAttributes.Name" />).
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Font size, in points, used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail
        ///     <see cref="IDotEdgeTailAttributes.Label" /> of the edge. If not set, defaults to the edge's font size (
        ///     <see cref="IDotEntityFontAttributes.Size" />).
        /// </summary>
        double? Size { get; set; }

        /// <summary>
        ///     Color used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail <see cref="IDotEdgeTailAttributes.Label" />
        ///     of the edge. If not set, defaults to the edge's font color (<see cref="IDotEntityFontAttributes.Color" />).
        /// </summary>
        DotColor Color { get; set; }
    }
}
namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public interface IDotEdgeEndpointLabelAttributes
    {
        /// <summary>
        ///     Font properties used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail
        ///     <see cref="IDotEdgeTailAttributes.Label" /> of the edge. If not set, defaults to the edge's font properties (
        ///     <see cref="IDotEdgeAttributes.Font" />).
        /// </summary>
        IDotEdgeEndpointLabelFontAttributes Font { get; }

        /// <summary>
        ///     Multiplicative scaling factor adjusting the distance that the the head <see cref="IDotEdgeHeadAttributes.Label" /> and the
        ///     tail <see cref="IDotEdgeTailAttributes.Label" /> are from the head/tail nodes. The default distance is 10 points, the minimum
        ///     is 0.0. See also <see cref="Angle" />.
        /// </summary>
        double? Distance { get; set; }

        /// <summary>
        ///     <para>
        ///         This, along with <see cref="Distance" />, determine where the the head <see cref="IDotEdgeHeadAttributes.Label" /> and
        ///         the tail <see cref="IDotEdgeTailAttributes.Label" /> are placed with respect to the head/tail in polar coordinates. The
        ///         origin in the coordinate system is the point where the edge touches the node. The ray of 0 degrees goes from the origin
        ///         back along the edge, parallel to the edge at the origin.
        ///     </para>
        ///     <para>
        ///         The angle, in degrees, specifies the rotation from the 0 degree ray, with positive angles moving counterclockwise and
        ///         negative angles moving clockwise. The default value is -25.0, the minimum: -180.0.
        ///     </para>
        /// </summary>
        double? Angle { get; set; }
    }
}
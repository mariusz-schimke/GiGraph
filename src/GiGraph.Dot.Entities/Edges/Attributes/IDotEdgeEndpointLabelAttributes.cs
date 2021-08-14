namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public interface IDotEdgeEndpointLabelAttributes
    {
        /// <summary>
        ///     Multiplicative scaling factor adjusting the distance that the the head and tail labels are from the head/tail nodes (see
        ///     <see cref="DotEdgeEndpointAttributes.Label" /> on the <see cref="DotEdgeAttributes.Head" /> and the
        ///     <see cref="DotEdgeAttributes.Tail" /> attributes of the edge). The default distance is 10 points, the minimum is 0.0. See
        ///     also <see cref="Angle" />.
        /// </summary>
        double? Distance { get; set; }

        /// <summary>
        ///     <para>
        ///         This, along with <see cref="Distance" />, determine where the the head and tail labels are placed with respect to the
        ///         head/tail in polar coordinates (see <see cref="DotEdgeEndpointAttributes.Label" /> on the
        ///         <see cref="DotEdgeAttributes.Head" /> and on the <see cref="DotEdgeAttributes.Tail" /> attributes of the edge). The
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
namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The arrow shape.
    ///     <see href="https://www.graphviz.org/doc/info/attrs.html#k:arrowType">
    ///         View how individual arrow shapes are visualized
    ///     </see>
    ///     .
    /// </summary>
    public enum DotArrowShape
    {
        None,

        Normal,
        Empty,
        Open,
        HalfOpen,
        Vee,

        Diamond,
        EmptyDiamond,
        OpenDiamond,

        Dot,
        OpenDot,
        InvertedDot,
        InvertedOpenDot,

        Box,
        OpenBox,

        Inverted,
        InvertedEmpty,

        Crow,

        Tee
    }
}
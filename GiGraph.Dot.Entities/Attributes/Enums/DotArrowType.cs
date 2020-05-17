namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    /// The arrow type. To see how each arrow type is rendered,
    /// please go to <seealso cref="https://www.graphviz.org/doc/info/attrs.html#k:arrowType"/>.
    /// </summary>
    public enum DotArrowType
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

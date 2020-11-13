using GiGraph.Dot.Entities.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The arrowhead shape. See the
    ///     <see href="https://www.graphviz.org/doc/info/arrows.html">
    ///         documentation
    ///     </see>
    ///     to view how individual shapes are visualized.
    /// </summary>
    public enum DotArrowheadShape
    {
        [DotAttributeValue("none")]
        None,

        [DotAttributeValue("normal")]
        Normal,

        [DotAttributeValue("inv")]
        InvertedNormal,

        [DotAttributeValue("box")]
        Box,

        [DotAttributeValue("crow")]
        Crow,

        [DotAttributeValue("curve")]
        Curve,

        [DotAttributeValue("icurve")]
        InvertedCurve,

        [DotAttributeValue("diamond")]
        Diamond,

        [DotAttributeValue("dot")]
        Dot,

        [DotAttributeValue("tee")]
        Tee,

        [DotAttributeValue("vee")]
        Vee
    }
}
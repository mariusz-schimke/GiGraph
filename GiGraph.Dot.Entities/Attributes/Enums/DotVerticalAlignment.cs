using GiGraph.Dot.Entities.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The vertical label alignment options.
    /// </summary>
    public enum DotVerticalAlignment
    {
        [DotAttributeValue("t")]
        Top,

        [DotAttributeValue("c")]
        Center,

        [DotAttributeValue("b")]
        Bottom
    }
}
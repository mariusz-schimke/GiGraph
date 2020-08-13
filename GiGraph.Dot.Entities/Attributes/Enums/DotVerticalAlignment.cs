using GiGraph.Dot.Entities.Types.Attributes;

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
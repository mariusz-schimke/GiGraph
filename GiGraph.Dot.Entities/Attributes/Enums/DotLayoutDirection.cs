using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The direction of graph layout.
    /// </summary>
    public enum DotLayoutDirection
    {
        [DotAttributeValue("TB")]
        TopToBottom,

        [DotAttributeValue("BT")]
        BottomToTop,

        [DotAttributeValue("LR")]
        LeftToRight,

        [DotAttributeValue("RL")]
        RightToLeft
    }
}
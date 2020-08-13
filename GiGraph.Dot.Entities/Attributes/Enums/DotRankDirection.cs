using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The direction of graph layout.
    /// </summary>
    public enum DotRankDirection
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
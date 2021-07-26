using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Types.Layout
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
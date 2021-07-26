using System;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Determines the parts of an arrowhead. Left and right are defined as those directions determined by looking from the edge
    ///     towards the point where the arrow "touches" the node.
    /// </summary>
    [Flags]
    public enum DotArrowheadParts
    {
        /// <summary>
        ///     The left part of the arrowhead.
        /// </summary>
        [DotAttributeValue("l")]
        Left = 1 << 0,

        /// <summary>
        ///     The right part of the arrowhead.
        /// </summary>
        [DotAttributeValue("r")]
        Right = 1 << 1,

        /// <summary>
        ///     Both parts of the arrowhead.
        /// </summary>
        [DotAttributeValue(null)]
        Both = Left | Right
    }
}
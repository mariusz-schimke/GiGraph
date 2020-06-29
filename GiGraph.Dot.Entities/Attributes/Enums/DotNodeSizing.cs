﻿using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    /// The values valid for the <see cref="IDotNodeAttributes.Sizing"/> node attribute.
    /// </summary>
    public enum DotNodeSizing
    {
        /// <summary>
        /// The node size is specified by the values of the width and height attributes only and is not expanded to contain the text label.
        /// There will be a warning if the label (with margin) cannot fit within these limits.
        /// </summary>
        Fixed,

        /// <summary>
        /// The size of a node is determined by smallest width and height needed to contain its label and image, if any,
        /// with a margin specified by the margin attribute. The width and height must also be at least as large as the sizes
        /// specified by the width and height attributes, which specify the minimum values for these parameters.
        /// </summary>
        Auto,

        /// <summary>
        /// The width and height attributes also determine the size of the node shape, but the label can be much larger.
        /// Both the label and shape sizes are used when avoiding node overlap, but all edges to the node ignore the label
        /// and only contact the node shape. No warning is given if the label is too large.
        /// </summary>
        Shape
    }
}
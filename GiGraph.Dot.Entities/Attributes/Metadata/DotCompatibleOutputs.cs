using System;

namespace GiGraph.Dot.Entities.Attributes.Metadata
{
    /// <summary>
    ///     Determines outputs that an attribute is used by.
    /// </summary>
    [Flags]
    public enum DotCompatibleOutputs
    {
        /// <summary>
        ///     The attribute is used by any output.
        /// </summary>
        Any = -1,

        /// <summary>
        ///     The xdot format extends the dot format by providing much more detailed information about how graph components are drawn. It
        ///     relies on additional attributes for nodes, edges and graphs.
        /// </summary>
        Xdot = 1 << 0,

        /// <summary>
        ///     Windows Bitmap format.
        /// </summary>
        Bitmap = 1 << 1,

        /// <summary>
        ///     Scalable Vector Graphics
        /// </summary>
        Svg = 1 << 2,

        /// <summary>
        ///     Client-side imagemap (deprecated).
        /// </summary>
        Cmap = 1 << 3,

        Map = 1 << 4,

        /// <summary>
        ///     The PostScript format.
        /// </summary>
        PostScript = 1 << 5
    }
}
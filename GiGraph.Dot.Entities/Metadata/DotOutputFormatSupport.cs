using System;

namespace GiGraph.Dot.Entities.Metadata
{
    /// <summary>
    ///     Output format.
    /// </summary>
    [Flags]
    public enum DotOutputFormatSupport
    {
        Any = 0,
        
        /// <summary>
        ///     The xdot format extends the dot format by providing much more detailed information about how graph components are drawn. It
        ///     relies on additional attributes for nodes, edges and graphs.
        /// </summary>
        Xdot,

        /// <summary>
        ///     Windows Bitmap Format.
        /// </summary>
        Bitmap,

        /// <summary>
        ///     Scalable Vector Graphics
        /// </summary>
        Svg,

        /// <summary>
        ///     Client-side imagemap (deprecated)
        /// </summary>
        Cmap,

        Map,

        PostScript,

        /// <summary>
        ///     The attribute is used for output, and is not used or read by any layout program.
        /// </summary>
        Output
    }
}
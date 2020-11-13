using System;

namespace GiGraph.Dot.Entities.Metadata
{
    /// <summary>
    ///     Output formats.
    /// </summary>
    [Flags]
    public enum DotOutputFormatSupport
    {
        /// <summary>
        ///     Any format.
        /// </summary>
        Any = 0,

        /// <summary>
        ///     The xdot format extends the dot format by providing much more detailed information about how graph components are drawn. It
        ///     relies on additional attributes for nodes, edges and graphs.
        /// </summary>
        Xdot = 1 << 0,

        /// <summary>
        ///     Windows Bitmap Format.
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
        PostScript = 1 << 5,

        /// <summary>
        ///     Indicates that an attribute is used for output, and is not used or read by any layout program.
        /// </summary>
        Output = 1 << 6
    }
}
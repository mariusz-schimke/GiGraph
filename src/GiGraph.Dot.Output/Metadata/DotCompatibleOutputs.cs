using System;

namespace GiGraph.Dot.Output.Metadata;

// TODO: Rename to DotCompatibleOutputFormats (include properties of this type).
/// <summary>
///     Determines outputs that an attribute is used for.
/// </summary>
[Flags]
public enum DotCompatibleOutputs
{
    /// <summary>
    ///     The attribute may be used for any output.
    /// </summary>
    Any = -1,

    /// <summary>
    ///     The attribute is used for text output, for example:
    ///     <c>
    ///         echo 'digraph G { Node0 }' | dot -Tcanon
    ///     </c>
    /// </summary>
    Dot = 1 << 0,

    /// <summary>
    ///     The attribute is used for the xdot output. It extends the dot format by providing much more detailed information about how
    ///     graph components are drawn. It relies on additional attributes for nodes, edges and graphs.
    /// </summary>
    Xdot = 1 << 1,

    /// <summary>
    ///     The attribute is used for the Windows Bitmap output.
    /// </summary>
    Bitmap = 1 << 2,

    /// <summary>
    ///     The attribute is used for the Scalable Vector Graphics output.
    /// </summary>
    Svg = 1 << 3,

    /// <summary>
    ///     The attribute is used for the Client-side imagemap output (deprecated).
    /// </summary>
    Cmap = 1 << 4,

    /// <summary>
    ///     The attribute is used for the map output.
    /// </summary>
    Map = 1 << 5,

    /// <summary>
    ///     The attribute is used for the PostScript output.
    /// </summary>
    PostScript = 1 << 6
}
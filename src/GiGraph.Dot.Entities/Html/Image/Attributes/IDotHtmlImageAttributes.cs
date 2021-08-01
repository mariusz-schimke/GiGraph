using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Image.Attributes
{
    /// <summary>
    ///     The attributes of an HTML image element (&lt;img&gt;).
    /// </summary>
    public interface IDotHtmlImageAttributes
    {
        /// <summary>
        ///     Specifies the image file to be displayed in the cell. Note that if the software is used as a web server, file system access
        ///     to images is more restricted. See
        ///     <see href="https://graphviz.org/doc/info/command.html#d:GV_FILE_PATH">
        ///         GV_FILE_PATH
        ///     </see>
        ///     and
        ///     <see href="https://graphviz.org/doc/info/command.html#d:SERVER_NAME">
        ///         SERVER_NAME
        ///     </see>
        ///     .
        /// </summary>
        string Source { get; set; }

        /// <summary>
        ///     Specifies how the image will use any extra space available in its cell. If this attribute is undefined, the image inherits
        ///     the image scaling of the graph. If the cell has a fixed size and the image is too large, any offending dimension will be
        ///     shrunk to fit the space, the scaling being uniform in width and height if the scale is <see cref="DotImageScaling.None" />.
        ///     Note that the containing cell’s alignment attributes override the current attribute.
        /// </summary>
        DotImageScaling? Scaling { get; set; }
    }
}
using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Images;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public interface IDotNodeImageAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gives the name of a file containing an image to be displayed inside the node. The image file must be in one of the
        ///         <see href="http://www.graphviz.org/doc/info/output.html#d:image_fmts">
        ///             recognized formats
        ///         </see>
        ///         , typically JPEG, PNG, GIF, BMP, SVG or Postscript, and be able to be converted into the desired output format.
        ///     </para>
        ///     <para>
        ///         The file must contain the image size information. This is usually trivially true for the bitmap formats. For PostScript,
        ///         the file must contain a line starting with %%BoundingBox: followed by four integers specifying the lower left x and y
        ///         coordinates and the upper right x and y coordinates of the bounding box for the image, the coordinates being in points.
        ///         An SVG image file must contain width and height attributes, typically as part of the svg element. The values for these
        ///         should have the form of a floating point number, followed by optional units, e.g., width="76pt". Recognized units are in,
        ///         px, pc, pt, cm and mm for inches, pixels, picas, points, centimeters and millimeters, respectively. The default unit is
        ///         points.
        ///     </para>
        ///     <para>
        ///         Unlike with the shapefile attribute, the image is treated as node content rather than the entire node. In particular, an
        ///         image can be contained in a node of any shape, not just a rectangle.
        ///     </para>
        /// </summary>
        string Path { get; set; }

        /// <summary>
        ///     Controls how an image is positioned within its containing node. This only has an effect when the image is smaller than the
        ///     containing node. The default is to be centered both horizontally and vertically (<see cref="DotAlignment.MiddleCenter" />).
        /// </summary>
        DotAlignment? Alignment { get; set; }

        /// <summary>
        ///     <para>
        ///         Attribute controlling how an image fills its containing node. In general, the image is given its natural size, (compare
        ///         the <see cref="DotGraphCanvasAttributes.Dpi" /> attribute on graph <see cref="DotGraphAttributes.Canvas" />), and the
        ///         node size is made large enough to contain its image, its label, its padding, and its peripheries. Its width and height
        ///         will also be at least as large as its minimum width and height. If, however, the node's
        ///         <see cref="DotNodeAttributes.Size" /> <see cref="DotNodeSizeAttributes.Mode" /> is <see cref="DotNodeSizing.Fixed" />,
        ///         the <see cref="DotNodeSizeAttributes.Width" /> and <see cref="DotNodeSizeAttributes.Height" /> attributes specify the
        ///         exact size of the node.
        ///     </para>
        ///     <para>
        ///         During rendering, in the default case (<see cref="Scaling" /> = <see cref="DotImageScaling.None" />), the image retains
        ///         its natural size. If <see cref="Scaling" /> = <see cref="DotImageScaling.Uniform" />, the image is uniformly scaled
        ///         (i.e., its aspect ratio is preserved) to fit inside the node. At least one dimension of the image will be as large as
        ///         possible given the size of the node. When <see cref="Scaling" /> = <see cref="DotImageScaling.FillWidth" />, the width of
        ///         the image is scaled to fill the node width. The corresponding property holds when <see cref="Scaling" /> =
        ///         <see cref="DotImageScaling.FillHeight" />. When <see cref="Scaling" /> = <see cref="DotImageScaling.FillBoth" />, both
        ///         the height and the width are scaled separately to fill the node.
        ///     </para>
        ///     <para>
        ///         In all cases, if a dimension of the image is larger than the corresponding dimension of the node, that dimension of the
        ///         image is scaled down to fit the node. As with the case of expansion, if <see cref="Scaling" /> =
        ///         <see cref="DotImageScaling.Uniform" />, width and height are scaled uniformly.
        ///     </para>
        /// </summary>
        DotImageScaling? Scaling { get; set; }
    }
}
using GiGraph.Dot.Entities.Html.Image;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Builder;

public partial class DotHtmlBuilder
{
    /// <summary>
    ///     Appends an image element to this instance.
    /// </summary>
    /// <param name="source">
    ///     Specifies the image file to be displayed.
    /// </param>
    /// <param name="scaling">
    ///     Specifies how the image will use any extra space available in its cell.
    /// </param>
    public virtual DotHtmlBuilder AppendImage(string source, DotImageScaling? scaling = null)
    {
        return AppendEntity(new DotHtmlImage(source, scaling));
    }
}
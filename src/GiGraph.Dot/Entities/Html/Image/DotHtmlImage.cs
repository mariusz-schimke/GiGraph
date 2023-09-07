using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Image.Attributes;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Image;

/// <summary>
///     An HTML &lt;img&gt; element.
/// </summary>
public partial class DotHtmlImage : DotHtmlVoidElement
{
    /// <summary>
    ///     Initializes a new image element instance.
    /// </summary>
    /// <param name="source">
    ///     Specifies the image file to be displayed.
    /// </param>
    /// <param name="scaling">
    ///     Specifies how the image will use any extra space available in its cell.
    /// </param>
    public DotHtmlImage(string source, DotImageScaling? scaling = null)
        : this(new DotHtmlAttributeCollection())
    {
        Source = source;

        if (scaling.HasValue)
        {
            Scaling = scaling;
        }
    }

    protected DotHtmlImage(DotHtmlAttributeCollection attributes)
        : this(new DotHtmlImageAttributes(attributes))
    {
    }

    protected DotHtmlImage(DotHtmlImageAttributes attributes)
        : base("img", attributes.Collection)
    {
        Attributes = new(attributes);
    }

    /// <summary>
    ///     Provides access to the attributes of the image.
    /// </summary>
    public new DotHtmlElementRootAttributesAccessor<IDotHtmlImageAttributes, DotHtmlImageAttributes> Attributes { get; }
}
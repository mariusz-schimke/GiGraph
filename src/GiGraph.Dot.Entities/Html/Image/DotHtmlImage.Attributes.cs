using GiGraph.Dot.Entities.Html.Image.Attributes;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Image;

public partial class DotHtmlImage : IDotHtmlImageAttributes
{
    /// <inheritdoc cref="IDotHtmlImageAttributes.Source" />
    public virtual string Source
    {
        get => Attributes.Implementation.Source;
        set => Attributes.Implementation.Source = value;
    }

    /// <inheritdoc cref="IDotHtmlImageAttributes.Scaling" />
    public virtual DotImageScaling? Scaling
    {
        get => Attributes.Implementation.Scaling;
        set => Attributes.Implementation.Scaling = value;
    }
}
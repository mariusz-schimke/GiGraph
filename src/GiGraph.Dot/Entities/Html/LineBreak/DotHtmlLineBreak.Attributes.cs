using GiGraph.Dot.Entities.Html.LineBreak.Attributes;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.LineBreak;

public partial class DotHtmlLineBreak : IDotHtmlLineBreakAttributes
{
    /// <inheritdoc cref="IDotHtmlLineBreakAttributes.LineAlignment" />
    public virtual DotHorizontalAlignment? LineAlignment
    {
        get => Attributes.Implementation.LineAlignment;
        set => Attributes.Implementation.LineAlignment = value;
    }
}
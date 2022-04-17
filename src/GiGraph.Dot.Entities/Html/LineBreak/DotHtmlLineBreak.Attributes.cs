using GiGraph.Dot.Entities.Html.LineBreak.Attributes;
using GiGraph.Dot.Output.Metadata.Html;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.LineBreak;

public partial class DotHtmlLineBreak : IDotHtmlLineBreakAttributes
{
    /// <inheritdoc cref="IDotHtmlLineBreakAttributes.LineAlignment" />
    [DotHtmlAttributeKey("align")]
    public virtual DotHorizontalAlignment? LineAlignment
    {
        get => Attributes.Implementation.LineAlignment;
        set => Attributes.Implementation.LineAlignment = value;
    }
}
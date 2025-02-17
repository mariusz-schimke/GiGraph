using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public abstract partial class DotHtmlTableTableCellCommonAttributes<TIHtmlTableTableCellAttributeProperties, THtmlTableTableCellAttributeProperties>
    : DotHtmlElementAttributes<TIHtmlTableTableCellAttributeProperties, THtmlTableTableCellAttributeProperties>, IDotHtmlTableTableCellCommonAttributes
    where TIHtmlTableTableCellAttributeProperties : IDotHtmlTableTableCellCommonAttributes
    where THtmlTableTableCellAttributeProperties : DotHtmlTableTableCellCommonAttributes<TIHtmlTableTableCellAttributeProperties, THtmlTableTableCellAttributeProperties>, TIHtmlTableTableCellAttributeProperties
{
    protected DotHtmlTableTableCellCommonAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    [DotAttributeKey("id")]
    public virtual partial DotEscapeString? Id { get; set; }

    [DotAttributeKey("port")]
    public virtual partial string? PortName { get; set; }

    [DotAttributeKey("valign")]
    public virtual partial DotVerticalAlignment? VerticalAlignment { get; set; }

    [DotAttributeKey("bgcolor")]
    public virtual partial DotColorDefinition? BackgroundColor { get; set; }

    [DotAttributeKey("color")]
    public virtual partial DotColor? BorderColor { get; set; }

    [DotAttributeKey("border")]
    public virtual partial int? BorderWidth { get; set; }

    [DotAttributeKey("cellpadding")]
    public virtual partial int? CellPadding { get; set; }

    [DotAttributeKey("cellspacing")]
    public virtual partial int? CellSpacing { get; set; }

    [DotAttributeKey("sides")]
    public virtual partial DotHtmlTableBorders? Borders { get; set; }

    [DotAttributeKey("fixedsize")]
    public virtual partial bool? FixedSize { get; set; }

    [DotAttributeKey("gradientangle")]
    public virtual partial int? GradientFillAngle { get; set; }

    [DotAttributeKey("width")]
    public virtual partial int? Width { get; set; }

    [DotAttributeKey("height")]
    public virtual partial int? Height { get; set; }

    [DotAttributeKey("href")]
    public virtual partial DotEscapeString? Href { get; set; }

    [DotAttributeKey("target")]
    public virtual partial DotEscapeString? Target { get; set; }

    [DotAttributeKey("title")]
    public virtual partial DotEscapeString? Title { get; set; }

    [DotAttributeKey("tooltip")]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    [DotAttributeKey("style")]
    public virtual partial DotHtmlTableStyles? Style { get; set; }
}
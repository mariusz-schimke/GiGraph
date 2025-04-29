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

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Id"/>
    [DotAttributeKey("id")]
    public virtual partial DotEscapeString? Id { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.PortName"/>
    [DotAttributeKey("port")]
    public virtual partial string? PortName { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.VerticalAlignment"/>
    [DotAttributeKey("valign")]
    public virtual partial DotVerticalAlignment? VerticalAlignment { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BackgroundColor"/>
    [DotAttributeKey("bgcolor")]
    public virtual partial DotColorDefinition? BackgroundColor { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BorderColor"/>
    [DotAttributeKey("color")]
    public virtual partial DotColor? BorderColor { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.BorderWidth"/>
    [DotAttributeKey("border")]
    public virtual partial int? BorderWidth { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellPadding"/>
    [DotAttributeKey("cellpadding")]
    public virtual partial int? CellPadding { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellSpacing"/>
    [DotAttributeKey("cellspacing")]
    public virtual partial int? CellSpacing { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Borders"/>
    [DotAttributeKey("sides")]
    public virtual partial DotHtmlTableBorders? Borders { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.FixedSize"/>
    [DotAttributeKey("fixedsize")]
    public virtual partial bool? FixedSize { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.GradientFillAngle"/>
    [DotAttributeKey("gradientangle")]
    public virtual partial int? GradientFillAngle { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Width"/>
    [DotAttributeKey("width")]
    public virtual partial int? Width { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Height"/>
    [DotAttributeKey("height")]
    public virtual partial int? Height { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Href"/>
    [DotAttributeKey("href")]
    public virtual partial DotEscapeString? Href { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Target"/>
    [DotAttributeKey("target")]
    public virtual partial DotEscapeString? Target { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Title"/>
    [DotAttributeKey("title")]
    public virtual partial DotEscapeString? Title { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Tooltip"/>
    [DotAttributeKey("tooltip")]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Style"/>
    [DotAttributeKey("style")]
    public virtual partial DotHtmlTableStyles? Style { get; set; }
}
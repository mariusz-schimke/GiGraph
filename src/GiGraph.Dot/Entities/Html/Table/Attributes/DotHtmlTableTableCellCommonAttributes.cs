using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public abstract partial class DotHtmlTableTableCellCommonAttributes<TIHtmlTableTableCellAttributeProperties, THtmlTableTableCellAttributeProperties>(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
    : DotHtmlElementAttributes<TIHtmlTableTableCellAttributeProperties, THtmlTableTableCellAttributeProperties>(attributes, attributeKeyLookup), IDotHtmlTableTableCellCommonAttributes
    where TIHtmlTableTableCellAttributeProperties : IDotHtmlTableTableCellCommonAttributes
    where THtmlTableTableCellAttributeProperties : DotHtmlTableTableCellCommonAttributes<TIHtmlTableTableCellAttributeProperties, THtmlTableTableCellAttributeProperties>, TIHtmlTableTableCellAttributeProperties
{
    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Id"/>
    [DotAttributeKey("id")]
    public virtual partial DotEscapeString? Id { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.PortName"/>
    [DotAttributeKey("port")]
    public virtual partial string? PortName { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellPadding"/>
    [DotAttributeKey("cellpadding")]
    public virtual partial int? CellPadding { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.CellSpacing"/>
    [DotAttributeKey("cellspacing")]
    public virtual partial int? CellSpacing { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonAttributes.Borders"/>
    [DotAttributeKey("sides")]
    public virtual partial DotHtmlTableBorders? Borders { get; set; }
}
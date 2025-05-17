using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableTableCellSizeAttributes : DotEntityAttributes<IDotHtmlTableTableCellSizeAttributes, DotHtmlTableTableCellSizeAttributes>, IDotHtmlTableTableCellSizeAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableTableCellSizeAttributes, IDotHtmlTableTableCellSizeAttributes>().BuildLazy();

    public DotHtmlTableTableCellSizeAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableTableCellSizeAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellSizeAttributes.Width"/>
    [DotAttributeKey("width")]
    public virtual partial int? Width { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellSizeAttributes.Height"/>
    [DotAttributeKey("height")]
    public virtual partial int? Height { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellSizeAttributes.Fixed"/>
    [DotAttributeKey("fixedsize")]
    public virtual partial bool? Fixed { get; set; }

    /// <summary>
    ///     Sets size attributes.
    /// </summary>
    /// <param name="width">
    ///     The width to set.
    /// </param>
    /// <param name="height">
    ///     The width to set.
    /// </param>
    /// <param name="isFixed">
    ///     Specifies whether the values given by the <paramref name="width"/> and <paramref name="height"/> attributes are enforced.
    /// </param>
    public virtual void Set(int? width = null, int? height = null, bool? isFixed = null)
    {
        Width = width;
        Height = height;
        Fixed = isFixed;
    }

    /// <summary>
    ///     Sets size attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set. Note that double values will be cast to integers, potentially losing the fractional part.
    /// </param>
    /// <param name="isFixed">
    ///     Specifies whether the values given by the <see cref="DotSize.Width"/> and <see cref="DotSize.Height"/> attributes are
    ///     enforced.
    /// </param>
    public virtual void Set(DotSize attributes, bool? isFixed = null)
    {
        Set((int?) attributes.Width, (int?) attributes.Height, isFixed);
    }
}
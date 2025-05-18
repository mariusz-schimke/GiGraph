using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Rule;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public abstract partial class DotHtmlTableTableCellCommonStyleAttributes<TIHtmlTableTableCellStyleAttributeProperties, THtmlTableTableCellStyleAttributeProperties>(
    DotHtmlAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup
)
    : DotEntityAttributes<TIHtmlTableTableCellStyleAttributeProperties, THtmlTableTableCellStyleAttributeProperties>(attributes, attributeKeyLookup), IDotHtmlTableTableCellCommonStyleAttributes, IDotHasStyleOptions<DotHtmlTableStyles>
    where TIHtmlTableTableCellStyleAttributeProperties : IDotHtmlTableTableCellCommonStyleAttributes
    where THtmlTableTableCellStyleAttributeProperties : DotHtmlTableTableCellCommonStyleAttributes<TIHtmlTableTableCellStyleAttributeProperties, THtmlTableTableCellStyleAttributeProperties>, TIHtmlTableTableCellStyleAttributeProperties
{
    protected const string StyleAttributeKey = "style";

    /// <summary>
    ///     True indicates that the element will have rounded corners. This probably works best if the outmost cells have no borders, or
    ///     their cell spacing is sufficiently large. If it is desirable to have borders around the cells, use HR (
    ///     <see cref="DotHtmlHorizontalRule"/>) and VR (<see cref="DotHtmlVerticalRule"/>) elements, or the column and row formatting
    ///     attributes of the table.
    /// </summary>
    public virtual bool RoundedCorners
    {
        get => this.HasStyleOption(DotHtmlTableStyles.Rounded);
        set => this.SetStyleOption(DotHtmlTableStyles.Rounded, value);
    }

    /// <summary>
    ///     True indicates that the element will have a radial gradient fill if a <see cref="DotGradientColor"/> is specified for
    ///     <see cref="BackgroundColor"/>.
    /// </summary>
    public virtual bool RadialFill
    {
        get => this.HasStyleOption(DotHtmlTableStyles.Radial);
        set => this.SetStyleOption(DotHtmlTableStyles.Radial, value);
    }

    protected virtual DotHtmlTableStyles? Style
    {
        get => ((IDotHtmlTableTableCellCommonStyleAttributes) this).Style;
        set => ((IDotHtmlTableTableCellCommonStyleAttributes) this).Style = value;
    }

    DotHtmlTableStyles? IDotHasStyleOptions<DotHtmlTableStyles>.Style
    {
        get => Style;
        set => Style = value;
    }

    [DotAttributeKey(StyleAttributeKey)]
    DotHtmlTableStyles? IDotHtmlTableTableCellCommonStyleAttributes.Style
    {
        [DotAttributeKey(StyleAttributeKey)]
        get => _attributes.GetValueAs(StyleAttributeKey, out DotHtmlTableStyles? result) ? result : null;
        [DotAttributeKey(StyleAttributeKey)]
        set => _attributes.SetValueOrRemove(StyleAttributeKey, value);
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonStyleAttributes.BackgroundColor"/>
    [DotAttributeKey("bgcolor")]
    public virtual partial DotColorDefinition? BackgroundColor { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonStyleAttributes.BorderColor"/>
    [DotAttributeKey("color")]
    public virtual partial DotColor? BorderColor { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonStyleAttributes.BorderWidth"/>
    [DotAttributeKey("border")]
    public virtual partial int? BorderWidth { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellCommonStyleAttributes.GradientFillAngle"/>
    [DotAttributeKey("gradientangle")]
    public virtual partial int? GradientFillAngle { get; set; }

    /// <summary>
    ///     Indicates whether the element has a 'style' attribute assigned. Returns true if the 'style' attribute has any value,
    ///     including its default value that renders an empty 'style' attribute. The 'style' attribute is a composite of multiple
    ///     options, each of which is exposed and configurable via a dedicated property.
    /// </summary>
    [Pure]
    public bool HasStyleOptions() => Style.HasValue;

    /// <summary>
    ///     Removes the style options of the element if set. The 'style' attribute will not be rendered.
    /// </summary>
    [Pure]
    public THtmlTableTableCellStyleAttributeProperties RemoveStyleOptions()
    {
        Style = null;
        return (THtmlTableTableCellStyleAttributeProperties) this;
    }
}
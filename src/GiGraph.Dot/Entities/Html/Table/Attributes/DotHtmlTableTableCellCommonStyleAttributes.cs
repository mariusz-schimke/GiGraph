using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.EnumHelpers;
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
    ///     Gets or sets a fill style.
    /// </summary>
    public virtual DotHtmlTableFillStyle FillStyle
    {
        get => this.GetPartialStyleOption<DotHtmlTableFillStyle, DotHtmlTableStyles>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a corner style.
    /// </summary>
    public virtual DotHtmlTableCornerStyle CornerStyle
    {
        get => this.GetPartialStyleOption<DotHtmlTableCornerStyle, DotHtmlTableStyles>();
        set => SetPartialStyleOption(value);
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
    ///     Applies the specified style options to the element.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    public virtual void SetStyleOptions(DotHtmlTableStyleOptions options)
    {
        SetStyleOptions(options.FillStyle, options.CornerStyle);
    }

    /// <summary>
    ///     Applies the specified style options to the element.
    /// </summary>
    /// <param name="fillStyle">
    ///     Specifies a fill style.
    /// </param>
    /// <param name="cornerStyle">
    ///     Specifies a corner style.
    /// </param>
    public virtual void SetStyleOptions(DotHtmlTableFillStyle fillStyle = DotHtmlTableFillStyle.Regular, DotHtmlTableCornerStyle cornerStyle = DotHtmlTableCornerStyle.Sharp)
    {
        FillStyle = fillStyle;
        CornerStyle = cornerStyle;
    }

    protected virtual void SetPartialStyleOption<TPartialStyle>(TPartialStyle option)
        where TPartialStyle : struct, Enum
    {
        var style = Style.GetValueOrDefault();
        style = DotPartialEnumMapper.ReplacePartialFlags(option, style);

        // since the style option may be set through helper methods, setting regular fill style would implicitly cause an empty style attribute to be rendered, which makes no sense
        Style = DotEnumHelper.IsDefault(style) ? null : style;
    }
}
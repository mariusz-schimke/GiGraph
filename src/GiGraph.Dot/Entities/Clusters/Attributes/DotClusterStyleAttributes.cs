using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

//todo: to ma ten sam zestaw opcji stylu co DotGraphClustersStyleAttributes
// może trzeba zrobić wspólną bazę implementującą IDotGraphClusterCommonStyleAttributes?

public partial class DotClusterStyleAttributes : DotEntityAttributesWithMetadata<IDotClusterStyleAttributes, DotClusterStyleAttributes>, IDotClusterStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotClusterStyleAttributes, IDotClusterStyleAttributes>().BuildLazy();
    private readonly DotStyleAttributeOptions _styleAttributeOptions;

    public DotClusterStyleAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotStyleAttributeOptions(attributes))
    {
    }

    protected DotClusterStyleAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup, DotStyleAttributeOptions styleAttributeOptions)
        : base(attributes, attributeKeyLookup)
    {
        _styleAttributeOptions = styleAttributeOptions;
    }


    /// <summary>
    ///     Gets or sets a fill style.
    /// </summary>
    public virtual DotClusterFillStyle FillStyle
    {
        get => _styleAttributeOptions.GetPart<DotClusterFillStyle>();
        set => _styleAttributeOptions.SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a border style.
    /// </summary>
    public virtual DotBorderStyle BorderStyle
    {
        get => _styleAttributeOptions.GetPart<DotBorderStyle>();
        set => _styleAttributeOptions.SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a border weight.
    /// </summary>
    public virtual DotBorderWeight BorderWeight
    {
        get => _styleAttributeOptions.GetPart<DotBorderWeight>();
        set => _styleAttributeOptions.SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a corner style.
    /// </summary>
    public virtual DotCornerStyle CornerStyle
    {
        get => _styleAttributeOptions.GetPart<DotCornerStyle>();
        set => _styleAttributeOptions.SetPart(value);
    }

    /// <summary>
    ///     When set, makes the element invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => _styleAttributeOptions.HasOption(DotStyles.Invisible);
        set => _styleAttributeOptions.ModifyOption(DotStyles.Invisible, value);
    }

    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual partial DotColorDefinition? Color { get; set; }

    [DotAttributeKey(DotAttributeKeys.ColorScheme)]
    public virtual partial string? ColorScheme { get; set; }

    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? FillColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.GradientAngle)]
    public virtual partial int? GradientFillAngle { get; set; }

    [DotAttributeKey(DotAttributeKeys.BgColor)]
    public virtual partial DotColorDefinition? BackgroundColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenColor)]
    public virtual partial DotColor? BorderColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? BorderWidth { get; set; }

    /// <summary>
    ///     Applies the specified style options.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    public virtual void Set(DotClusterStyleProperties options)
    {
        SetProperties(options.FillStyle, options.BorderStyle, options.BorderWeight, options.CornerStyle, options.Invisible);
    }

    /// <summary>
    ///     Applies the specified style options.
    /// </summary>
    /// <param name="fillStyle">
    ///     The fill style to set.
    /// </param>
    /// <param name="borderStyle">
    ///     The border style to set.
    /// </param>
    /// <param name="borderWeight">
    ///     The border weight to set.
    /// </param>
    /// <param name="cornerStyle">
    ///     The corner style to set.
    /// </param>
    /// <param name="invisible">
    ///     Determines whether the node should be invisible.
    /// </param>
    public virtual void Set(DotClusterFillStyle fillStyle = default, DotBorderStyle borderStyle = default,
        DotBorderWeight borderWeight = default, DotCornerStyle cornerStyle = default, bool invisible = false)
    {
        SetProperties(fillStyle, borderStyle, borderWeight, cornerStyle, invisible);
    }

    protected virtual void SetProperties(DotClusterFillStyle fillStyle, DotBorderStyle borderStyle, DotBorderWeight borderWeight, DotCornerStyle cornerStyle, bool invisible)
    {
        FillStyle = fillStyle;
        BorderStyle = borderStyle;
        BorderWeight = borderWeight;
        CornerStyle = cornerStyle;
        Invisible = invisible;
    }
}
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeStyleAttributes : DotEntityStyleAttributesWithMetadata<IDotEdgeStyleAttributes, DotEdgeStyleAttributes>, IDotEdgeStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeStyleAttributes, IDotEdgeStyleAttributes>().BuildLazy();

    public DotEdgeStyleAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotStyleAttributeOptions(attributes))
    {
    }

    protected DotEdgeStyleAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup, DotStyleAttributeOptions styleAttributeOptions)
        : base(attributes, attributeKeyLookup, styleAttributeOptions)
    {
    }
    
    /// <summary>
    ///     Gets or sets a line style for the edge (default: <see cref="DotLineStyle.Normal" />).
    /// </summary>
    public virtual DotLineStyle LineStyle
    {
        get => _styleAttributeOptions.GetPart<DotLineStyle>();
        set => _styleAttributeOptions.SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a line weight for the edge (default: <see cref="DotLineWeight.Normal" />).
    /// </summary>
    public virtual DotLineWeight LineWeight
    {
        get => _styleAttributeOptions.GetPart<DotLineWeight>();
        set => _styleAttributeOptions.SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a value indicating if the edge is invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => _styleAttributeOptions.HasOption(DotStyles.Invisible);
        set => _styleAttributeOptions.ModifyOption(DotStyles.Invisible, value);
    }

    /// <summary>
    ///     Applies the specified style options to the edge.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    public virtual void SetOptions(DotEdgeStyleOptions options)
    {
        SetOptions(options.LineStyle, options.LineWeight, options.Invisible);
    }

    /// <summary>
    ///     Applies the specified style options to the edge.
    /// </summary>
    /// <param name="lineStyle">
    ///     The line style to set.
    /// </param>
    /// <param name="lineWeight">
    ///     The line weight to set.
    /// </param>
    /// <param name="invisible">
    ///     Determines whether the edge should be invisible.
    /// </param>
    public virtual void SetOptions(DotLineStyle lineStyle = default, DotLineWeight lineWeight = default, bool invisible = false)
    {
        LineStyle = lineStyle;
        LineWeight = lineWeight;
        Invisible = invisible;
    }

    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual partial DotColorDefinition? Color { get; set; }

    [DotAttributeKey(DotAttributeKeys.ColorScheme)]
    public virtual partial string? ColorScheme { get; set; }

    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? FillColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? Width { get; set; }
}
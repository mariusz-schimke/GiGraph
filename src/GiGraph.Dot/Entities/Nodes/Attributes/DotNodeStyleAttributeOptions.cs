using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

// todo: usunąć
public class DotNodeStyleAttributeOptions(DotAttributeCollection attributes) : DotStyleAttributeOptions(attributes)
{
    /// <summary>
    ///     Gets or sets a fill style.
    /// </summary>
    public virtual DotNodeFillStyle FillStyle
    {
        get => GetPart<DotNodeFillStyle>();
        set => SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a border style.
    /// </summary>
    public virtual DotBorderStyle BorderStyle
    {
        get => GetPart<DotBorderStyle>();
        set => SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a border weight.
    /// </summary>
    public virtual DotBorderWeight BorderWeight
    {
        get => GetPart<DotBorderWeight>();
        set => SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a corner style.
    /// </summary>
    public virtual DotCornerStyle CornerStyle
    {
        get => GetPart<DotCornerStyle>();
        set => SetPart(value);
    }

    /// <summary>
    ///     When set, causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two
    ///     chords near the top and the bottom of the shape.
    /// </summary>
    public virtual bool Diagonals
    {
        get => HasOption(DotStyles.Diagonals);
        set => ModifyOption(DotStyles.Diagonals, value);
    }

    /// <summary>
    ///     When set, makes the element invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => HasOption(DotStyles.Invisible);
        set => ModifyOption(DotStyles.Invisible, value);
    }

    /// <summary>
    ///     Applies the specified style options.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    public virtual void Set(DotNodeStyleProperties options)
    {
        Set(options.FillStyle, options.BorderStyle, options.BorderWeight, options.CornerStyle, options.Diagonals, options.Invisible);
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
    /// <param name="diagonals">
    ///     Causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two chords near
    ///     the top and the bottom of the shape.
    /// </param>
    /// <param name="invisible">
    ///     Determines whether the node should be invisible.
    /// </param>
    public virtual void Set(DotNodeFillStyle fillStyle = default, DotBorderStyle borderStyle = default, DotBorderWeight borderWeight = default,
        DotCornerStyle cornerStyle = default, bool diagonals = false, bool invisible = false)
    {
        FillStyle = fillStyle;
        BorderStyle = borderStyle;
        BorderWeight = borderWeight;
        CornerStyle = cornerStyle;
        Diagonals = diagonals;
        Invisible = invisible;
    }
}
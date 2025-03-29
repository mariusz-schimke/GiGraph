using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.ClusterNode;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public class DotNodeStyleAttributeOptions : DotClusterNodeCommonStyleAttributeOptions<DotNodeFillStyle, DotNodeStyleProperties>
{
    public DotNodeStyleAttributeOptions(DotAttributeCollection attributes)
        : base(attributes)
    {
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

    /// <inheritdoc cref="DotClusterNodeCommonStyleAttributeOptions{TFillStyle,TStyleProperties}.Set" />
    public override void Set(DotNodeStyleProperties options)
    {
        base.Set(options);
        Diagonals = options.Diagonals;
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
    public virtual void Set(DotNodeFillStyle fillStyle = default, DotBorderStyle borderStyle = default,
        DotBorderWeight borderWeight = default, DotCornerStyle cornerStyle = default, bool diagonals = false, bool invisible = false)
    {
        base.SetProperties(fillStyle, borderStyle, borderWeight, cornerStyle, invisible);
        Diagonals = diagonals;
    }

    /// <inheritdoc cref="DotClusterNodeCommonStyleAttributeOptions{TFillStyle,TStyleProperties}.CopyFrom" />
    public virtual void CopyFrom(DotNodeStyleAttributeOptions options)
    {
        base.CopyFrom(options);
        Diagonals = options.Diagonals;
    }
}
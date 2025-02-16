using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Layout;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public class DotGraphLayoutAttributes : DotEntityAttributesWithMetadata<IDotGraphLayoutAttributes, DotGraphLayoutAttributes>, IDotGraphLayoutAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphLayoutAttributes, IDotGraphLayoutAttributes>().BuildLazy();

    public DotGraphLayoutAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotGraphLayoutAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.FloatingNodeRank" />
    [DotAttributeKey(DotAttributeKeys.TbBalance)]
    public virtual DotRank? FloatingNodeRank
    {
        get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Rotation" />
    [DotAttributeKey(DotAttributeKeys.Rotation)]
    public virtual double? Rotation
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.RepeatEdgeCrossingMinimization" />
    [DotAttributeKey(DotAttributeKeys.ReMinCross)]
    public virtual bool? RepeatEdgeCrossingMinimization
    {
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.EdgeCrossingMinimizationScaleFactor" />
    [DotAttributeKey(DotAttributeKeys.McLimit)]
    public virtual double? EdgeCrossingMinimizationScaleFactor
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.UseGlobalRanking" />
    [DotAttributeKey(DotAttributeKeys.NewRank)]
    public virtual bool? UseGlobalRanking
    {
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.NodeRank" />
    [DotAttributeKey(DotAttributeKeys.Rank)]
    public virtual DotRank? NodeRank
    {
        get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Packing" />
    [DotAttributeKey(DotAttributeKeys.Pack)]
    public virtual DotPackingDefinition? Packing
    {
        get => GetValueAsPackingDefinition(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.PackingMode" />
    [DotAttributeKey(DotAttributeKeys.PackMode)]
    public virtual DotPackingModeDefinition? PackingMode
    {
        get => GetValueAsPackingModeDefinition(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.NodeSeparation" />
    [DotAttributeKey(DotAttributeKeys.NodeSep)]
    public virtual double? NodeSeparation
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.RankSeparation" />
    [DotAttributeKey(DotAttributeKeys.RankSep)]
    public virtual DotRankSeparationDefinition? RankSeparation
    {
        get => GetValueAsRankSeparationDefinition(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.ConcentrateEdges" />
    [DotAttributeKey(DotAttributeKeys.Concentrate)]
    public virtual bool? ConcentrateEdges
    {
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Engine" />
    [DotAttributeKey(DotAttributeKeys.Layout)]
    public virtual string? Engine
    {
        get => GetValueAsString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Direction" />
    [DotAttributeKey(DotAttributeKeys.RankDir)]
    public virtual DotLayoutDirection? Direction
    {
        get => GetValueAs<DotLayoutDirection>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.EdgeOrderingMode" />
    [DotAttributeKey(DotAttributeKeys.Ordering)]
    public virtual DotEdgeOrderingMode? EdgeOrderingMode
    {
        get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.ForceExternalLabels" />
    [DotAttributeKey(DotAttributeKeys.ForceLabels)]
    public virtual bool? ForceExternalLabels
    {
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.ForceCircularLayout" />
    [DotAttributeKey(DotAttributeKeys.OneBlock)]
    public virtual bool? ForceCircularLayout
    {
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.SortIndex" />
    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual int? SortIndex
    {
        get => GetValueAsInt(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <summary>
    ///     Copies layout attributes from the specified instance.
    /// </summary>
    /// <param name="attributes">
    ///     The instance to copy the attributes from.
    /// </param>
    public virtual void Set(IDotGraphLayoutAttributes attributes)
    {
        ConcentrateEdges = attributes.ConcentrateEdges;
        Direction = attributes.Direction;
        EdgeOrderingMode = attributes.EdgeOrderingMode;
        Engine = attributes.Engine;
        ForceExternalLabels = attributes.ForceExternalLabels;
        ForceCircularLayout = attributes.ForceCircularLayout;
        NodeRank = attributes.NodeRank;
        FloatingNodeRank = attributes.FloatingNodeRank;
        NodeSeparation = attributes.NodeSeparation;
        Packing = attributes.Packing;
        PackingMode = attributes.PackingMode;
        RankSeparation = attributes.RankSeparation;
        RepeatEdgeCrossingMinimization = attributes.RepeatEdgeCrossingMinimization;
        EdgeCrossingMinimizationScaleFactor = attributes.EdgeCrossingMinimizationScaleFactor;
        Rotation = attributes.Rotation;
        SortIndex = attributes.SortIndex;
        UseGlobalRanking = attributes.UseGlobalRanking;
    }
}
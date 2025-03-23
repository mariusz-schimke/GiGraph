using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Layout;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphLayoutAttributes : DotEntityAttributesWithMetadata<IDotGraphLayoutAttributes, DotGraphLayoutAttributes>, IDotGraphLayoutAttributes
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
    public virtual partial DotRank? FloatingNodeRank { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Rotation" />
    [DotAttributeKey(DotAttributeKeys.Rotation)]
    public virtual partial double? Rotation { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.RepeatEdgeCrossingMinimization" />
    [DotAttributeKey(DotAttributeKeys.ReMinCross)]
    public virtual partial bool? RepeatEdgeCrossingMinimization { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.EdgeCrossingMinimizationScaleFactor" />
    [DotAttributeKey(DotAttributeKeys.McLimit)]
    public virtual partial double? EdgeCrossingMinimizationScaleFactor { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.EnableGlobalRanking" />
    [DotAttributeKey(DotAttributeKeys.NewRank)]
    public virtual partial bool? EnableGlobalRanking { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.NodeRank" />
    [DotAttributeKey(DotAttributeKeys.Rank)]
    public virtual partial DotRank? NodeRank { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Packing" />
    [DotAttributeKey(DotAttributeKeys.Pack)]
    public virtual partial DotPackingDefinition? Packing { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.PackingMode" />
    [DotAttributeKey(DotAttributeKeys.PackMode)]
    public virtual partial DotPackingModeDefinition? PackingMode { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.NodeSeparation" />
    [DotAttributeKey(DotAttributeKeys.NodeSep)]
    public virtual partial double? NodeSeparation { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.RankSeparation" />
    [DotAttributeKey(DotAttributeKeys.RankSep)]
    public virtual partial DotRankSeparationDefinition? RankSeparation { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.ConcentrateEdges" />
    [DotAttributeKey(DotAttributeKeys.Concentrate)]
    public virtual partial bool? ConcentrateEdges { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Engine" />
    [DotAttributeKey(DotAttributeKeys.Layout)]
    public virtual partial string? Engine { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Direction" />
    [DotAttributeKey(DotAttributeKeys.RankDir)]
    public virtual partial DotLayoutDirection? Direction { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.EdgeOrderingMode" />
    [DotAttributeKey(DotAttributeKeys.Ordering)]
    public virtual partial DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.ForceExternalLabels" />
    [DotAttributeKey(DotAttributeKeys.ForceLabels)]
    public virtual partial bool? ForceExternalLabels { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.ForceCircularLayout" />
    [DotAttributeKey(DotAttributeKeys.OneBlock)]
    public virtual partial bool? ForceCircularLayout { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.SortIndex" />
    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual partial int? SortIndex { get; set; }

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
        EnableGlobalRanking = attributes.EnableGlobalRanking;
    }
}
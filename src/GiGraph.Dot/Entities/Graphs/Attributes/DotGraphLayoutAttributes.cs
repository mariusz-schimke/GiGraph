using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges.Layout;
using GiGraph.Dot.Types.Graphs.Layout;
using GiGraph.Dot.Types.Graphs.Layout.Packing;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;
using GiGraph.Dot.Types.Identifiers;

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

    /// <inheritdoc cref="IDotGraphLayoutAttributes.FloatingNodeRank"/>
    [DotAttributeKey(DotAttributeKeys.TbBalance)]
    public virtual partial DotRank? FloatingNodeRank { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Rotation"/>
    [DotAttributeKey(DotAttributeKeys.Rotation)]
    public virtual partial double? Rotation { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.RepeatEdgeCrossingMinimization"/>
    [DotAttributeKey(DotAttributeKeys.ReMinCross)]
    public virtual partial bool? RepeatEdgeCrossingMinimization { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.EdgeCrossingMinimizationScale"/>
    [DotAttributeKey(DotAttributeKeys.McLimit)]
    public virtual partial double? EdgeCrossingMinimizationScale { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.EnableGlobalRanking"/>
    [DotAttributeKey(DotAttributeKeys.NewRank)]
    public virtual partial bool? EnableGlobalRanking { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.NodeRank"/>
    [DotAttributeKey(DotAttributeKeys.Rank)]
    public virtual partial DotRank? NodeRank { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Packing"/>
    [DotAttributeKey(DotAttributeKeys.Pack)]
    public virtual partial DotPackingDefinition? Packing { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.PackingMode"/>
    [DotAttributeKey(DotAttributeKeys.PackMode)]
    public virtual partial DotPackingModeDefinition? PackingMode { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.NodeSeparation"/>
    [DotAttributeKey(DotAttributeKeys.NodeSep)]
    public virtual partial double? NodeSeparation { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.RankSeparation"/>
    [DotAttributeKey(DotAttributeKeys.RankSep)]
    public virtual partial DotRankSeparationDefinition? RankSeparation { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.ConcentrateEdges"/>
    [DotAttributeKey(DotAttributeKeys.Concentrate)]
    public virtual partial bool? ConcentrateEdges { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Engine"/>
    [DotAttributeKey(DotAttributeKeys.Layout)]
    public virtual partial string? Engine { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.Direction"/>
    [DotAttributeKey(DotAttributeKeys.RankDir)]
    public virtual partial DotLayoutDirection? Direction { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.EdgeOrderingMode"/>
    [DotAttributeKey(DotAttributeKeys.Ordering)]
    public virtual partial DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.EdgeShape"/>
    [DotAttributeKey(DotAttributeKeys.Splines)]
    public virtual partial DotEdgeShape? EdgeShape { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.ForceExternalLabels"/>
    [DotAttributeKey(DotAttributeKeys.ForceLabels)]
    public virtual partial bool? ForceExternalLabels { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.UseCircularLayout"/>
    [DotAttributeKey(DotAttributeKeys.OneBlock)]
    public virtual partial bool? UseCircularLayout { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.RootNodeId"/>
    [DotAttributeKey(DotAttributeKeys.Root)]
    public virtual partial DotId? RootNodeId { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.SortIndex"/>
    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual partial int? SortIndex { get; set; }

    /// <inheritdoc cref="IDotGraphLayoutAttributes.OutputOrder"/>
    [DotAttributeKey(DotAttributeKeys.OutputOrder)]
    public virtual partial DotOutputOrder? OutputOrder { get; set; }
}
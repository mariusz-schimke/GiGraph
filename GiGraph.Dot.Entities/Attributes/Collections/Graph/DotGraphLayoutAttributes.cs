using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Entities.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphLayoutAttributes : DotEntityAttributes<IDotGraphLayoutAttributes>, IDotGraphLayoutAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphLayoutAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphLayoutAttributes, IDotGraphLayoutAttributes>().Build();

        protected DotGraphLayoutAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphLayoutAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphLayoutAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.Rotation" />
        [DotAttributeKey(DotAttributeKeys.Rotation)]
        public virtual double? Rotation
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.RepeatCrossingMinimization" />
        [DotAttributeKey(DotAttributeKeys.ReMinCross)]
        public virtual bool? RepeatCrossingMinimization
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.UseGlobalRanking" />
        [DotAttributeKey(DotAttributeKeys.NewRank)]
        public virtual bool? UseGlobalRanking
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.NodeRank" />
        [DotAttributeKey(DotAttributeKeys.Rank)]
        public virtual DotRank? NodeRank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotRank?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotRankAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.Packing" />
        [DotAttributeKey(DotAttributeKeys.Pack)]
        public virtual DotPackingDefinition Packing
        {
            get
            {
                return GetValueAs<DotPackingDefinition>
                (
                    MethodBase.GetCurrentMethod(),
                    out var value,
                    v => v is int i ? (true, new DotPackingMargin(i)) : (false, default),
                    v => v is bool b ? (true, new DotPackingToggle(b)) : (false, default)
                )
                    ? value
                    : null;
            }
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPackingDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.PackingMode" />
        [DotAttributeKey(DotAttributeKeys.PackMode)]
        public virtual DotPackingModeDefinition PackingMode
        {
            get
            {
                return GetValueAs<DotPackingModeDefinition>
                (
                    MethodBase.GetCurrentMethod(),
                    out var value,
                    v => v is DotPackingGranularity g ? (true, new DotGranularPackingMode(g)) : (false, default)
                )
                    ? value
                    : null;
            }
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPackingModeDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.NodeSeparation" />
        [DotAttributeKey(DotAttributeKeys.NodeSep)]
        public virtual double? NodeSeparation
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(NodeSeparation), v.Value, "Node separation must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.RankSeparation" />
        [DotAttributeKey(DotAttributeKeys.RankSep)]
        public virtual DotRankSeparationDefinition RankSeparation
        {
            get
            {
                return GetValueAs<DotRankSeparationDefinition>
                (
                    MethodBase.GetCurrentMethod(),
                    out var value,
                    v => v is int i ? (true, new DotRankSeparation(i)) : (false, default),
                    v => v is double d ? (true, new DotRankSeparation(d)) : (false, default),
                    v => v is double[] da ? (true, new DotRadialRankSeparation(da)) : (false, default)
                )
                    ? value
                    : null;
            }
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotRankSeparationDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.ConcentrateEdges" />
        [DotAttributeKey(DotAttributeKeys.Concentrate)]
        public virtual bool? ConcentrateEdges
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.Engine" />
        [DotAttributeKey(DotAttributeKeys.Layout)]
        public virtual string Engine
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.Direction" />
        [DotAttributeKey(DotAttributeKeys.RankDir)]
        public virtual DotLayoutDirection? Direction
        {
            get => GetValueAs<DotLayoutDirection>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotLayoutDirection?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLayoutDirectionAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.EdgeOrderingMode" />
        [DotAttributeKey(DotAttributeKeys.Ordering)]
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeOrderingMode?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeOrderingModeAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.ForceExternalLabels" />
        [DotAttributeKey(DotAttributeKeys.ForceLabels)]
        public virtual bool? ForceExternalLabels
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphLayoutAttributes.SortIndex" />
        [DotAttributeKey(DotAttributeKeys.SortV)]
        public virtual int? SortIndex
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        /// <summary>
        ///     Copies layout properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotGraphLayoutAttributes attributes)
        {
            ConcentrateEdges = attributes.ConcentrateEdges;
            Direction = attributes.Direction;
            EdgeOrderingMode = attributes.EdgeOrderingMode;
            Engine = attributes.Engine;
            ForceExternalLabels = attributes.ForceExternalLabels;
            NodeRank = attributes.NodeRank;
            NodeSeparation = attributes.NodeSeparation;
            Packing = attributes.Packing;
            PackingMode = attributes.PackingMode;
            RankSeparation = attributes.RankSeparation;
            RepeatCrossingMinimization = attributes.RepeatCrossingMinimization;
            Rotation = attributes.Rotation;
            SortIndex = attributes.SortIndex;
            UseGlobalRanking = attributes.UseGlobalRanking;
        }
    }
}
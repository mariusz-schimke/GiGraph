using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Ranks;
using GiGraph.Dot.Entities.Types.Scaling;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphAttributes : DotEntityCommonAttributes<IDotGraphAttributes>, IDotGraphAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphAttributes, IDotGraphAttributes>().Build();

        protected DotGraphAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEntityHyperlinkAttributes hyperlinkAttributes,
            DotGraphFontAttributes fontAttributes,
            DotGraphStyleAttributes styleAttributes,
            DotGraphClusterAttributes clusterAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            Font = fontAttributes;
            Style = styleAttributes;
            Clusters = clusterAttributes;
        }

        public DotGraphAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                GraphAttributesKeyLookup,
                new DotEntityHyperlinkAttributes(attributes),
                new DotGraphFontAttributes(attributes),
                new DotGraphStyleAttributes(attributes),
                new DotGraphClusterAttributes(attributes)
            )
        {
        }

        public DotGraphAttributes()
            : this(new DotAttributeCollection())
        {
        }

        /// <summary>
        ///     Font properties.
        /// </summary>
        public virtual DotGraphFontAttributes Font { get; }

        /// <summary>
        ///     Style options. Note that the options are shared with those specified for <see cref="Clusters" />.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.Style)]
        public virtual DotGraphStyleAttributes Style { get; }

        /// <summary>
        ///     The graph attributes applied to clusters.
        /// </summary>
        public virtual DotGraphClusterAttributes Clusters { get; }

        // overridden to inherit comment from interface
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        // overridden to inherit comment from interface
        public override string ColorScheme
        {
            get => base.ColorScheme;
            set => base.ColorScheme = value;
        }

        [DotAttributeKey(DotAttributeKeys.Comment)]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.BgColor)]
        public virtual DotColorDefinition BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.GradientAngle)]
        public virtual int? GradientAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.LabelJust)]
        public virtual DotHorizontalAlignment? HorizontalLabelAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotHorizontalAlignment?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotHorizontalAlignmentAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.LabelLoc)]
        public virtual DotVerticalAlignment? VerticalLabelAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotVerticalAlignment?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotVerticalAlignmentAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Ordering)]
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeOrderingMode?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeOrderingModeAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Margin)]
        public virtual DotPoint Margin
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.SortV)]
        public virtual int? SortIndex
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Orientation)]
        public virtual DotOrientation? Orientation
        {
            get => GetValueAs<DotOrientation>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotOrientation?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotOrientationAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.RankDir)]
        public virtual DotLayoutDirection? LayoutDirection
        {
            get => GetValueAs<DotLayoutDirection>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotLayoutDirection?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLayoutDirectionAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Splines)]
        public virtual DotEdgeShape? EdgeShape
        {
            get => GetValueAs<DotEdgeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeShape?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeShapeAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Concentrate)]
        public virtual bool? ConcentrateEdges
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.ForceLabels)]
        public virtual bool? ForceExternalLabels
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Charset)]
        public virtual string Charset
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.NodeSep)]
        public virtual double? NodeSeparation
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(NodeSeparation), v.Value, "Node separation must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

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
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotRankSeparationDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Rotate)]
        public virtual int? Rotation
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Center)]
        public virtual bool? Center
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.ImagePath)]
        public virtual string ImageDirectories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Pad)]
        public virtual DotPoint Padding
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Size)]
        public virtual DotPoint Size
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Ratio)]
        public virtual DotGraphScalingDefinition Scaling
        {
            get
            {
                return GetValueAs<DotGraphScalingDefinition>
                (
                    MethodBase.GetCurrentMethod(),
                    out var value,
                    v => v is int i ? (true, new DotGraphScalingAspectRatio(i)) : (false, default),
                    v => v is double d ? (true, new DotGraphScalingAspectRatio(d)) : (false, default),
                    v => v is DotGraphScaling s ? (true, new DotGraphScalingOption(s)) : (false, default)
                )
                    ? value
                    : null;
            }
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotGraphScalingDefinitionAttribute(k, v));
        }

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
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPackingDefinitionAttribute(k, v));
        }

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
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPackingModeDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Dpi)]
        public virtual double? Dpi
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Dpi), v.Value, "DPI must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Resolution)]
        public virtual double? Resolution
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Resolution), v.Value, "Resolution must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Landscape)]
        public virtual bool? LandscapeOrientation
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }
    }
}
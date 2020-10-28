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
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphAttributes : DotEntityCommonAttributes<IDotGraphAttributes>, IDotGraphAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotGraphAttributes));

        protected DotGraphAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEntityHyperlinkAttributes hyperlinkAttributes,
            DotGraphFontAttributes fontAttributes,
            DotGraphClusterAttributes clusterAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            Font = fontAttributes;
            Clusters = clusterAttributes;
        }

        public DotGraphAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                GraphAttributesKeyLookup,
                new DotEntityHyperlinkAttributes(attributes),
                new DotGraphFontAttributes(attributes),
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
        ///     The graph-level attributes applied to clusters.
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

        // overridden to inherit comment from interface
        public override DotStyles? Style
        {
            get => base.Style;
            set => base.Style = value;
        }
        
        [DotAttributeKey("comment")]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }
        
        [DotAttributeKey("bgcolor")]
        public virtual DotColorDefinition BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey("gradientangle")]
        public virtual int? GradientAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        // TODO: niektóre atrybuty powtarzają się między klasami.
        // Zrobić metody analogiczne do AddOrRemovePenWidth, które obsłużą warunki walidacji?
        
        [DotAttributeKey("labeljust")]
        public virtual DotHorizontalAlignment? HorizontalLabelAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotHorizontalAlignment?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotHorizontalAlignmentAttribute(k, v.Value));
        }

        [DotAttributeKey("labelloc")]
        public virtual DotVerticalAlignment? VerticalLabelAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotVerticalAlignment?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotVerticalAlignmentAttribute(k, v.Value));
        }

        [DotAttributeKey("ordering")]
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeOrderingMode?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeOrderingModeAttribute(k, v.Value));
        }

        [DotAttributeKey("margin")]
        public virtual DotPoint Margin
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        [DotAttributeKey("sortv")]
        public virtual int? SortIndex
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey("orientation")]
        public virtual DotOrientation? Orientation
        {
            get => GetValueAs<DotOrientation>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotOrientation?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotOrientationAttribute(k, v.Value));
        }

        [DotAttributeKey("rankdir")]
        public virtual DotLayoutDirection? LayoutDirection
        {
            get => GetValueAs<DotLayoutDirection>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotLayoutDirection?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLayoutDirectionAttribute(k, v.Value));
        }

        [DotAttributeKey("splines")]
        public virtual DotEdgeShape? EdgeShape
        {
            get => GetValueAs<DotEdgeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeShape?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeShapeAttribute(k, v.Value));
        }

        [DotAttributeKey("concentrate")]
        public virtual bool? ConcentrateEdges
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("forcelabels")]
        public virtual bool? ForceExternalLabels
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("charset")]
        public virtual string Charset
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("nodesep")]
        public virtual double? NodeSeparation
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(NodeSeparation), v.Value, "Node separation must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("ranksep")]
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

        [DotAttributeKey("rotate")]
        public virtual int? RotationAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey("center")]
        public virtual bool? Center
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("imagepath")]
        public virtual string ImageDirectories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("pad")]
        public virtual DotPoint Padding
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        [DotAttributeKey("size")]
        public virtual DotPoint Size
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        [DotAttributeKey("ratio")]
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

        [DotAttributeKey("pack")]
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

        [DotAttributeKey("packmode")]
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

        [DotAttributeKey("dpi")]
        public virtual double? Dpi
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Dpi), v.Value, "DPI must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("resolution")]
        public virtual double? Resolution
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Resolution), v.Value, "Resolution must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("landscape")]
        public virtual bool? LandscapeOrientation
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <summary>
        ///     Applies the specified graph style options to the <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" />
        ///     attribute.
        /// </summary>
        public virtual void SetStyle(DotGraphStyleOptions options)
        {
            base.SetStyle(options);
        }

        /// <summary>
        ///     Applies the specified clusters style options to the
        ///     <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" /> attribute.
        /// </summary>
        public virtual void SetClustersStyle(DotClusterStyleOptions options)
        {
            base.SetStyle(options);
        }

        /// <summary>
        ///     Applies the <see cref="DotStyles.Invisible" /> style option to the
        ///     <see cref="DotEntityCommonAttributes{TIEntityAttributeProperties}.Style" /> attribute, making the border and background of
        ///     clusters invisible.
        /// </summary>
        public virtual void SetClustersInvisible()
        {
            ApplyStyleOption(DotStyles.Invisible);
        }

        // TODO: rozważyć, czy te metody Set...() nie powinny być extension methods podobnie jak ToPolygon i inne
        // TODO: dodać zamiast SetFilled() metody SetGradientFill(DotGradientColor color, bool radial)
        // TODO: oraz SetStriped(DotMultiColor color) -- uwzględnić wagi
        // TODO: oraz SetWedged(DotMultiColor color) -- uwzględnić wagi
        // TODO: oraz SetFilled(DotColorDefinition/DotColor color)
    }
}
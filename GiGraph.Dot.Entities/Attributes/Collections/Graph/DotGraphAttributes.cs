using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Ranks;
using GiGraph.Dot.Entities.Types.Scaling;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public partial class DotGraphAttributes : DotEntityCommonAttributes<IDotGraphAttributes>, IDotGraphAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphAttributes, IDotGraphAttributes>().Build();

        protected DotGraphAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEntityHyperlinkAttributes hyperlinkAttributes,
            DotGraphFontAttributes fontAttributes,
            DotGraphStyleAttributes styleAttributes,
            DotGraphStyleSheetAttributes styleSheetAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            Font = fontAttributes;
            Style = styleAttributes;
            StyleSheet = styleSheetAttributes;
        }

        public DotGraphAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                GraphAttributesKeyLookup,
                new DotEntityHyperlinkAttributes(attributes),
                new DotGraphFontAttributes(attributes),
                new DotGraphStyleAttributes(attributes),
                new DotGraphStyleSheetAttributes(attributes)
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
        public virtual DotGraphStyleAttributes Style { get; }

        /// <summary>
        ///     Style sheet attributes used for SVG output.
        /// </summary>
        public virtual DotGraphStyleSheetAttributes StyleSheet { get; }

        // accessible only through the interface
        [DotAttributeKey(DotEntityStyleAttributes.StyleKey)]
        DotStyles? IDotGraphAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotStyles?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Label" />
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.ColorScheme" />
        public override string ColorScheme
        {
            get => base.ColorScheme;
            set => base.ColorScheme = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Id" />
        public override DotEscapeString Id
        {
            get => base.Id;
            set => base.Id = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.Comment" />
        [DotAttributeKey(DotAttributeKeys.Comment)]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.BackgroundColor" />
        [DotAttributeKey(DotAttributeKeys.BgColor)]
        public virtual DotColorDefinition BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.GradientAngle" />
        [DotAttributeKey(DotAttributeKeys.GradientAngle)]
        public virtual int? GradientAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.HorizontalLabelAlignment" />
        [DotAttributeKey(DotAttributeKeys.LabelJust)]
        public virtual DotHorizontalAlignment? HorizontalLabelAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotHorizontalAlignment?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotHorizontalAlignmentAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.VerticalLabelAlignment" />
        [DotAttributeKey(DotAttributeKeys.LabelLoc)]
        public virtual DotVerticalAlignment? VerticalLabelAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotVerticalAlignment?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotVerticalAlignmentAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.EdgeOrderingMode" />
        [DotAttributeKey(DotAttributeKeys.Ordering)]
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeOrderingMode?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeOrderingModeAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Margin" />
        [DotAttributeKey(DotAttributeKeys.Margin)]
        public virtual DotPoint Margin
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.SortIndex" />
        [DotAttributeKey(DotAttributeKeys.SortV)]
        public virtual int? SortIndex
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Orientation" />
        [DotAttributeKey(DotAttributeKeys.Orientation)]
        public virtual DotOrientation? Orientation
        {
            get => GetValueAs<DotOrientation>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotOrientation?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotOrientationAttribute(k, v.Value));
        }

        // implemented explicitly not to cause confusion (there two other synonymous attributes)
        /// <inheritdoc cref="IDotGraphAttributes.OrientationAngle" />
        [DotAttributeKey(DotAttributeKeys.Rotate)]
        public virtual int? OrientationAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        // implemented explicitly not to cause confusion (there two other synonymous attributes)
        /// <inheritdoc cref="IDotGraphAttributes.LandscapeOrientation" />
        [DotAttributeKey(DotAttributeKeys.Landscape)]
        public virtual bool? LandscapeOrientation
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.LayoutDirection" />
        [DotAttributeKey(DotAttributeKeys.RankDir)]
        public virtual DotLayoutDirection? LayoutDirection
        {
            get => GetValueAs<DotLayoutDirection>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotLayoutDirection?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLayoutDirectionAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.EdgeShape" />
        [DotAttributeKey(DotAttributeKeys.Splines)]
        public virtual DotEdgeShape? EdgeShape
        {
            get => GetValueAs<DotEdgeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeShape?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeShapeAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.ConcentrateEdges" />
        [DotAttributeKey(DotAttributeKeys.Concentrate)]
        public virtual bool? ConcentrateEdges
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.ForceExternalLabels" />
        [DotAttributeKey(DotAttributeKeys.ForceLabels)]
        public virtual bool? ForceExternalLabels
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Charset" />
        [DotAttributeKey(DotAttributeKeys.Charset)]
        public virtual string Charset
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.NodeSeparation" />
        [DotAttributeKey(DotAttributeKeys.NodeSep)]
        public virtual double? NodeSeparation
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(NodeSeparation), v.Value, "Node separation must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.RankSeparation" />
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

        /// <inheritdoc cref="IDotGraphAttributes.Center" />
        [DotAttributeKey(DotAttributeKeys.Center)]
        public virtual bool? Center
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.ImageDirectories" />
        [DotAttributeKey(DotAttributeKeys.ImagePath)]
        public virtual string ImageDirectories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Padding" />
        [DotAttributeKey(DotAttributeKeys.Pad)]
        public virtual DotPoint Padding
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Size" />
        [DotAttributeKey(DotAttributeKeys.Size)]
        public virtual DotPoint Size
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Scaling" />
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
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotGraphScalingDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Packing" />
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

        /// <inheritdoc cref="IDotGraphAttributes.PackingMode" />
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

        /// <inheritdoc cref="IDotGraphAttributes.Dpi" />
        [DotAttributeKey(DotAttributeKeys.Dpi)]
        public virtual double? Dpi
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Dpi), v.Value, "DPI must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Resolution" />
        [DotAttributeKey(DotAttributeKeys.Resolution)]
        public virtual double? Resolution
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Resolution), v.Value, "Resolution must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.RootNodeId" />
        [DotAttributeKey(DotAttributeKeys.Root)]
        public virtual string RootNodeId
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotNodeIdAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Rotation" />
        [DotAttributeKey(DotAttributeKeys.Rotation)]
        public virtual double? Rotation
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }
    }
}
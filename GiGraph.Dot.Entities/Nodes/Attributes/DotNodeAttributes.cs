using System.Reflection;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Labels;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Nodes.Attributes
{
    public partial class DotNodeAttributes : DotClusterNodeCommonAttributes<IDotNodeAttributes>, IDotNodeAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup NodeAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeAttributes, IDotNodeAttributes>().Build();

        protected DotNodeAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotFontAttributes fontAttributes,
            DotNodeStyleAttributes styleAttributes,
            DotNodeImageAttributes imageAttributes,
            DotNodeGeometryAttributes geometryAttributes,
            DotNodeSizeAttributes sizeAttributes,
            DotStyleSheetAttributes styleSheetAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes, styleSheetAttributes)
        {
            Font = fontAttributes;
            Style = styleAttributes;
            Image = imageAttributes;
            Geometry = geometryAttributes;
            Size = sizeAttributes;
        }

        public DotNodeAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                NodeAttributesKeyLookup,
                new DotHyperlinkAttributes(attributes),
                new DotFontAttributes(attributes),
                new DotNodeStyleAttributes(attributes),
                new DotNodeImageAttributes(attributes),
                new DotNodeGeometryAttributes(attributes),
                new DotNodeSizeAttributes(attributes),
                new DotStyleSheetAttributes(attributes)
            )
        {
        }

        public DotNodeAttributes()
            : this(new DotAttributeCollection(DotAttributeFactory.Instance))
        {
        }

        /// <summary>
        ///     Font properties.
        /// </summary>
        public virtual DotFontAttributes Font { get; }

        /// <summary>
        ///     Node image properties.
        /// </summary>
        public virtual DotNodeImageAttributes Image { get; }

        /// <summary>
        ///     Node geometry properties applicable if <see cref="Shape" /> is set to <see cref="DotNodeShape.Polygon" />.
        /// </summary>
        public virtual DotNodeGeometryAttributes Geometry { get; }

        /// <summary>
        ///     Node size properties.
        /// </summary>
        public virtual DotNodeSizeAttributes Size { get; }

        /// <summary>
        ///     Style options.
        /// </summary>
        public virtual DotNodeStyleAttributes Style { get; }

        // accessible only through the interface
        [DotAttributeKey(DotStyleAttributes.StyleKey)]
        DotStyles? IDotNodeAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        /// <inheritdoc cref="IDotNodeAttributes.Label" />
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.ColorScheme" />
        public override string ColorScheme
        {
            get => base.ColorScheme;
            set => base.ColorScheme = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Color" />
        public override DotColorDefinition Color
        {
            get => base.Color;
            set => base.Color = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.FillColor" />
        public override DotColorDefinition FillColor
        {
            get => base.FillColor;
            set => base.FillColor = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.GradientFillAngle" />
        public override int? GradientFillAngle
        {
            get => base.GradientFillAngle;
            set => base.GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Tooltip" />
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Padding" />
        public override DotPoint Padding
        {
            get => base.Padding;
            set => base.Padding = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.BorderWidth" />
        public override double? BorderWidth
        {
            get => base.BorderWidth;
            set => base.BorderWidth = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.SortIndex" />
        public override int? SortIndex
        {
            get => base.SortIndex;
            set => base.SortIndex = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.ObjectId" />
        public override DotEscapeString ObjectId
        {
            get => base.ObjectId;
            set => base.ObjectId = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Comment" />
        [DotAttributeKey(DotAttributeKeys.Comment)]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotNodeAttributes.ExternalLabel" />
        [DotAttributeKey(DotAttributeKeys.XLabel)]
        public virtual DotLabel ExternalLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotNodeAttributes.LabelAlignment" />
        [DotAttributeKey(DotAttributeKeys.LabelLoc)]
        public virtual DotVerticalAlignment? LabelAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        /// <inheritdoc cref="IDotNodeAttributes.EdgeOrderingMode" />
        [DotAttributeKey(DotAttributeKeys.Ordering)]
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        /// <inheritdoc cref="IDotNodeAttributes.Shape" />
        [DotAttributeKey(DotAttributeKeys.Shape)]
        public virtual DotNodeShape? Shape
        {
            get => GetValueAs<DotNodeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        /// <inheritdoc cref="IDotNodeAttributes.GroupName" />
        [DotAttributeKey(DotAttributeKeys.Group)]
        public virtual string GroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotNodeAttributes.IsRoot" />
        [DotAttributeKey(DotAttributeKeys.Root)]
        public virtual bool? IsRoot
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        protected override void SetFillStyle(DotStyles fillStyle)
        {
            Style.FillStyle = (DotNodeFillStyle) fillStyle;
        }
    }
}
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common.ClusterNode;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Attributes
{
    public class DotNodeAttributes : DotClusterNodeCommonAttributes<IDotNodeAttributes>, IDotNodeAttributesRoot
    {
        protected static readonly DotMemberAttributeKeyLookup NodeAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeAttributes, IDotNodeAttributes>().Build();

        protected readonly DotFontAttributes _font;
        protected readonly DotNodeGeometryAttributes _geometry;
        protected readonly DotNodeImageAttributes _image;
        protected readonly DotNodeSizeAttributes _size;
        protected readonly DotNodeStyleAttributes _style;

        protected DotNodeAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotFontAttributes fontAttributes,
            DotNodeStyleAttributes styleAttributes,
            DotNodeImageAttributes imageAttributes,
            DotNodeGeometryAttributes geometryAttributes,
            DotNodeSizeAttributes sizeAttributes,
            DotSvgStyleSheetAttributes svgStyleSheetAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes, svgStyleSheetAttributes)
        {
            _font = fontAttributes;
            _style = styleAttributes;
            _image = imageAttributes;
            _geometry = geometryAttributes;
            _size = sizeAttributes;
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
                new DotSvgStyleSheetAttributes(attributes)
            )
        {
        }

        public DotNodeAttributes()
            : this(new DotAttributeCollection(DotAttributeFactory.Instance))
        {
        }

        DotFontAttributes IDotNodeAttributesRoot.Font => _font;
        DotNodeStyleAttributes IDotNodeAttributesRoot.Style => _style;
        DotNodeSizeAttributes IDotNodeAttributesRoot.Size => _size;
        DotNodeGeometryAttributes IDotNodeAttributesRoot.Geometry => _geometry;
        DotNodeImageAttributes IDotNodeAttributesRoot.Image => _image;
        DotSvgStyleSheetAttributes IDotNodeAttributesRoot.SvgStyleSheet => _svgStyleSheet;

        DotLabel IDotNodeAttributes.Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        string IDotNodeAttributes.ColorScheme
        {
            get => base.ColorScheme;
            set => base.ColorScheme = value;
        }

        DotEscapeString IDotNodeAttributes.ObjectId
        {
            get => base.ObjectId;
            set => base.ObjectId = value;
        }

        [DotAttributeKey(DotAttributeKeys.Color)]
        DotColorDefinition IDotNodeAttributes.Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.FillColor)]
        DotColorDefinition IDotNodeAttributes.FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.GradientAngle)]
        int? IDotNodeAttributes.GradientFillAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        double? IDotNodeAttributes.BorderWidth
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Tooltip)]
        DotEscapeString IDotNodeAttributes.Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Margin)]
        DotPoint IDotNodeAttributes.Padding
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.SortV)]
        int? IDotNodeAttributes.SortIndex
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotStyleAttributes.StyleKey)]
        DotStyles? IDotNodeAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Comment)]
        string IDotNodeAttributes.Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.XLabel)]
        DotLabel IDotNodeAttributes.ExternalLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.LabelLoc)]
        DotVerticalAlignment? IDotNodeAttributes.LabelAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Ordering)]
        DotEdgeOrderingMode? IDotNodeAttributes.EdgeOrderingMode
        {
            get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Shape)]
        DotNodeShape? IDotNodeAttributes.Shape
        {
            get => GetValueAs<DotNodeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Group)]
        string IDotNodeAttributes.GroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Root)]
        bool? IDotNodeAttributes.IsRoot
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        protected override void SetFillStyle(DotStyles fillStyle)
        {
            _style.FillStyle = (DotNodeFillStyle) fillStyle;
        }
    }
}
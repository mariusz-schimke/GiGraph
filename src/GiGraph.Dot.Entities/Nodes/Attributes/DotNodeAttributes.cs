using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Edges;
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
        DotNodeImageAttributes IDotNodeAttributesRoot.Image => _image;
        DotNodeGeometryAttributes IDotNodeAttributesRoot.Geometry => _geometry;
        DotNodeSizeAttributes IDotNodeAttributesRoot.Size => _size;
        DotNodeStyleAttributes IDotNodeAttributesRoot.Style => _style;

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
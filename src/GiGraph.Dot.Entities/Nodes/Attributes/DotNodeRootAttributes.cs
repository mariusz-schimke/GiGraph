using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.ClusterNode;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Attributes
{
    public class DotNodeRootAttributes : DotClusterNodeRootCommonAttributes<IDotNodeAttributes, DotNodeRootAttributes>, IDotNodeRootAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> NodeRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeRootAttributes, IDotNodeAttributes>().BuildLazy();

        protected readonly DotFontAttributes _fontAttributes;
        protected readonly DotNodeGeometryAttributes _geometryAttributes;
        protected readonly DotNodeImageAttributes _imageAttributes;
        protected readonly DotNodeSizeAttributes _sizeAttributes;
        protected readonly DotNodeStyleAttributeOptions _styleAttributeOptions;

        protected DotNodeRootAttributes(
            DotAttributeCollection attributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotFontAttributes fontAttributes,
            DotNodeStyleAttributeOptions styleAttributeOptions,
            DotNodeImageAttributes imageAttributes,
            DotNodeGeometryAttributes geometryAttributes,
            DotNodeSizeAttributes sizeAttributes,
            DotSvgStyleSheetAttributes svgStyleSheetAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes, svgStyleSheetAttributes)
        {
            _fontAttributes = fontAttributes;
            _styleAttributeOptions = styleAttributeOptions;
            _imageAttributes = imageAttributes;
            _geometryAttributes = geometryAttributes;
            _sizeAttributes = sizeAttributes;
        }

        public DotNodeRootAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                NodeRootAttributesKeyLookup,
                new DotHyperlinkAttributes(attributes),
                new DotFontAttributes(attributes),
                new DotNodeStyleAttributeOptions(attributes),
                new DotNodeImageAttributes(attributes),
                new DotNodeGeometryAttributes(attributes),
                new DotNodeSizeAttributes(attributes),
                new DotSvgStyleSheetAttributes(attributes)
            )
        {
        }

        public virtual DotFontAttributes Font => _fontAttributes;
        public virtual DotNodeStyleAttributeOptions Style => _styleAttributeOptions;
        public virtual DotNodeSizeAttributes Size => _sizeAttributes;
        public virtual DotNodeGeometryAttributes Geometry => _geometryAttributes;
        public virtual DotNodeImageAttributes Image => _imageAttributes;

        [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
        DotStyles? IDotNodeAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Comment)]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.XLabel)]
        public virtual DotLabel ExternalLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.LabelLoc)]
        public virtual DotVerticalAlignment? LabelAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Ordering)]
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Shape)]
        public virtual DotNodeShape? Shape
        {
            get => GetValueAs<DotNodeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Group)]
        public virtual string GroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Root)]
        public virtual bool? IsRoot
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Identifiers;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Styling;
using GiGraph.Dot.Entities.Types.Text;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public partial class DotGraphAttributes : DotEntityRootCommonAttributes<IDotGraphAttributes>, IDotGraphAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphAttributes, IDotGraphAttributes>().Build();

        protected DotGraphAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotGraphFontAttributes fontAttributes,
            DotGraphStyleAttributes styleAttributes,
            DotGraphStyleSheetAttributes styleSheetAttributes,
            DotGraphLayoutAttributes layoutAttributes,
            DotGraphCanvasAttributes canvasAttributes,
            DotLabelAlignmentAttributes labelAlignmentAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            Font = fontAttributes;
            Style = styleAttributes;
            StyleSheet = styleSheetAttributes;
            Layout = layoutAttributes;
            Canvas = canvasAttributes;
            LabelAlignment = labelAlignmentAttributes;
        }

        public DotGraphAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                GraphAttributesKeyLookup,
                new DotHyperlinkAttributes(attributes),
                new DotGraphFontAttributes(attributes),
                new DotGraphStyleAttributes(attributes),
                new DotGraphStyleSheetAttributes(attributes),
                new DotGraphLayoutAttributes(attributes),
                new DotGraphCanvasAttributes(attributes),
                new DotLabelAlignmentAttributes(attributes)
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

        /// <summary>
        ///     Graph layout options.
        /// </summary>
        public virtual DotGraphLayoutAttributes Layout { get; }

        /// <summary>
        ///     Graph canvas properties.
        /// </summary>
        public virtual DotGraphCanvasAttributes Canvas { get; }

        /// <summary>
        ///     Horizontal and vertical label alignment options.
        /// </summary>
        public virtual DotLabelAlignmentAttributes LabelAlignment { get; }

        // accessible only through the interface
        [DotAttributeKey(DotStyleAttributes.StyleKey)]
        DotStyles? IDotGraphAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
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

        /// <inheritdoc cref="IDotGraphAttributes.ObjectId" />
        public override DotEscapeString ObjectId
        {
            get => base.ObjectId;
            set => base.ObjectId = value;
        }

        /// <inheritdoc cref="IDotGraphAttributes.EdgeShape" />
        [DotAttributeKey(DotAttributeKeys.Splines)]
        public virtual DotEdgeShape? EdgeShape
        {
            get => GetValueAs<DotEdgeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeShapeAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Comment" />
        [DotAttributeKey(DotAttributeKeys.Comment)]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.Charset" />
        [DotAttributeKey(DotAttributeKeys.Charset)]
        public virtual string Charset
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.ImageDirectories" />
        [DotAttributeKey(DotAttributeKeys.ImagePath)]
        public virtual string ImageDirectories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphAttributes.RootNodeId" />
        [DotAttributeKey(DotAttributeKeys.Root)]
        public virtual DotId RootNodeId
        {
            get => GetValueAsId(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIdAttribute(k, v));
        }
    }
}
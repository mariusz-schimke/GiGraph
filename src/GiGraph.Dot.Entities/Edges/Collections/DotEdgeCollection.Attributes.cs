using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotEdgeCollection : IDotEdgeAttributesRoot
    {
        /// <inheritdoc cref="IDotEdgeAttributesRoot.HeadAttributes" />
        public virtual DotEdgeHeadAttributes HeadAttributes => ((IDotEdgeAttributesRoot) Attributes).HeadAttributes;

        /// <inheritdoc cref="IDotEdgeAttributesRoot.TailAttributes" />
        public virtual DotEdgeTailAttributes TailAttributes => ((IDotEdgeAttributesRoot) Attributes).TailAttributes;

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Font" />
        public virtual DotFontAttributes Font => ((IDotEdgeAttributesRoot) Attributes).Font;

        /// <inheritdoc cref="IDotEdgeAttributesRoot.EndpointLabels" />
        public virtual DotEdgeEndpointLabelsAttributes EndpointLabels => ((IDotEdgeAttributesRoot) Attributes).EndpointLabels;

        /// <inheritdoc cref="IDotEdgeAttributesRoot.EdgeHyperlink" />
        public virtual DotEdgeHyperlinkAttributes EdgeHyperlink => ((IDotEdgeAttributesRoot) Attributes).EdgeHyperlink;

        /// <inheritdoc cref="IDotEdgeAttributesRoot.LabelHyperlink" />
        public virtual DotEdgeLabelHyperlinkAttributes LabelHyperlink => ((IDotEdgeAttributesRoot) Attributes).LabelHyperlink;

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Style" />
        public virtual DotEdgeStyleAttributes Style => ((IDotEdgeAttributesRoot) Attributes).Style;

        /// <inheritdoc cref="IDotEdgeAttributesRoot.SvgStyleSheet" />
        public virtual DotSvgStyleSheetAttributes SvgStyleSheet => ((IDotEdgeAttributesRoot) Attributes).SvgStyleSheet;

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Hyperlink" />
        public virtual DotHyperlinkAttributes Hyperlink => ((IDotEdgeAttributesRoot) Attributes).Hyperlink;

        DotStyles? IDotEdgeAttributes.Style
        {
            get => ((IDotEdgeAttributes) Attributes).Style;
            set => ((IDotEdgeAttributes) Attributes).Style = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Label" />
        public virtual DotLabel Label
        {
            get => ((IDotEdgeAttributes) Attributes).Label;
            set => ((IDotEdgeAttributes) Attributes).Label = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.ExternalLabel" />
        public virtual DotLabel ExternalLabel
        {
            get => ((IDotEdgeAttributes) Attributes).ExternalLabel;
            set => ((IDotEdgeAttributes) Attributes).ExternalLabel = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.AllowLabelFloat" />
        public virtual bool? AllowLabelFloat
        {
            get => ((IDotEdgeAttributes) Attributes).AllowLabelFloat;
            set => ((IDotEdgeAttributes) Attributes).AllowLabelFloat = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.MinLength" />
        public virtual int? MinLength
        {
            get => ((IDotEdgeAttributes) Attributes).MinLength;
            set => ((IDotEdgeAttributes) Attributes).MinLength = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Length" />
        public virtual double? Length
        {
            get => ((IDotEdgeAttributes) Attributes).Length;
            set => ((IDotEdgeAttributes) Attributes).Length = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Weight" />
        public virtual double? Weight
        {
            get => ((IDotEdgeAttributes) Attributes).Weight;
            set => ((IDotEdgeAttributes) Attributes).Weight = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => ((IDotEdgeAttributes) Attributes).Tooltip;
            set => ((IDotEdgeAttributes) Attributes).Tooltip = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Color" />
        public virtual DotColorDefinition Color
        {
            get => ((IDotEdgeAttributes) Attributes).Color;
            set => ((IDotEdgeAttributes) Attributes).Color = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.FillColor" />
        public virtual DotColorDefinition FillColor
        {
            get => ((IDotEdgeAttributes) Attributes).FillColor;
            set => ((IDotEdgeAttributes) Attributes).FillColor = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.ColorScheme" />
        public virtual string ColorScheme
        {
            get => ((IDotEdgeAttributes) Attributes).ColorScheme;
            set => ((IDotEdgeAttributes) Attributes).ColorScheme = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Width" />
        public virtual double? Width
        {
            get => ((IDotEdgeAttributes) Attributes).Width;
            set => ((IDotEdgeAttributes) Attributes).Width = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.ArrowheadScale" />
        public virtual double? ArrowheadScale
        {
            get => ((IDotEdgeAttributes) Attributes).ArrowheadScale;
            set => ((IDotEdgeAttributes) Attributes).ArrowheadScale = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Directions" />
        public virtual DotEdgeDirections? Directions
        {
            get => ((IDotEdgeAttributes) Attributes).Directions;
            set => ((IDotEdgeAttributes) Attributes).Directions = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.AttachLabel" />
        public virtual bool? AttachLabel
        {
            get => ((IDotEdgeAttributes) Attributes).AttachLabel;
            set => ((IDotEdgeAttributes) Attributes).AttachLabel = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Constrain" />
        public virtual bool? Constrain
        {
            get => ((IDotEdgeAttributes) Attributes).Constrain;
            set => ((IDotEdgeAttributes) Attributes).Constrain = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.Comment" />
        public virtual string Comment
        {
            get => ((IDotEdgeAttributes) Attributes).Comment;
            set => ((IDotEdgeAttributes) Attributes).Comment = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributesRoot.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => ((IDotEdgeAttributes) Attributes).ObjectId;
            set => ((IDotEdgeAttributes) Attributes).ObjectId = value;
        }
    }
}
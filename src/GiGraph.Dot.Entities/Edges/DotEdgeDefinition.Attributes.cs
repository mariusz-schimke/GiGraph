using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract partial class DotEdgeDefinition : IDotEdgeRootAttributes
    {
        DotEdgeHeadAttributes IDotEdgeRootAttributes.Head => ((IDotEdgeRootAttributes) Attributes).Head;
        DotEdgeTailAttributes IDotEdgeRootAttributes.Tail => ((IDotEdgeRootAttributes) Attributes).Tail;

        /// <inheritdoc cref="IDotEdgeRootAttributes.Font" />
        public virtual DotFontAttributes Font => ((IDotEdgeRootAttributes) Attributes).Font;

        /// <inheritdoc cref="IDotEdgeRootAttributes.EndpointLabels" />
        public virtual DotEdgeEndpointLabelsAttributes EndpointLabels => ((IDotEdgeRootAttributes) Attributes).EndpointLabels;

        /// <inheritdoc cref="IDotEdgeRootAttributes.EdgeHyperlink" />
        public virtual DotEdgeHyperlinkAttributes EdgeHyperlink => ((IDotEdgeRootAttributes) Attributes).EdgeHyperlink;

        /// <inheritdoc cref="IDotEdgeRootAttributes.LabelHyperlink" />
        public virtual DotEdgeLabelHyperlinkAttributes LabelHyperlink => ((IDotEdgeRootAttributes) Attributes).LabelHyperlink;

        /// <inheritdoc cref="IDotEdgeRootAttributes.Style" />
        public virtual DotEdgeStyleAttributes Style => ((IDotEdgeRootAttributes) Attributes).Style;

        /// <inheritdoc cref="IDotEdgeRootAttributes.SvgStyleSheet" />
        public virtual DotSvgStyleSheetAttributes SvgStyleSheet => ((IDotEdgeRootAttributes) Attributes).SvgStyleSheet;

        /// <inheritdoc cref="IDotEdgeRootAttributes.Hyperlink" />
        public virtual DotHyperlinkAttributes Hyperlink => ((IDotEdgeRootAttributes) Attributes).Hyperlink;

        DotStyles? IDotEdgeAttributes.Style
        {
            get => ((IDotEdgeAttributes) Attributes).Style;
            set => ((IDotEdgeAttributes) Attributes).Style = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Label" />
        public virtual DotLabel Label
        {
            get => ((IDotEdgeAttributes) Attributes).Label;
            set => ((IDotEdgeAttributes) Attributes).Label = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ExternalLabel" />
        public virtual DotLabel ExternalLabel
        {
            get => ((IDotEdgeAttributes) Attributes).ExternalLabel;
            set => ((IDotEdgeAttributes) Attributes).ExternalLabel = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.AllowLabelFloat" />
        public virtual bool? AllowLabelFloat
        {
            get => ((IDotEdgeAttributes) Attributes).AllowLabelFloat;
            set => ((IDotEdgeAttributes) Attributes).AllowLabelFloat = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.MinLength" />
        public virtual int? MinLength
        {
            get => ((IDotEdgeAttributes) Attributes).MinLength;
            set => ((IDotEdgeAttributes) Attributes).MinLength = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Length" />
        public virtual double? Length
        {
            get => ((IDotEdgeAttributes) Attributes).Length;
            set => ((IDotEdgeAttributes) Attributes).Length = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Weight" />
        public virtual double? Weight
        {
            get => ((IDotEdgeAttributes) Attributes).Weight;
            set => ((IDotEdgeAttributes) Attributes).Weight = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => ((IDotEdgeAttributes) Attributes).Tooltip;
            set => ((IDotEdgeAttributes) Attributes).Tooltip = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Color" />
        public virtual DotColorDefinition Color
        {
            get => ((IDotEdgeAttributes) Attributes).Color;
            set => ((IDotEdgeAttributes) Attributes).Color = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.FillColor" />
        public virtual DotColorDefinition FillColor
        {
            get => ((IDotEdgeAttributes) Attributes).FillColor;
            set => ((IDotEdgeAttributes) Attributes).FillColor = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ColorScheme" />
        public virtual string ColorScheme
        {
            get => ((IDotEdgeAttributes) Attributes).ColorScheme;
            set => ((IDotEdgeAttributes) Attributes).ColorScheme = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Width" />
        public virtual double? Width
        {
            get => ((IDotEdgeAttributes) Attributes).Width;
            set => ((IDotEdgeAttributes) Attributes).Width = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ArrowheadScale" />
        public virtual double? ArrowheadScale
        {
            get => ((IDotEdgeAttributes) Attributes).ArrowheadScale;
            set => ((IDotEdgeAttributes) Attributes).ArrowheadScale = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Directions" />
        public virtual DotEdgeDirections? Directions
        {
            get => ((IDotEdgeAttributes) Attributes).Directions;
            set => ((IDotEdgeAttributes) Attributes).Directions = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.AttachLabel" />
        public virtual bool? AttachLabel
        {
            get => ((IDotEdgeAttributes) Attributes).AttachLabel;
            set => ((IDotEdgeAttributes) Attributes).AttachLabel = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Constrain" />
        public virtual bool? Constrain
        {
            get => ((IDotEdgeAttributes) Attributes).Constrain;
            set => ((IDotEdgeAttributes) Attributes).Constrain = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Comment" />
        public virtual string Comment
        {
            get => ((IDotEdgeAttributes) Attributes).Comment;
            set => ((IDotEdgeAttributes) Attributes).Comment = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => ((IDotEdgeAttributes) Attributes).ObjectId;
            set => ((IDotEdgeAttributes) Attributes).ObjectId = value;
        }
    }
}
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract partial class DotEdgeDefinition : IDotEdgeRootAttributes
    {
        // hidden by explicit implementation because they are exposed through separate properties of descendant classes
        DotEdgeHeadAttributes IDotEdgeRootAttributes.Head => Attributes.Attributes.Head;
        DotEdgeTailAttributes IDotEdgeRootAttributes.Tail => Attributes.Attributes.Tail;


        /// <inheritdoc cref="IDotEdgeRootAttributes.Font" />
        public virtual DotFontAttributes Font => Attributes.Attributes.Font;

        /// <inheritdoc cref="IDotEdgeRootAttributes.EndpointLabels" />
        public virtual DotEdgeEndpointLabelsAttributes EndpointLabels => Attributes.Attributes.EndpointLabels;

        /// <inheritdoc cref="IDotEdgeRootAttributes.EdgeHyperlink" />
        public virtual DotEdgeHyperlinkAttributes EdgeHyperlink => Attributes.Attributes.EdgeHyperlink;

        /// <inheritdoc cref="IDotEdgeRootAttributes.LabelHyperlink" />
        public virtual DotEdgeLabelHyperlinkAttributes LabelHyperlink => Attributes.Attributes.LabelHyperlink;

        /// <inheritdoc cref="IDotEdgeRootAttributes.Style" />
        public virtual DotEdgeStyleAttributeOptions Style => Attributes.Attributes.Style;

        /// <inheritdoc cref="IDotEdgeRootAttributes.SvgStyleSheet" />
        public virtual DotSvgStyleSheetAttributes SvgStyleSheet => Attributes.Attributes.SvgStyleSheet;

        /// <inheritdoc cref="IDotEdgeRootAttributes.Hyperlink" />
        public virtual DotHyperlinkAttributes Hyperlink => Attributes.Attributes.Hyperlink;

        DotStyles? IDotEdgeAttributes.Style
        {
            get => ((IDotEdgeAttributes) Attributes.Attributes).Style;
            set => ((IDotEdgeAttributes) Attributes.Attributes).Style = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Label" />
        public virtual DotLabel Label
        {
            get => Attributes.Attributes.Label;
            set => Attributes.Attributes.Label = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ExternalLabel" />
        public virtual DotLabel ExternalLabel
        {
            get => Attributes.Attributes.ExternalLabel;
            set => Attributes.Attributes.ExternalLabel = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.AllowLabelFloat" />
        public virtual bool? AllowLabelFloat
        {
            get => Attributes.Attributes.AllowLabelFloat;
            set => Attributes.Attributes.AllowLabelFloat = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.MinLength" />
        public virtual int? MinLength
        {
            get => Attributes.Attributes.MinLength;
            set => Attributes.Attributes.MinLength = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Length" />
        public virtual double? Length
        {
            get => Attributes.Attributes.Length;
            set => Attributes.Attributes.Length = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Weight" />
        public virtual double? Weight
        {
            get => Attributes.Attributes.Weight;
            set => Attributes.Attributes.Weight = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => Attributes.Attributes.Tooltip;
            set => Attributes.Attributes.Tooltip = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Color" />
        public virtual DotColorDefinition Color
        {
            get => Attributes.Attributes.Color;
            set => Attributes.Attributes.Color = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.FillColor" />
        public virtual DotColorDefinition FillColor
        {
            get => Attributes.Attributes.FillColor;
            set => Attributes.Attributes.FillColor = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ColorScheme" />
        public virtual string ColorScheme
        {
            get => Attributes.Attributes.ColorScheme;
            set => Attributes.Attributes.ColorScheme = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Width" />
        public virtual double? Width
        {
            get => Attributes.Attributes.Width;
            set => Attributes.Attributes.Width = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ArrowheadScale" />
        public virtual double? ArrowheadScale
        {
            get => Attributes.Attributes.ArrowheadScale;
            set => Attributes.Attributes.ArrowheadScale = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Directions" />
        public virtual DotEdgeDirections? Directions
        {
            get => Attributes.Attributes.Directions;
            set => Attributes.Attributes.Directions = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.AttachLabel" />
        public virtual bool? AttachLabel
        {
            get => Attributes.Attributes.AttachLabel;
            set => Attributes.Attributes.AttachLabel = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Constrain" />
        public virtual bool? Constrain
        {
            get => Attributes.Attributes.Constrain;
            set => Attributes.Attributes.Constrain = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Comment" />
        public virtual string Comment
        {
            get => Attributes.Attributes.Comment;
            set => Attributes.Attributes.Comment = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => Attributes.Attributes.ObjectId;
            set => Attributes.Attributes.ObjectId = value;
        }
    }
}
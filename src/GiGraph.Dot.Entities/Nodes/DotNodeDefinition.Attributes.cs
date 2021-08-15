using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes
{
    public abstract partial class DotNodeDefinition : IDotNodeRootAttributes
    {
        /// <inheritdoc cref="IDotNodeRootAttributes.Font" />
        public virtual DotFontAttributes Font => ((IDotNodeRootAttributes) Attributes).Font;

        /// <inheritdoc cref="IDotNodeRootAttributes.Image" />
        public virtual DotNodeImageAttributes Image => ((IDotNodeRootAttributes) Attributes).Image;

        /// <inheritdoc cref="IDotNodeRootAttributes.Geometry" />
        public virtual DotNodeGeometryAttributes Geometry => ((IDotNodeRootAttributes) Attributes).Geometry;

        /// <inheritdoc cref="IDotNodeRootAttributes.Size" />
        public virtual DotNodeSizeAttributes Size => ((IDotNodeRootAttributes) Attributes).Size;

        /// <inheritdoc cref="IDotNodeRootAttributes.Style" />
        public virtual DotNodeStyleAttributes Style => ((IDotNodeRootAttributes) Attributes).Style;

        /// <inheritdoc cref="IDotNodeRootAttributes.SvgStyleSheet" />
        public virtual DotSvgStyleSheetAttributes SvgStyleSheet => ((IDotNodeRootAttributes) Attributes).SvgStyleSheet;

        /// <inheritdoc cref="IDotNodeRootAttributes.SvgStyleSheet" />
        public virtual DotHyperlinkAttributes Hyperlink => ((IDotNodeRootAttributes) Attributes).Hyperlink;

        DotStyles? IDotNodeAttributes.Style
        {
            get => ((IDotNodeAttributes) Attributes).Style;
            set => ((IDotNodeAttributes) Attributes).Style = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Label" />
        public virtual DotLabel Label
        {
            get => ((IDotNodeAttributes) Attributes).Label;
            set => ((IDotNodeAttributes) Attributes).Label = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.ExternalLabel" />
        public virtual DotLabel ExternalLabel
        {
            get => ((IDotNodeAttributes) Attributes).ExternalLabel;
            set => ((IDotNodeAttributes) Attributes).ExternalLabel = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.LabelAlignment" />
        public virtual DotVerticalAlignment? LabelAlignment
        {
            get => ((IDotNodeAttributes) Attributes).LabelAlignment;
            set => ((IDotNodeAttributes) Attributes).LabelAlignment = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => ((IDotNodeAttributes) Attributes).Tooltip;
            set => ((IDotNodeAttributes) Attributes).Tooltip = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Color" />
        public virtual DotColorDefinition Color
        {
            get => ((IDotNodeAttributes) Attributes).Color;
            set => ((IDotNodeAttributes) Attributes).Color = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.FillColor" />
        public virtual DotColorDefinition FillColor
        {
            get => ((IDotNodeAttributes) Attributes).FillColor;
            set => ((IDotNodeAttributes) Attributes).FillColor = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.ColorScheme" />
        public virtual string ColorScheme
        {
            get => ((IDotNodeAttributes) Attributes).ColorScheme;
            set => ((IDotNodeAttributes) Attributes).ColorScheme = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.GradientFillAngle" />
        public virtual int? GradientFillAngle
        {
            get => ((IDotNodeAttributes) Attributes).GradientFillAngle;
            set => ((IDotNodeAttributes) Attributes).GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.BorderWidth" />
        public virtual double? BorderWidth
        {
            get => ((IDotNodeAttributes) Attributes).BorderWidth;
            set => ((IDotNodeAttributes) Attributes).BorderWidth = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Shape" />
        public virtual DotNodeShape? Shape
        {
            get => ((IDotNodeAttributes) Attributes).Shape;
            set => ((IDotNodeAttributes) Attributes).Shape = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Padding" />
        public virtual DotPoint Padding
        {
            get => ((IDotNodeAttributes) Attributes).Padding;
            set => ((IDotNodeAttributes) Attributes).Padding = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Comment" />
        public virtual string Comment
        {
            get => ((IDotNodeAttributes) Attributes).Comment;
            set => ((IDotNodeAttributes) Attributes).Comment = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.EdgeOrderingMode" />
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => ((IDotNodeAttributes) Attributes).EdgeOrderingMode;
            set => ((IDotNodeAttributes) Attributes).EdgeOrderingMode = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.GroupName" />
        public virtual string GroupName
        {
            get => ((IDotNodeAttributes) Attributes).GroupName;
            set => ((IDotNodeAttributes) Attributes).GroupName = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.SortIndex" />
        public virtual int? SortIndex
        {
            get => ((IDotNodeAttributes) Attributes).SortIndex;
            set => ((IDotNodeAttributes) Attributes).SortIndex = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.IsRoot" />
        public virtual bool? IsRoot
        {
            get => ((IDotNodeAttributes) Attributes).IsRoot;
            set => ((IDotNodeAttributes) Attributes).IsRoot = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => ((IDotNodeAttributes) Attributes).ObjectId;
            set => ((IDotNodeAttributes) Attributes).ObjectId = value;
        }
    }
}
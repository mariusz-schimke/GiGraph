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
        public virtual DotFontAttributes Font => Attributes.Attributes.Font;

        /// <inheritdoc cref="IDotNodeRootAttributes.Image" />
        public virtual DotNodeImageAttributes Image => Attributes.Attributes.Image;

        /// <inheritdoc cref="IDotNodeRootAttributes.Geometry" />
        public virtual DotNodeGeometryAttributes Geometry => Attributes.Attributes.Geometry;

        /// <inheritdoc cref="IDotNodeRootAttributes.Size" />
        public virtual DotNodeSizeAttributes Size => Attributes.Attributes.Size;

        /// <inheritdoc cref="IDotNodeRootAttributes.Style" />
        public virtual DotNodeStyleAttributeOptions Style => Attributes.Attributes.Style;

        /// <inheritdoc cref="IDotNodeRootAttributes.SvgStyleSheet" />
        public virtual DotSvgStyleSheetAttributes SvgStyleSheet => Attributes.Attributes.SvgStyleSheet;

        /// <inheritdoc cref="IDotNodeRootAttributes.Hyperlink" />
        public virtual DotHyperlinkAttributes Hyperlink => Attributes.Attributes.Hyperlink;

        DotStyles? IDotNodeAttributes.Style
        {
            get => ((IDotNodeAttributes) Attributes.Attributes).Style;
            set => ((IDotNodeAttributes) Attributes.Attributes).Style = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Label" />
        public virtual DotLabel Label
        {
            get => Attributes.Attributes.Label;
            set => Attributes.Attributes.Label = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.ExternalLabel" />
        public virtual DotLabel ExternalLabel
        {
            get => Attributes.Attributes.ExternalLabel;
            set => Attributes.Attributes.ExternalLabel = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.LabelAlignment" />
        public virtual DotVerticalAlignment? LabelAlignment
        {
            get => Attributes.Attributes.LabelAlignment;
            set => Attributes.Attributes.LabelAlignment = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => Attributes.Attributes.Tooltip;
            set => Attributes.Attributes.Tooltip = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Color" />
        public virtual DotColorDefinition Color
        {
            get => Attributes.Attributes.Color;
            set => Attributes.Attributes.Color = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.FillColor" />
        public virtual DotColorDefinition FillColor
        {
            get => Attributes.Attributes.FillColor;
            set => Attributes.Attributes.FillColor = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.ColorScheme" />
        public virtual string ColorScheme
        {
            get => Attributes.Attributes.ColorScheme;
            set => Attributes.Attributes.ColorScheme = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.GradientFillAngle" />
        public virtual int? GradientFillAngle
        {
            get => Attributes.Attributes.GradientFillAngle;
            set => Attributes.Attributes.GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.BorderWidth" />
        public virtual double? BorderWidth
        {
            get => Attributes.Attributes.BorderWidth;
            set => Attributes.Attributes.BorderWidth = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Shape" />
        public virtual DotNodeShape? Shape
        {
            get => Attributes.Attributes.Shape;
            set => Attributes.Attributes.Shape = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Padding" />
        public virtual DotPoint Padding
        {
            get => Attributes.Attributes.Padding;
            set => Attributes.Attributes.Padding = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.Comment" />
        public virtual string Comment
        {
            get => Attributes.Attributes.Comment;
            set => Attributes.Attributes.Comment = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.EdgeOrderingMode" />
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => Attributes.Attributes.EdgeOrderingMode;
            set => Attributes.Attributes.EdgeOrderingMode = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.GroupName" />
        public virtual string GroupName
        {
            get => Attributes.Attributes.GroupName;
            set => Attributes.Attributes.GroupName = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.SortIndex" />
        public virtual int? SortIndex
        {
            get => Attributes.Attributes.SortIndex;
            set => Attributes.Attributes.SortIndex = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.IsRoot" />
        public virtual bool? IsRoot
        {
            get => Attributes.Attributes.IsRoot;
            set => Attributes.Attributes.IsRoot = value;
        }

        /// <inheritdoc cref="IDotNodeAttributes.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => Attributes.Attributes.ObjectId;
            set => Attributes.Attributes.ObjectId = value;
        }
    }
}
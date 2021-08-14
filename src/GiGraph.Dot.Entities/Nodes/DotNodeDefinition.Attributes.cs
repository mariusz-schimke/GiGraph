using GiGraph.Dot.Entities.Attributes.Properties.Common;
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
    public abstract partial class DotNodeDefinition : IDotNodeAttributesRoot
    {
        /// <inheritdoc cref="IDotNodeAttributesRoot.Font" />
        public virtual DotFontAttributes Font => ((IDotNodeAttributesRoot) Attributes).Font;

        /// <inheritdoc cref="IDotNodeAttributesRoot.Image" />
        public virtual DotNodeImageAttributes Image => ((IDotNodeAttributesRoot) Attributes).Image;

        /// <inheritdoc cref="IDotNodeAttributesRoot.Geometry" />
        public virtual DotNodeGeometryAttributes Geometry => ((IDotNodeAttributesRoot) Attributes).Geometry;

        /// <inheritdoc cref="IDotNodeAttributesRoot.Size" />
        public virtual DotNodeSizeAttributes Size => ((IDotNodeAttributesRoot) Attributes).Size;

        /// <inheritdoc cref="IDotNodeAttributesRoot.Style" />
        public virtual DotNodeStyleAttributes Style => ((IDotNodeAttributesRoot) Attributes).Style;

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
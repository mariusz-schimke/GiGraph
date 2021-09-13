using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters
{
    public partial class DotClusterSection : IDotClusterRootAttributes
    {
        /// <inheritdoc cref="IDotClusterRootAttributes.Font" />
        public virtual DotFontAttributes Font => Attributes.Attributes.Font;

        /// <inheritdoc cref="IDotClusterRootAttributes.Style" />
        public virtual DotClusterStyleAttributeOptions Style => Attributes.Attributes.Style;

        /// <inheritdoc cref="IDotClusterRootAttributes.LabelAlignment" />
        public virtual DotLabelAlignmentAttributes LabelAlignment => Attributes.Attributes.LabelAlignment;

        /// <inheritdoc cref="IDotClusterRootAttributes.SvgStyleSheet" />
        public virtual DotSvgStyleSheetAttributes SvgStyleSheet => Attributes.Attributes.SvgStyleSheet;

        /// <inheritdoc cref="IDotClusterRootAttributes.Hyperlink" />
        public virtual DotHyperlinkAttributes Hyperlink => Attributes.Attributes.Hyperlink;

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.Color" />
        public virtual DotColorDefinition Color
        {
            get => Attributes.Attributes.Color;
            set => Attributes.Attributes.Color = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.FillColor" />
        public virtual DotColorDefinition FillColor
        {
            get => Attributes.Attributes.FillColor;
            set => Attributes.Attributes.FillColor = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderWidth" />
        public virtual double? BorderWidth
        {
            get => Attributes.Attributes.BorderWidth;
            set => Attributes.Attributes.BorderWidth = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderColor" />
        public virtual DotColor BorderColor
        {
            get => Attributes.Attributes.BorderColor;
            set => Attributes.Attributes.BorderColor = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Style" />
        DotStyles? IDotClusterAttributes.Style
        {
            get => ((IDotClusterAttributes) Attributes.Attributes).Style;
            set => ((IDotClusterAttributes) Attributes.Attributes).Style = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Label" />
        public virtual DotLabel Label
        {
            get => Attributes.Attributes.Label;
            set => Attributes.Attributes.Label = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => Attributes.Attributes.Tooltip;
            set => Attributes.Attributes.Tooltip = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.BackgroundColor" />
        public virtual DotColorDefinition BackgroundColor
        {
            get => Attributes.Attributes.BackgroundColor;
            set => Attributes.Attributes.BackgroundColor = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.ColorScheme" />
        public virtual string ColorScheme
        {
            get => Attributes.Attributes.ColorScheme;
            set => Attributes.Attributes.ColorScheme = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.GradientFillAngle" />
        public virtual int? GradientFillAngle
        {
            get => Attributes.Attributes.GradientFillAngle;
            set => Attributes.Attributes.GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Peripheries" />
        public virtual int? Peripheries
        {
            get => Attributes.Attributes.Peripheries;
            set => Attributes.Attributes.Peripheries = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Padding" />
        public virtual DotPoint Padding
        {
            get => Attributes.Attributes.Padding;
            set => Attributes.Attributes.Padding = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.SortIndex" />
        public virtual int? SortIndex
        {
            get => Attributes.Attributes.SortIndex;
            set => Attributes.Attributes.SortIndex = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => Attributes.Attributes.ObjectId;
            set => Attributes.Attributes.ObjectId = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.NodeRank" />
        public virtual DotRank? NodeRank
        {
            get => Attributes.Attributes.NodeRank;
            set => Attributes.Attributes.NodeRank = value;
        }
    }
}
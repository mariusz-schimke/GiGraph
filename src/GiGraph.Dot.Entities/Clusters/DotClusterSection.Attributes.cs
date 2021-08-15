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
    public partial class DotClusterSection : IDotClusterAttributesRoot
    {
        /// <inheritdoc cref="IDotClusterAttributesRoot.Font" />
        public virtual DotFontAttributes Font => ((IDotClusterAttributesRoot) Attributes).Font;

        /// <inheritdoc cref="IDotClusterAttributesRoot.Style" />
        public virtual DotClusterStyleAttributes Style => ((IDotClusterAttributesRoot) Attributes).Style;

        /// <inheritdoc cref="IDotClusterAttributesRoot.LabelAlignment" />
        public virtual DotLabelAlignmentAttributes LabelAlignment => ((IDotClusterAttributesRoot) Attributes).LabelAlignment;

        /// <inheritdoc cref="IDotClusterAttributesRoot.SvgStyleSheet" />
        public virtual DotSvgStyleSheetAttributes SvgStyleSheet => ((IDotClusterAttributesRoot) Attributes).SvgStyleSheet;

        /// <inheritdoc cref="IDotClusterAttributesRoot.SvgStyleSheet" />
        public virtual DotHyperlinkAttributes Hyperlink => ((IDotClusterAttributesRoot) Attributes).Hyperlink;

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.Color" />
        public virtual DotColorDefinition Color
        {
            get => ((IDotClusterAttributes) Attributes).Color;
            set => ((IDotClusterAttributes) Attributes).Color = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.FillColor" />
        public virtual DotColorDefinition FillColor
        {
            get => ((IDotClusterAttributes) Attributes).FillColor;
            set => ((IDotClusterAttributes) Attributes).FillColor = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderWidth" />
        public virtual double? BorderWidth
        {
            get => ((IDotClusterAttributes) Attributes).BorderWidth;
            set => ((IDotClusterAttributes) Attributes).BorderWidth = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderColor" />
        public virtual DotColor BorderColor
        {
            get => ((IDotClusterAttributes) Attributes).BorderColor;
            set => ((IDotClusterAttributes) Attributes).BorderColor = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Style" />
        DotStyles? IDotClusterAttributes.Style
        {
            get => ((IDotClusterAttributes) Attributes).Style;
            set => ((IDotClusterAttributes) Attributes).Style = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Label" />
        public virtual DotLabel Label
        {
            get => ((IDotClusterAttributes) Attributes).Label;
            set => ((IDotClusterAttributes) Attributes).Label = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Tooltip" />
        public virtual DotEscapeString Tooltip
        {
            get => ((IDotClusterAttributes) Attributes).Tooltip;
            set => ((IDotClusterAttributes) Attributes).Tooltip = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.BackgroundColor" />
        public virtual DotColorDefinition BackgroundColor
        {
            get => ((IDotClusterAttributes) Attributes).BackgroundColor;
            set => ((IDotClusterAttributes) Attributes).BackgroundColor = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.ColorScheme" />
        public virtual string ColorScheme
        {
            get => ((IDotClusterAttributes) Attributes).ColorScheme;
            set => ((IDotClusterAttributes) Attributes).ColorScheme = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.GradientFillAngle" />
        public virtual int? GradientFillAngle
        {
            get => ((IDotClusterAttributes) Attributes).GradientFillAngle;
            set => ((IDotClusterAttributes) Attributes).GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Peripheries" />
        public virtual int? Peripheries
        {
            get => ((IDotClusterAttributes) Attributes).Peripheries;
            set => ((IDotClusterAttributes) Attributes).Peripheries = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Padding" />
        public virtual DotPoint Padding
        {
            get => ((IDotClusterAttributes) Attributes).Padding;
            set => ((IDotClusterAttributes) Attributes).Padding = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.SortIndex" />
        public virtual int? SortIndex
        {
            get => ((IDotClusterAttributes) Attributes).SortIndex;
            set => ((IDotClusterAttributes) Attributes).SortIndex = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.ObjectId" />
        public virtual DotEscapeString ObjectId
        {
            get => ((IDotClusterAttributes) Attributes).ObjectId;
            set => ((IDotClusterAttributes) Attributes).ObjectId = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.NodeRank" />
        public virtual DotRank? NodeRank
        {
            get => ((IDotClusterAttributes) Attributes).NodeRank;
            set => ((IDotClusterAttributes) Attributes).NodeRank = value;
        }
    }
}